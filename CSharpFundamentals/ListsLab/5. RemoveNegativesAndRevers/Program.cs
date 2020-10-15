using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._RemoveNegativesAndRevers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = ReadNumbersInSingleLine();
            RemoveNegativesAndReverse(numbers);
        }
        static List<int> ReadNumbersInSingleLine()
        {
            List<int> list = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            return list;
        }
        static void RemoveNegativesAndReverse(List<int> numbers)
        {
            for (int i = 0; i < numbers.Count; i++)
            {

                if(numbers[i] < 0)
                {
                    numbers.RemoveAt(i--);
                }
            }
            if(numbers.Count == 0)
            {
                Console.WriteLine("empty");
                return;
            }
            numbers.Reverse();
            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}
