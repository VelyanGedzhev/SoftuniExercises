using System;
using System.Data;

namespace _3._Gaming_store
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyAmount = double.Parse(Console.ReadLine());
            double moneySpent = moneyAmount;
            string command = Console.ReadLine();

            while(command != "Game Time")
            {
                switch (command)
                {
                    case "OutFall 4":
                        if (moneySpent >= 39.99)
                        {
                            Console.WriteLine($"Bought {command}");
                            moneySpent -= 39.99;
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                            break;
                        }
                        break;
                    case "CS: OG":
                        if (moneySpent >= 15.99)
                        {
                            Console.WriteLine($"Bought {command}");
                            moneySpent -= 15.99;
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                            break;
                        }
                        break;
                    case "Zplinter Zell":
                        if (moneySpent >= 19.99)
                        {
                            Console.WriteLine($"Bought {command}");
                            moneySpent -= 19.99;
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                            break;
                        }
                        break;
                    case "Honored 2":
                        if (moneySpent >= 59.99)
                        {
                            Console.WriteLine($"Bought {command}");
                            moneySpent -= 59.99;
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                            break;
                        }
                        break;
                    case "RoverWatch":
                        if (moneySpent >= 29.99)
                        {
                            Console.WriteLine($"Bought {command}");
                            moneySpent -= 29.99;
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                            break;
                        }
                        break;
                    case "RoverWatch Origins Edition":
                        if (moneySpent >= 39.99)
                        {
                            Console.WriteLine($"Bought {command}");
                            moneySpent -= 39.99;
                        }
                        else
                        {
                            Console.WriteLine("Too Expensive");
                            break;
                        }
                        break;
                    default:
                        Console.WriteLine("Not Found");
                        break;
                }
                if(moneySpent == 0)
                {
                    Console.WriteLine("Out of money!");
                    break;
                }
                command = Console.ReadLine();
            }
            if (moneySpent > 0)
            {
                Console.WriteLine($"Total spent: ${moneyAmount - moneySpent:f2}. Remaining: ${moneySpent:f2}");
            }
            
        }
    }
}
