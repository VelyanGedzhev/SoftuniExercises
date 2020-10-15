using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._ThirdTaksV2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine()
               .Split()
               .Select(int.Parse)
               .ToList();

            double averageValue = sequence.Sum() * 1.0 / sequence.Count;


        }
    }
}
