using System;

namespace _7._Vending_machine
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            double totalSum = 0;

            while(input != "Start")
            {
                double currentAmount = double.Parse(input);

                if(currentAmount != 0.1 && currentAmount != 0.2 && currentAmount != 0.5 
                    && currentAmount != 1 && currentAmount != 2)
                {
                    Console.WriteLine($"Cannot accept {currentAmount}");
                }
                else
                {
                    totalSum += currentAmount;
                }
                input = Console.ReadLine();
            }
            string input2 = Console.ReadLine();
            string product = "";
            while(input2 != "End")
            {
                double currentPrice = 0;
                switch (input2)
                {
                    case "Nuts":
                        currentPrice = 2.0;
                        product = "nuts";
                        break;
                    case "Water":
                        currentPrice = 0.7;
                        product = "water";
                        break;
                    case "Crisps":
                        currentPrice = 1.5;
                        product = "crisps";
                        break;
                    case "Soda":
                        currentPrice = 0.8;
                        product = "soda";
                        break;
                    case "Coke":
                        currentPrice = 1.0;
                        product = "coke";
                        break;
                    default:
                        Console.WriteLine("Invalid product");
                        input2 = Console.ReadLine();
                        continue;
                }

                if(totalSum >= currentPrice)
                {
                    totalSum -= currentPrice;
                    Console.WriteLine($"Purchased {product}"); //.ToLower
                }
                else
                {
                    Console.WriteLine("Sorry, not enough money");
                }

                input2 = Console.ReadLine();
            }
            Console.WriteLine($"Change: {totalSum:f2}");
        }
    }
}
