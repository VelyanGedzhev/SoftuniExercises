using System;

namespace _10._MultiplyEvenByOdds
{
    class Program
    {
        static void Main(string[] args)
        {
            int input = int.Parse(Console.ReadLine());
            input = Math.Abs(input);
            Console.WriteLine(MultplyEvenAndOddDigits(input));
        }
        static int CalculateOddDigitsSum(int number)
        {
            int currentNumber = number;
            int oddSum = 0;
            while (currentNumber != 0)
            {
                int currentDigit = currentNumber % 10;
                currentNumber /= 10;
                if (currentDigit % 2 != 0)
                {
                    oddSum += currentDigit;
                }
            }

            return oddSum;
        }
        static int CalculateEvenDigitsSum(int number)
        {
            int currentNumber = number;
            int evenSum = 0;
            
            while (currentNumber != 0)
            {
                int currentDigit = currentNumber % 10;
                currentNumber /= 10;
                if(currentDigit % 2 == 0)
                {
                    evenSum += currentDigit;
                }
            }

            return evenSum;
        }
        static int MultplyEvenAndOddDigits(int sum)
        {
            
            return CalculateOddDigitsSum(sum) * CalculateEvenDigitsSum(sum);
        }
    }
}
