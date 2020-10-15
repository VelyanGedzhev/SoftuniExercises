using System;
using System.Linq;

namespace _4._Largest3Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int[] sortedNumbers = numbers
                .OrderByDescending(x => x)
                .ToArray();

            if (sortedNumbers.Length > 3)
            {
                Console.WriteLine($"{sortedNumbers[0]} {sortedNumbers[1]} {sortedNumbers[2]}");
            }
            else
            {
                Console.WriteLine(string.Join(" ", sortedNumbers));     
            }
        }
    }
}
