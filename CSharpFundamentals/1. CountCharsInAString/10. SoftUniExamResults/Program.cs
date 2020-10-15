using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._SoftUniExamResults
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            Dictionary<string, Student> students = new Dictionary<string, Student>();

            while ((command = Console.ReadLine()) != "exam finished")
            {

            }
        }
        public class Student
        {
            public string Username { get; set; }
            public string Points { get; set; }
            public int Sumbisions { get; set; }

            public Student(string name, string result)
            {
                this.Username = name;
                this.Points = result;
                this.Sumbisions = 0;
            }
        }
    }
}
