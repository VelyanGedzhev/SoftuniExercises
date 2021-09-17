using System;
using System.Linq;

namespace _2.SumNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(ParseNumber)
                .ToArray();

            PrintResult(array, NumCount, NumSum);
        }
        static int NumCount(int[] array)
        {
            return array.Length;
        }
        static int NumSum (int[] array)
        {
            return array.Sum();
        }
        static void PrintResult(int[] array, Func<int[], int> count, Func<int[], int> sum)
        {
            Console.WriteLine(count(array));
            Console.WriteLine(sum(array));
        }
        static int ParseNumber (string num)
        {
            return int.Parse(num);
        }
    }
}
