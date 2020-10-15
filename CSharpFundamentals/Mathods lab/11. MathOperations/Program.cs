using System;

namespace _11._MathOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            string @operator = Console.ReadLine();
            int b = int.Parse(Console.ReadLine());

            Console.WriteLine(CalculationResult(a, @operator, b));
        }
        static double CalculationResult(int firstNumber, string @operator, int secondNumber)
        {
            double result = 0;
            switch (@operator)
            {
                case "/":
                    result =  firstNumber / secondNumber;
                    break;
                case "*":
                    result = firstNumber * secondNumber;
                    break;
                case "+":
                    result = firstNumber + secondNumber;
                    break;
                case "-":
                    result = firstNumber - secondNumber;
                    break;    
            }
            return result;
        }
    }
}
