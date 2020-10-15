using System;

namespace _3._Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());

            Calculations(a, b, command);

        }
        static void Calculations(int x, int y, string command)
        {
            if(command == "add")
            {
                Console.WriteLine(x+y);
            }
            else if(command == "multiply")
            {
                Console.WriteLine(x * y);
            }
            else if (command == "subtract")
            {
                Console.WriteLine(x-y);
            }
            else if (command == "divide")
            {
                Console.WriteLine(x / y);
            }
        }
    }
}
