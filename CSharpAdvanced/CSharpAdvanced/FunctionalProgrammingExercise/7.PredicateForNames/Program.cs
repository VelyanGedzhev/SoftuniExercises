using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            int lenght = int.Parse(Console.ReadLine());

            List<string> names = Console.ReadLine()
                .Split()
                .ToList();

            names = names.Where(x => x.Length <= lenght).ToList();

            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
