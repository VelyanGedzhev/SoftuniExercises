using System;
using System.Collections.Generic;
using System.Linq;


namespace _2.BasicQueueOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>();

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

            for (int i = 0; i < input2.Length; i++)
            {
                queue.Enqueue(input2[i]);
            }

            for (int i = 0; i < s; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count < 1)
            {
                Console.WriteLine(0);
            }
            else
            {
                foreach (var num in queue)
                {
                    if (num == x)
                    {
                        Console.WriteLine("true");
                        return;
                    }
                    else if (num < min)
                    {
                        min = num;
                    }
                }
                Console.WriteLine(min);
            }
        }
    }
}
