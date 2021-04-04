namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        { 
            var projects = context.Projects.ToArray()
                .Where(x => x.Tasks.Any())
                .Select(x => new ProjectOutputModelXml
                {
                    TasksCount = x.Tasks.Count,
                    Name = x.Name,
                    HasEndDate = (x.DueDate.HasValue ? "Yes" : "No"),
                    Tasks = x.Tasks.Select(t => new TaskOutputModelXml
                    {
                        Name = t.Name,
                        Label = t.LabelType.ToString(),
                    })
                    .OrderBy(x => x.Name)
                    .ToArray()
                })
                .OrderByDescending(x => x.TasksCount)
                .ThenBy(x => x.Name)
                .ToArray();

            XmlSerializer xmlSerializer =
                new XmlSerializer(typeof(ProjectOutputModelXml[]), new XmlRootAttribute("Projects"));

            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");

            var stringWriter = new StringWriter();

            xmlSerializer.Serialize(stringWriter, projects, ns);

            return stringWriter.ToString();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {

            var employees = context.Employees.ToArray()
               .Where(x => x.EmployeesTasks.Any(x => x.Task.OpenDate >= date))
               .Select(x => new
               {
                   Username = x.Username,
                   Tasks = x.EmployeesTasks
                      .Where(t => t.Task.OpenDate >= date)
                      .OrderByDescending(t => t.Task.DueDate)
                      .ThenBy(x => x.Task.Name)
                      .Select(t => new
                       {
                           TaskName = t.Task.Name,
                           OpenDate = t.Task.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                           DueDate = t.Task.DueDate.ToString("d", CultureInfo.InvariantCulture),
                           LabelType = t.Task.LabelType.ToString(),
                           ExecutionType = t.Task.ExecutionType.ToString(),
                       })
                   
                   .ToList()
                 })
                 .OrderByDescending(x => x.Tasks.Count())
                 .ThenBy(x => x.Username)
                 .Take(10)
                 .ToList();


            return JsonConvert.SerializeObject(employees, Formatting.Indented);
        }

    }
}