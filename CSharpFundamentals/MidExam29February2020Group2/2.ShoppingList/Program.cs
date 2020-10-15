using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.ShoppingList
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> groceries = Console.ReadLine()
                .Split("!")
                .ToList();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "Go Shopping!")
            {
                string[] command = input
                    .Split()
                    .ToArray();

                if (command[0] == "Urgent")
                {
                    UrgentItem(groceries, command[1]);
                }
                else if (command[0] == "Unnecessary")
                {
                    UnnecessaryItem(groceries, command[1]);
                }
                else if (command[0] == "Correct")
                {
                    CorrectList(groceries, command[1], command[2]);
                }
                else if (command[0] == "Rearrange")
                {
                    RearrangeList(groceries, command[1]);
                }
            }
            Console.WriteLine(string.Join(", ", groceries));
        }
        public static void UrgentItem(List<string> list, string item)
        {
            if (!list.Contains(item))
            {
                list.Insert(0, item);
            }
        } 
        public static void UnnecessaryItem(List<string> list, string item)
        {
            if (list.Contains(item))
            {
                list.Remove(item);
            }
        }
        public static void CorrectList(List<string> list, string oldItem, string newItem)
        {
            if (list.Contains(oldItem))
            {
                int index = list.IndexOf(oldItem);
                list.RemoveAt(index);
                list.Insert(index, newItem);
            }
        }
        public static void RearrangeList(List<string> list, string item)
        {
            if (list.Contains(item))
            {
                list.Remove(item);
                list.Add(item);
            }
        }
    }
}
