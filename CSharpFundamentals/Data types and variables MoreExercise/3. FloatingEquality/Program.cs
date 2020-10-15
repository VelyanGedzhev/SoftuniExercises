using System;

namespace _3._FloatingEquality
{
    class Program
    {
        static void Main(string[] args)
        {
            double eps = 0.000001;
            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());

            if(secondNumber-firstNumber >= eps || firstNumber-secondNumber >= eps)
            {
                Console.WriteLine("False");
            }
            else
            {
                Console.WriteLine("True");
            }
        }
    }
}
