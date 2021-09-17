using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.FashionBoutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Reverse()
                .ToArray();
            int rackCapacity = int.Parse(Console.ReadLine());
            Stack<int> clothes = new Stack<int>(input);
            int sum = 0;
            int racksCount = 1;

            while(clothes.Count > 0)
            {
                if (sum + clothes.Peek() <= rackCapacity)
                {
                    sum += clothes.Pop();
                }
                else
                {
                    racksCount++;
                    sum = 0;
                }
            }
            Console.WriteLine(racksCount);
        }
    }
}
