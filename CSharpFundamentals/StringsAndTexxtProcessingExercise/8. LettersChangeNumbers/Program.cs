using System;
using System.Linq;

namespace _8._LettersChangeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            double sum = 0;
            
            foreach (string item in input)
            {
                double number = double.Parse(item.Substring(1,item.Length -2));
                string letterBefore = item.Substring(0, 1);
                string letterAfter = item.Substring(item.Length - 1, 1);
                

                if (letterBefore.ToLower() != letterBefore)
                {
                    number /= (int)char.Parse(letterBefore.ToUpper()) - 64;
                }
                else
                {
                    number *= char.Parse(letterBefore.ToUpper()) - 64;
                }

                if (letterAfter.ToLower() != letterAfter)
                {
                    number -= (int)char.Parse(letterAfter.ToUpper()) - 64;
                }
                else
                {
                    number += (int)(char.Parse(letterAfter.ToUpper()) - 64);
                }

                sum += number;
            }
            Console.WriteLine($"{sum:f2}");
        }
    }
}
