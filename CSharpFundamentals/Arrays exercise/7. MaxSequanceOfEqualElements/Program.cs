using System;
using System.Linq;

namespace _7._MaxSequanceOfEqualElements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int maxLenght = 0;
            int tempLenght = 1;
            int start = 0;
            int bestStart = 0;

            for (int i = 1; i < input.Length; i++)
            {
                if(input[i] == input[i - 1])
                {
                    tempLenght++;
                }
                else
                {
                    tempLenght = 1;
                    start = i;
                }

                if(tempLenght > maxLenght)
                {
                    maxLenght = tempLenght;
                    bestStart = start;
                }
            }
            for (int i = bestStart; i < bestStart + maxLenght; i++)
            {
                Console.Write(input[i] + " ");
            }
        }
    }
}
