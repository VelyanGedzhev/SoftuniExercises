using System;
using System.Linq;
using System.Collections.Generic;

namespace _1.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] input2 = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int n = input[0];
            int s = input[1];
            int x = input[2];
            int min = int.MaxValue;

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < input2.Length; i++)
            {
                stack.Push(input2[i]);
            }
            

            for (int i = 0; i < s; i++)
            {
                stack.Pop();
            }

            if (stack.Count < 1)
            {
                Console.WriteLine(0);
            }
            else
            {
                foreach (var num in stack)
                {
                    if (num == x)
                    {
                        Console.WriteLine("true");
                        return;
                    }
                    else
                    {
                        if (num < min)
                        {
                            min = num;
                        }
                    }
                }
                Console.WriteLine(min);
            }
        }
    }
}
