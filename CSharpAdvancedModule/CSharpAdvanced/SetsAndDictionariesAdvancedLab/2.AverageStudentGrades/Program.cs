using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _2.AverageStudentGrades
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> grades = new Dictionary<string, List<decimal>>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string name = input[0];
                decimal grade = decimal.Parse(input[1]);

                if (!grades.ContainsKey(name))
                {
                    grades.Add(name, new List<decimal>());
                }
                grades[name].Add(grade);
            }
            foreach (var item in grades)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < item.Value.Count; i++)
                {
                    sb.Append($"{item.Value[i]:f2} ");
                }

                Console.WriteLine($"{item.Key} -> {sb.ToString()}(avg: {item.Value.Average():f2})");
            }
        }
    }
}
