using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.FindEvensOrOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int start = range[0];
            int end = range[1];
            string condition = Console.ReadLine();

            Func<int, int, List<int>> generateList = (start, end) =>
            {
                List<int> nums = new List<int>();

                for (int i = start; i <= end; i++)
                {
                    nums.Add(i);
                }
                return nums;
            };
            List<int> numbers = generateList(start, end);

            Predicate<int> predicate = n => n % 2 == 0;

            if (condition == "odd")
            {
                predicate = n => n % 2 != 0;
            }

            numbers = MyWhere(numbers, predicate);
            Console.WriteLine(string.Join(" ", numbers));
        }
        static List<int> MyWhere(List<int> numbers, Predicate<int> predicate)
        {
            List<int> result = new List<int>();

            foreach (int item in numbers)
            {
                if (predicate(item))
                {
                    result.Add(item);
                }
                
            }

            return result;
        }
    }
}
