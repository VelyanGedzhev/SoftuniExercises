using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Train
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> train = ReadSingleLineIntegers();
            int maxCapacity = int.Parse(Console.ReadLine());
            string input = Console.ReadLine();

            while(input != "end")
            {
                List<string> command = input.Split().ToList();

                if(command[0] == "Add")
                {
                    train.Add(int.Parse(command[1]));
                }
                else
                {
                    for (int i = 0; i < train.Count; i++)
                    {
                        int currentPassengers = int.Parse(command[0]);

                        if (train[i] + currentPassengers <= maxCapacity)
                        {
                            train[i] += currentPassengers;
                            break;
                        }
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(String.Join(" ", train));

        }
        static List<int> ReadSingleLineIntegers()
        {
            List<int> input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            return input;
        }
    }
}
