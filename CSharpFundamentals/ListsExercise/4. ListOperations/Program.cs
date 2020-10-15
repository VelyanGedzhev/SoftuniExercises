using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._ListOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = ReadSingleLineIntegers();
            string input = Console.ReadLine();

            while (input != "End")
            {
                List<string> command = input.Split().ToList();
                
                if (command[0] == "Add")
                {
                    int number = int.Parse(command[1]);
                    numbers.Add(number);
                }
                else if (command[0] == "Insert")
                {
                    int number = int.Parse(command[1]);
                    int index = int.Parse(command[2]);

                    if (index >= numbers.Count || index < 0)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.Insert(index, number);
                    }
                }
                else if (command[0] == "Remove")
                {
                    int index = int.Parse(command[1]);

                    if (index >= numbers.Count || index < 0)
                    {
                        Console.WriteLine("Invalid index");
                    }
                    else
                    {
                        numbers.RemoveAt(index);
                    }
                }
                else if (command[0] == "Shift" && command[1] == "left")
                {
                    int count = int.Parse(command[2]);

                    for (int i = 0; i < count; i++)
                    {
                        int firstIndex = numbers[0];
                        numbers.Add(firstIndex);
                        numbers.RemoveAt(0);
                        
                    }

                }
                else if (command[0] == "Shift" && command[1] == "right")
                {
                    int count = int.Parse(command[2]);

                    for (int i = 0; i < count; i++)
                    {
                        int lastIndex = numbers[numbers.Count - 1];
                        numbers.Insert(0, lastIndex);
                        numbers.RemoveAt(numbers.Count - 1);
                        
                    }
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(String.Join(" ", numbers));
           
        }
        static List<int> ReadSingleLineIntegers()
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            return numbers;
        }
    }
}
