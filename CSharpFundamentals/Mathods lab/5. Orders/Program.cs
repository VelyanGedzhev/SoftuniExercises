using System;

namespace _5._Orders
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderFinalPrice(
                Console.ReadLine(),
                double.Parse(Console.ReadLine())
                );
            
        }
        static void OrderFinalPrice(string product, double quantity)
        {
            switch (product)
            {
                case "coffee":
                    Console.WriteLine($"{quantity*1.5:f2}");
                    break;
                case "water":
                    Console.WriteLine($"{quantity * 1.0:f2}");
                    break;
                case "coke":
                    Console.WriteLine($"{quantity * 1.4:f2}");
                    break;
                case "snacks":
                    Console.WriteLine($"{quantity * 2.0:f2}");
                    break;
            }
        }
    }
}
