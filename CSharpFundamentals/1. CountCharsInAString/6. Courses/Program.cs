using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Courses
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = string.Empty;
            Dictionary<string, List<string>> courses = new Dictionary<string, List<string>>();
           
            while ((input = Console.ReadLine()) != "end")
            {
                string[] command = input
                    .Split(" : ")
                    .ToArray();

                string courseName = command[0];
                string name = command[1];

                if (courses.ContainsKey(courseName))
                {
                    courses[courseName].Add(name);
                }
                else
                {
                    courses.Add(courseName, new List<string>());
                    courses[courseName].Add( name);
                }
            }
            //Dictionary<string, List<string>> sortedCourses = courses
            //    .OrderByDescending(x => x.Value.Count)
            //    .ThenByDescending(x => x.Key)
            //    .ToDictionary(a => a.Key, a => a.Value);

            //foreach (var item in sortedCourses)
            //{
            //    Console.WriteLine($"{item.Key}: {item.Value.Count}");
            //    //Console.WriteLine(String.Join(Environment.NewLine, item.Value));
            //    foreach (var course in item.Value.OrderBy(x => x))
            //    {
            //        Console.WriteLine($"-- {course}");
            //    }
            //}
            foreach (var kvp in courses.OrderByDescending(x => x.Value.Count))
            {
                Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value.Count);
                foreach (var item in kvp.Value.OrderBy(x => x))
                {
                    Console.WriteLine("-- {0}", item);
                }
            } // end foreach for rezult
        }
    }
}
