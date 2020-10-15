using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Students
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            List<Student> students = new List<Student>();

            for (int i = 0; i < studentsCount; i++)
            {
                string[] data = Console.ReadLine()
                    .Split()
                    .ToArray();
                Student student = new Student(data);
                students.Add(student);
            }
            List<Student> sortedList = students.OrderByDescending(x => x.Grade).ToList();
            Console.WriteLine(String.Join(System.Environment.NewLine, sortedList));
        }
    }
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double Grade { get; set; }

        public Student(string[] data)
        {
            FirstName = data[0];
            LastName = data[1];
            Grade = double.Parse(data[2]);
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}: {Grade:f2}";     
        }
    }
}
