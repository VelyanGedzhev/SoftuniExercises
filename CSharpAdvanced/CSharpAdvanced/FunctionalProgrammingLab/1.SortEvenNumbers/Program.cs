using System;
using System.Linq;

namespace _1.SortEvenNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select((number) =>
                {
                    return int.Parse(number);
                })
                .Where(x => x % 2 == 0)
                .OrderBy(x => x)
                .ToArray();
            Console.WriteLine(string.Join(", ", numbers));
        }
    }
}
