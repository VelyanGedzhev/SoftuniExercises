using System;

namespace _5._MultiplicationSign
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ReturnProductSign(
                int.Parse(Console.ReadLine()),
                int.Parse(Console.ReadLine()),
                int.Parse(Console.ReadLine())
                ));
        }
        static string ReturnProductSign(int a, int b, int c)
        {
            string sign = "positive";

            if((a > 0 && b > 0 && c > 0) || (a < 0 && b < 0 && c > 0) 
                || (a < 0 && b > 0 && c < 0) || (a > 0 && b < 0 && c < 0))
            {
                sign = "positive";
            }
            else if(a == 0 || b == 0 || c == 0)
            {
                sign = "zero";
            }
            else
            {
                sign = "negative";
            }

            return sign;
        }
    }
}
