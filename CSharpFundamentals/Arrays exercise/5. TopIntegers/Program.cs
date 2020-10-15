using System;
using System.Linq;

namespace _5._TopIntegers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            string result = string.Empty;

            for (int i = 0; i < numbers.Length - 1; i++)
            {
                bool isBigger = true;
                for (int j = i + 1; j < numbers.Length; j++)
                {
                    if (numbers[i] <= numbers[j])
                    {
                        isBigger = false;
                        break;
                    }
                }
                if (isBigger)
                {
                    result += numbers[i] + " ";
                }
            }
            Console.WriteLine(result + numbers[numbers.Length - 1]);
        }
    }
}
