using System;
using System.Collections.Generic;
using System.Text;

namespace AttributesDemo.Models
{
    public class Department
    {
        public Department()
        {
            Employees = new HashSet<Employee>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        //Optional
        public ICollection<Employee> Employees { get; set; }
    }
}
