using System;
using System.Collections.Generic;
using System.Text;

namespace FluentApiDemo.Models
{
    public class Employee
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public DateTime? StartWorkDate { get; set; }

        public decimal Salary { get; set; }

        //Optional
        public int DepartmentId { get; set; }

        //Required
        public Department Department { get; set; }
    }
}
