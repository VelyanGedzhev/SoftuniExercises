using System;
using System.Linq;

namespace _1._EncryptSortAndPrintArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            int[] numbers = new int[count];
            string vowels = "aAeEiIoOuU";
            char[] vowelsArray = vowels.ToCharArray();
            

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                int sum = 0;

                for (int j = 0; j < input.Length; j++)
                {
                    if (vowelsArray.Contains(input[j]))
                    {
                        sum += input[j] * input.Length;
                    }
                    else
                    {
                        sum += input[j] / input.Length;
                    }
                }
                numbers[i] = sum;
            }
            Array.Sort(numbers);
            foreach (var item in numbers)
            {
                Console.WriteLine(item);
            }
        }
    }
}
