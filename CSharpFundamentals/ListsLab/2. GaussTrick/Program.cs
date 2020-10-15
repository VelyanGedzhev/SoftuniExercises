using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._GaussTrick
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = ReadNumbersInLine();
            Console.WriteLine(String.Join(" ",GaussTrickSum(numbers)));
        }
        static List<int> ReadNumbersInLine()
        {
            List<int> numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            return numbers;
        }
        static List<int> GaussTrickSum(List<int> numbers)
        {
            List<int> result = new List<int>();

            for (int i = 0; i < numbers.Count / 2; i++)
            {
                result.Add(numbers[i] + numbers[numbers.Count - i - 1]);
            }
            if(numbers.Count % 2 != 0)
            {
                result.Add(numbers[numbers.Count / 2]);
            }

            return result;
        }
    }
}
