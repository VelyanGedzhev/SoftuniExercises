using System;
using System.Linq;
using System.Collections.Generic;

namespace _3.MaximumAndMinimumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                int command = input[0];
                switch (command)
                {
                    case 1:
                        stack.Push(input[1]);
                        break;
                    case 2:
                        if (stack.Count > 0)
                        {
                            stack.Pop();
                        }
                        break;
                    case 3:
                        if (stack.Count > 0)
                        {
                            Console.WriteLine(stack.Max());
                        }
                        break;
                    case 4:
                        if (stack.Count > 0 )
                        {
                            Console.WriteLine(stack.Min());
                        }
                        break;
                    default:
                        break;
                }
            }
            if (stack.Count > 0)
            {
                Console.WriteLine(String.Join(", ", stack));
            }
        }
    }
}
