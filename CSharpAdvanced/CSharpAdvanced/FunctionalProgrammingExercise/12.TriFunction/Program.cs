using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine()
                .Split()
                .ToList();
            Func<string, int> getAsciiSum = p => p.Select(c => (int)c).Sum();
            //string person = GetName(names, n, getAsciiSum);
            //Console.WriteLine(person);

            Func<List<string>, int, Func<string, int>, string> nameFunc = (names, n, func) => names.FirstOrDefault(p => func(p) >= n);

            string result = nameFunc(names, n, getAsciiSum);
            Console.WriteLine(result);
        }
        static string GetName(List<string> people, int n, Func<string, int> func)
        {
            string result = null;
            foreach (string person in people)
            {
                if (func(person) >= n)
                {
                    result = person;
                }
            }
            return result;
        }
    }
}
