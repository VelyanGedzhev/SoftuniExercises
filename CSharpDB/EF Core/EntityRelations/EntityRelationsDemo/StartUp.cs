using FluentApiDemo.Models;
using System;

namespace FluentApiDemo
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var db = new ApplicationDbContext();

            //This is just to safe time for the demo
            //The right way -> use migrations!
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();

            var department = new Department { Name = "HR" };

            for (int i = 0; i < 10; i++)
            {
                db.Employees.Add(new Employee
                {
                    FirstName = "Velyan",
                    LastName = "Gedzhev",
                    StartWorkDate = new DateTime(2010 + i, 1, 1),
                    Salary = 1000 + i,
                    Department = department,
                });
            }

            db.SaveChanges();
        }
    }
}
