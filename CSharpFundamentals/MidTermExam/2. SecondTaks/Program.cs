using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._SecondTaks
{
    class Program
    {
        static void Main(string[] args)
        {
            List<long> numbers = Console.ReadLine()
                .Split()
                .Select(long.Parse)
                .ToList();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "end")
            {
                string[] command = input
                    .Split()
                    .ToArray();

                if (command[0] == "swap")
                {
                    int firstIndex = int.Parse(command[1]);
                    int secondIndex = int.Parse(command[2]);

                    SwapElements(numbers, firstIndex, secondIndex);
                }
                else if (command[0] == "multiply")
                {
                    int firstIndex = int.Parse(command[1]);
                    int secondIndex = int.Parse(command[2]);

                    MiltiplyElements(numbers, firstIndex, secondIndex);
                }
                else if (command[0] == "decrease")
                {
                    DecreaseElements(numbers);
                }
            }
            Console.WriteLine(String.Join(", ", numbers));
        }
        public static void SwapElements(List<long> list, int firstIndex, int secondIndex)
        {
            long firstElement = list[firstIndex];
            long secondElement = list[secondIndex];

            list.Insert(firstIndex, secondElement);
            list.RemoveAt(firstIndex + 1);
            list.Insert(secondIndex, firstElement);
            list.RemoveAt(secondIndex + 1);
            
        }
        public static void MiltiplyElements(List<long> list, int firstIndex, int secondIndex)
        {
            long firstElement = list[firstIndex];
            long secondElement = list[secondIndex];
            long result = firstElement * secondElement;

            list.Insert(firstIndex, result);
            list.RemoveAt(firstIndex + 1);
            
        }
        public static void DecreaseElements (List<long> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                list[i] -= 1;
            }
        }
    }
}
