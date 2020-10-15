using System;

namespace _2._SumDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            int currentNum = number;
            int sum = 0;

            while (currentNum != 0)
            {
                int currentDigit = currentNum % 10;
                sum += currentDigit;
                currentNum /= 10;
            }
            Console.WriteLine(sum);
        }
    }
}
