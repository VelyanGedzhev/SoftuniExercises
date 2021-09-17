using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.CountSameValuesInArray
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> times = new Dictionary<double, int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (!times.ContainsKey(input[i]))
                {
                    times.Add(input[i],0);
                }
                times[input[i]]++;
            }
            foreach (var item in times)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
