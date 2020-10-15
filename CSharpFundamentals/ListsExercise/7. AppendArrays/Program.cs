using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._AppendArrays
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = Console.ReadLine()
                .Split('|')
                .Reverse()
                .ToList();

            List<int> result = new List<int>();

            foreach (var item in input)
            {
                result.AddRange(item.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToList());
                
            }
            Console.WriteLine(String.Join(" ", result));
        }
    }
}
