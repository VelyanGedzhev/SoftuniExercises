using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Inventory
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> items = Console.ReadLine()
                .Split(", ")
                .ToList();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Craft!")
            {
                string[] command = input
                    .Split(" - ")
                    .ToArray();

                string item = command[1];

                if (command[0] == "Collect")
                {
                    if (items.Contains(item))
                    {
                        continue;
                    }
                    else
                    {
                        items.Add(item);
                    }
                }
                else if (command[0] == "Drop")
                {
                    if (items.Contains(item))
                    {
                        items.Remove(item);
                    }
                }
                else if (command[0] == "Combine Items")
                {
                    string[] combine = item
                        .Split(":")
                        .ToArray();

                    if (items.Contains(combine[0]))
                    {
                        int index = items.IndexOf(combine[0]);
                        items.Insert(index + 1, combine[1]);
                    }
                }
                else if (command[0] == "Renew")
                {
                    if (items.Contains(command[1]))
                    {
                        int index = items.IndexOf(command[1]);
                        items.RemoveAt(index);
                        items.Add(command[1]);

                    }
                }
            }
            Console.WriteLine(String.Join(", ", items));
        }
    }
}
