using System;
using System.Linq;

namespace _2._CharacherMultipier
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split()
                .ToArray();

            string firstStr = input[0];
            string secondStr = input[1];
            int maxLenght = Math.Min(firstStr.Length, secondStr.Length);
            int sum = 0;

            for (int i = 0; i < maxLenght; i++)
            {
                sum += (int)firstStr[i] * (int)secondStr[i];
            }
            if (firstStr.Length > maxLenght)
            {
                for (int i =  maxLenght; i < firstStr.Length; i++)
                {
                    sum += (int)firstStr[i];
                }
            }
            else if (secondStr.Length > maxLenght)
            {
                for (int i = maxLenght; i < secondStr.Length; i++)
                {
                    sum += (int)secondStr[i];
                }
            }
            Console.WriteLine(sum);
        }
    }
}
