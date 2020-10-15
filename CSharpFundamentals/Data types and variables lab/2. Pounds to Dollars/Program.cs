using System;

namespace _2._Pounds_to_Dollars
{
    class Program
    {
        static void Main(string[] args)
        {
            double pounds = double.Parse(Console.ReadLine());
            decimal dollars = (decimal)pounds * 1.31M;

            Console.WriteLine($"{dollars:f3}");
        }
    }
}
