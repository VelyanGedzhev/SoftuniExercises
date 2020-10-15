using System;
using System.Linq;

namespace _5._WordsFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split()
                .Where(word => word.Length % 2 == 0)
                .ToArray();

            Console.WriteLine(String.Join(Environment.NewLine, input));
        }
    }
}
