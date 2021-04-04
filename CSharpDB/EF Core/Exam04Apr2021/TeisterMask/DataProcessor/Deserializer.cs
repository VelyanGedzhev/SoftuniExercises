namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var output = new StringBuilder();
            var projects = new List<Project>();

            var xmlSerializer =
                new XmlSerializer(typeof(ProjectInputModelXml[]), new XmlRootAttribute("Projects"));

            var xmlProjects = (ProjectInputModelXml[])xmlSerializer.Deserialize(new StringReader(xmlString));

            foreach (var xmlProject in xmlProjects)
            {
                if (!IsValid(xmlProject))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var isValidOpenDate =
                    DateTime.TryParseExact(xmlProject.OpenDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime projectOpenDate);

                var isValidDueDate =
                    DateTime.TryParseExact(xmlProject.DueDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime projectDueDate);


                if (!isValidOpenDate)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var project = new Project
                {
                    Name = xmlProject.Name,
                    OpenDate = projectOpenDate,
                    DueDate = projectDueDate,
                };

                if (project.DueDate.Value.Year == 0001)
                {
                    project.DueDate = null;
                }

                foreach (var xmlTask in xmlProject.Tasks)
                {
                    var isValidTaskOpenDate =
                    DateTime.TryParseExact(xmlTask.OpenDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime taskOpenDate);

                    var isValidTaskDueDate =
                    DateTime.TryParseExact(xmlTask.DueDate, "dd/MM/yyyy",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime taskDueDate);

                    if (project.DueDate == null)
                    {
                        if (!IsValid(xmlTask) ||
                        taskOpenDate < project.OpenDate)
                        {
                            output.AppendLine(ErrorMessage);
                            continue;
                        } 
                    } 
                    else if (!IsValid(xmlTask) ||
                        taskOpenDate < project.OpenDate ||
                        taskDueDate > project.DueDate)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    var task = new Task
                    {
                        Name = xmlTask.Name,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = Enum.Parse<ExecutionType>(xmlTask.ExecutionType),
                        LabelType = Enum.Parse<LabelType>(xmlTask.LabelType),
                    };

                    project.Tasks.Add(task);
                }
                projects.Add(project);

                output
                    .AppendLine(string.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));
            }
            context.Projects.AddRange(projects);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var output = new StringBuilder();
            var employees = new List<Employee>();

            var jsonEmployees = JsonConvert.DeserializeObject<IEnumerable<EmployeeInputModelJson>>(jsonString);

            foreach (var jsonEmployee in jsonEmployees)
            {
                if (!IsValid(jsonEmployee))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var employee = new Employee
                {
                    Username = jsonEmployee.Username,
                    Email = jsonEmployee.Email,
                    Phone = jsonEmployee.Phone,
                };

                foreach (var jsonTask in jsonEmployee.Tasks)
                {
                    var task = context.Tasks.FirstOrDefault(x => x.Id == jsonTask);

                    if (task == null)
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (employee.EmployeesTasks.Any(x => x.TaskId == jsonTask))
                    {
                        continue;
                    }

                    employee.EmployeesTasks.Add(new EmployeeTask { TaskId = task.Id});
                }

                employees.Add(employee);
                output.AppendLine(string.Format(SuccessfullyImportedEmployee, employee.Username, employee.EmployeesTasks.Count));
            }
            context.Employees.AddRange(employees);
            context.SaveChanges();

            return output.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}