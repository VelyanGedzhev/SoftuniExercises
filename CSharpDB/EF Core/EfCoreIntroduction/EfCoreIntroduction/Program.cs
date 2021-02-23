using EfCoreIntroduction.Model;
using System;
using System.Linq;

namespace EfCoreIntroduction
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new SoftUniContext();
            //GetTopPaidEmployees(db);  
            

        }

        private static void GetTopPaidEmployees(SoftUniContext db)
        {
            var topPaidEmployees = db.Employees
                            .OrderByDescending(x => x.Salary)
                            .Take(10)
                            .ToList();

            foreach (var employee in topPaidEmployees)
            {
                Console.WriteLine($"{employee.FirstName} {employee.LastName} -- {employee.Salary}");
            }
        }
    }
}
