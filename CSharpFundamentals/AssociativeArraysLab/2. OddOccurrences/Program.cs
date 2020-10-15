using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._OddOccurrences
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split()
                .ToArray();

            Dictionary<string, int> counts = new Dictionary<string, int>();

            foreach (string word in input)
            {
                string wordToLowerCase = word.ToLower();

                if (counts.ContainsKey(wordToLowerCase))
                {
                    counts[wordToLowerCase]++;
                }
                else
                {
                    counts.Add(wordToLowerCase, 1);
                }
            }
            foreach (var count in counts)
            {
                if (count.Value % 2 != 0)
                {
                    Console.Write(count.Key + " ");
                }
            }
        }
    }
}
