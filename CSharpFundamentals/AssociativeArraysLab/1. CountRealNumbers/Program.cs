﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._CountRealNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] input = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            SortedDictionary<double, int> numbers = new SortedDictionary<double, int>();

            foreach (double number in input)
            {
                if (numbers.ContainsKey(number))
                {
                    numbers[number]++;
                }
                else
                {
                    numbers.Add(number, 1);
                }
            }
            foreach (var row in numbers)
            {
                Console.WriteLine($"{row.Key} -> {row.Value}");
            }

        }
    }
}
