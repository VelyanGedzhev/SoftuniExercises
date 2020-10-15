using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._MovingTarget
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input
                    .Split()
                    .ToArray();

                int index = int.Parse(command[1]);
                int value = int.Parse(command[2]);

                if (command[0] == "Shoot")
                {
                    ShootTarget(sequence, index, value);
                }
                else if (command[0] == "Add")
                {
                    AddTaget(sequence, index, value);
                }
                else if (command[0] == "Strike")
                {
                    StrikeTarget(sequence, index, value);
                }
            }
            Console.WriteLine(String.Join("|", sequence));
        }
        public static void ShootTarget(List<int> sequence, int index, int power)
        {
            List<int> list = sequence;

            if (index >= 0 && index <= list.Count - 1)
            {
                list[index] -= power;

                if (list[index] <= 0)
                {
                    list.RemoveAt(index);
                }
            }
            
        }
        public static void AddTaget(List<int> sequence, int index, int value)
        {
            List<int> list = sequence;

            if (index >= 0 && index <= list.Count - 1)
            {
                list.Insert(index, value);
            }
            else
            {
                Console.WriteLine("Invalid placement!");
            }
        }
        public static void StrikeTarget(List<int> sequence, int index, int radius)
        {
            List<int> list = sequence;

            if (index >= 0 && index <= list.Count - 1)
            {
                if (index + radius <= list.Count -1 && index - radius >= 0)
                {
                    list.RemoveRange(index - radius, radius * 2 + 1);
                }
                else
                {
                    Console.WriteLine("Strike missed!");
                }
            }
        }
    }
}
