using System;
using System.Linq;

namespace _3.CountUppercaseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(s => s[0] == s.ToUpper()[0])
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, input));
        }
    }
}
