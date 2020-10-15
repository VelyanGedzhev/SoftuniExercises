using System;

namespace _8._FactorialDivision
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNum = int.Parse(Console.ReadLine());
            int secondNum = int.Parse(Console.ReadLine());

            Console.WriteLine($"{FactorialDivision(firstNum,secondNum):f2}");
        }
        static double GetFirstFactorial(int num)
        {
            double firstFactorial = num;

            for (int i = 1; i < num; i++)
            {
                firstFactorial *= i;
            }
            return firstFactorial;
        }
        static double GetSecondFactorial(int num)
        {
            double secondFactorial = num;

            for (int i = 1; i < num; i++)
            {
                secondFactorial *= i;
            }
            return secondFactorial;
        }
        static double FactorialDivision(int a, int b)
        {
            double result = GetFirstFactorial(a) * 1.0 / GetSecondFactorial(b);
            return result;
        }
    }
}
