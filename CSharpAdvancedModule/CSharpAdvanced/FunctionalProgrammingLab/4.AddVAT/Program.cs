using System;
using System.Linq;

namespace _4.AddVAT
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(decimal.Parse)
                .Select(x => x * 1.2m)
                .ToArray();

            foreach (var num in numbers)
            {
                Console.WriteLine($"{num:f2}");
            }
        }
    }
}
