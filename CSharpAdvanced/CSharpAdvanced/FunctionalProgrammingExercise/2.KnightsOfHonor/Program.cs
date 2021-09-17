using System;
using System.Linq;

namespace _2.KnightsOfHonor
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string> print = message => Console.WriteLine($"Sir {message}");

            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            foreach (var knight in input)
            {
                print(knight);
            }

        }
    }
}
