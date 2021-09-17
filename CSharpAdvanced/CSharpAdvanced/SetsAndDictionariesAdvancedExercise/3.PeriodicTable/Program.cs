using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.PeriodicTable
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> chemicalElements = new HashSet<string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split();

                foreach (var item in input)
                {
                    chemicalElements.Add(item);
                }
            }
            //foreach (var item in chemicalElements.OrderBy(x => x))
            //{
            //    Console.Write(item + " ");
            //}
            var sorted = chemicalElements.OrderBy(x => x).ToHashSet();
            Console.WriteLine(string.Join(" ", sorted));
        }
    }
}
