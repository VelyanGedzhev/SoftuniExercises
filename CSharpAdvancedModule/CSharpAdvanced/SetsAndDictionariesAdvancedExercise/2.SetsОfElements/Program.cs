using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.SetsОfElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            HashSet<int> N = new HashSet<int>();
            HashSet<int> M = new HashSet<int>();

            for (int i = 0; i < input[0]; i++)
            {
                N.Add(int.Parse(Console.ReadLine()));
            }
            for (int i = 0; i < input[1]; i++)
            {
                M.Add(int.Parse(Console.ReadLine()));
            }
            var C = N.Intersect(M);
            Console.WriteLine(string.Join(" ", C));
        }
    }
}
