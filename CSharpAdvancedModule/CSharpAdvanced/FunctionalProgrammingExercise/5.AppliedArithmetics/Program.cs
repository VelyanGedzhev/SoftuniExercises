using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            Func<int, int> add = x => x + 1;
            Func<int, int> multiply = x => x * 2;
            Func<int, int> subtract = x => x - 1;
           
            string command = Console.ReadLine();

            while (command != "end")
            {
                
                switch (command)
                {
                    case "add":
                        numbers = numbers.Select(add).ToList();
                        break;
                    case "multiply":
                        numbers = numbers.Select(multiply).ToList();
                        break;
                    case "subtract":
                        numbers = numbers.Select(subtract).ToList();
                        break;
                    case "print":
                        Console.WriteLine(string.Join(" ", numbers));
                        break;
                    default:
                        break;
                }
                
                command = Console.ReadLine();
            }
            
        }
    }
}
