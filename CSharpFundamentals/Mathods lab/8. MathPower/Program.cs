using System;

namespace _8._MathPower
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(RaiseToPower(
                double.Parse(Console.ReadLine()),
                double.Parse(Console.ReadLine())));
                
        }
        static double RaiseToPower(double number, double power)
        {
            return Math.Pow(number, power);
        }
    }
}
