using System;
using System.Collections.Generic;

namespace _5._Students
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string input = Console.ReadLine();
            List<Student> students = new List<Student>();

            while (input != "end")
            {
                string[] data = input.Split();
                Student student = new Student(data);
                students.Add(student);

                input = Console.ReadLine();
            }

            string town = Console.ReadLine();

            foreach (Student student in students)
            {
                if (student.HomeTown == town)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName} is " +
                        $"{student.Age} years old.");
                }
            }
        }
    }
    public class Student
    {
        public Student(string[] data)
        {
            FirstName = data[0];
            LastName = data[1];
            Age = int.Parse(data[2]);
            HomeTown = data[3];
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }
    }
    
}
