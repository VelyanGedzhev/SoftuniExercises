using System;
using System.Collections.Generic;
using System.Linq;

namespace _9.ListOfPredicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] dividers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Func<int, List<int>> listGenerator = (n) =>
            {
                List<int> numbers = new List<int>();

                for (int i = 1; i <= n; i++)
                {
                    numbers.Add(i);
                }
                return numbers;
            };
            List<int> numbers = listGenerator(n);
            Func<int[], List<int>, List<int>> checker = (x, y) =>
            {
                List<int> result = new List<int>();

                foreach (var num in numbers)
                {
                    bool isDividable = true;

                    foreach (var divider in dividers)
                    {
                        if (num % divider != 0)
                        {
                            isDividable = false;
                        }
                    }
                    if (isDividable)
                    {
                        result.Add(num);
                    }
                }
                return result;
            };
            List<int> result = checker(dividers,numbers);
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
