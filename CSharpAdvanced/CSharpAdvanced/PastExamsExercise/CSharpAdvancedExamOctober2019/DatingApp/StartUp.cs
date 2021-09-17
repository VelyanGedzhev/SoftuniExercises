﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace DatingApp
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Stack<int> males = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> females = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            int matches = 0;

            while (males.Count > 0 && females.Count > 0)
            {
                if (males.Peek() <= 0)
                {
                    males.Pop();
                    continue;
                }
                if (females.Peek() <= 0)
                {
                    females.Dequeue();
                    continue;
                }
                if (males.Peek() % 25 == 0 && males.Peek() != 0)
                {
                    males.Pop();
                    if (males.Count > 0)
                    {
                        males.Pop();
                    }
                    continue;
                }
                if (females.Peek() % 25 == 0 && females.Peek() != 0)
                {
                    females.Dequeue();
                    if (females.Count > 0)
                    {
                        females.Dequeue();
                    }
                    continue;
                }
                if (males.Count > 0 && females.Count > 0)
                {
                    if (females.Peek() == males.Peek())
                    {
                        matches++;
                        females.Dequeue();
                        males.Pop();
                        continue;
                    }
                    else
                    {
                        females.Dequeue();
                        males.Push(males.Pop() - 2);
                        continue;
                    }
                }
                
            }
            Console.WriteLine($"Matches: {matches}");
            if (males.Count == 0)
            {
                Console.WriteLine("Males left: none");
            }
            else
            {
                Console.WriteLine($"Males left: {string.Join(", ", males)}");
            }
            if (females.Count == 0)
            {
                Console.WriteLine("Females left: none");
            }
            else
            {
                Console.WriteLine($"Females left: {string.Join(", ", females)}");
            }
        }
    }
}
