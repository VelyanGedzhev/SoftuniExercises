using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._ListManipulationBasics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = ReadNumbersInSingleLine();
            string input = Console.ReadLine();
            int number = 0;
            int index = 0;

            while (input != "end")
            {
                List<string> command = input.Split().ToList();

                if (command[0] == "Add")
                {
                    number = int.Parse(command[1]);
                    AddNumber(numbers, number);
                }
                else if (command[0] == "Remove")
                {
                    number = int.Parse(command[1]);
                    RemoveNumber(numbers, number);
                }
                else if (command[0] == "RemoveAt")
                {
                    index = int.Parse(command[1]);
                    RemoveFromIndex(numbers, index);

                }
                else if (command[0] == "Insert")
                {
                    number = int.Parse(command[1]);
                    index = int.Parse(command[2]);
                    InsertNumberAtIndex(numbers, number, index);
                }
                input = Console.ReadLine();
                if (input == "end")
                {
                    Console.WriteLine(String.Join(" ", numbers));
                    return;
                }
            }
            static List<int> ReadNumbersInSingleLine()
            {
                List<int> input = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToList();

                return input;
            }
            static List<int> AddNumber(List<int> numbers, int number)
            {
                numbers.Add(number);
                return numbers;
            }
            static List<int> RemoveNumber (List<int> numbers, int number)
            {
                numbers.Remove(number);
                return numbers;
            }
            static List<int> RemoveFromIndex(List<int> numbers, int index)
            {
                numbers.RemoveAt(index);
                return numbers;
            }
            static List<int> InsertNumberAtIndex (List<int> numbers, int number, int index)
            {
                numbers.Insert(index, number);
                return numbers;
            }
        }
    }
}
