using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._StudentAcademy
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Dictionary<string, List<double>> students = new Dictionary<string, List<double>>();

            for (int i = 0; i < count; i++)
            {
                string name = Console.ReadLine();
                double grade = double.Parse(Console.ReadLine());

                if (students.ContainsKey(name))
                {
                    students[name].Add(grade);
                }
                else
                {
                    students.Add(name, new List<double>());
                    students[name].Add(grade);
                }
            }
            Dictionary<string, double> sortedStudent = new Dictionary<string, double>();

            foreach (var student in students)
            {
                if (student.Value.Average() >= 4.5)
                {
                    sortedStudent.Add(student.Key, student.Value.Average());
                }
            }

            foreach (var student in sortedStudent.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{student.Key} -> {student.Value:f2}");
            }
        }
    }
}
