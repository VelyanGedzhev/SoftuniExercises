using System;
using System.Linq;
using System.Runtime.CompilerServices;

namespace _3._RoundingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            //double[] numbers = Console.ReadLine()
            //    .Split()
            //    .Select(double.Parse)
            //    .ToArray();

            //for (int i = 0; i < numbers.Length; i++)
            //{
            //    int currentNum = (int)Math.Round(numbers[i]);
            //    Console.WriteLine($"{numbers[i]} => {currentNum}");
            //}

            double[] numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == 0)
                {
                    numbers[i] = 0;
                }
                Console.WriteLine($"{numbers[i]} => {(int)Math.Round(numbers[i], MidpointRounding.AwayFromZero)}");
            }
        }
    }
}
