﻿using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new SoftUniContext();

            //var employees = GetEmployeesFullInformation(db);
            //Console.WriteLine(employees);

            //var employees = GetEmployeesWithSalaryOver50000(db);
            //Console.WriteLine(employees);

            //var employees = GetEmployeesFromResearchAndDevelopment(db);
            //Console.WriteLine(employees);

            var addresses = AddNewAddressToEmployee(db);
            Console.WriteLine(addresses);

        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(x => new
                {
                    x.EmployeeId,
                    x.FirstName,
                    x.MiddleName,
                    x.LastName,
                    x.JobTitle,
                    x.Salary,
                })
                .OrderBy(x => x.EmployeeId)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(x => new
                {
                    x.FirstName,
                    x.Salary,
                })
                .Where(x => x.Salary > 50_000)
                .OrderBy(x => x.FirstName)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var employees = context.Employees
                .Select(x => new
                {
                    x.FirstName,
                    x.LastName,
                    x.Department,
                    x.Salary
                })
                .Where(x => x.Department.Name == "Research and Development")
                .OrderBy(x => x.Salary)
                .ThenByDescending(x => x.FirstName)
                .ToList();


            StringBuilder sb = new StringBuilder();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.Department.Name} - ${employee.Salary:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            //First solution
            /*var address = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4,
            };

            context.Addresses.Add(address);
            context.SaveChanges();

            var requiredEmployee = context.Employees
                .FirstOrDefault(x => x.LastName == "Nakov");

            requiredEmployee.AddressId = address.AddressId;
            context.SaveChanges();*/

            //Second solution

            var requiredEmployee = context.Employees
                .FirstOrDefault(x => x.LastName == "Nakov");

            requiredEmployee.Address = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4,
            };

            context.SaveChanges();

            var addresses = context.Employees
                .Select(x => new
                {
                    x.AddressId,
                    x.Address.AddressText,
                })
                .OrderByDescending(x => x.AddressId)
                .Take(10)
                .ToList();

            StringBuilder sb = new StringBuilder();

            foreach (var address in addresses)
            {
                sb.AppendLine(address.AddressText);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
