using System;

namespace _1._DataTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckingInput(Console.ReadLine());
        }
        static void CheckingInput(string input)
        {
            if(input == "int")
            {
                MultiplyInteger(int.Parse(Console.ReadLine()));
            }
            else if(input == "real")
            {
                MultiplyAndFormatRealNum(double.Parse(Console.ReadLine()));
            }
            else if (input == "string")
            {
                SurroundString(Console.ReadLine());
            }
        }
        static void MultiplyInteger(int num)
        {
            Console.WriteLine(num * 2);
        }
        static void MultiplyAndFormatRealNum(double num)
        {
            Console.WriteLine($"{num * 1.5:f2}");
        }
        static void SurroundString(string text)
        {
            Console.WriteLine($"${text}$");
        }
    }
}
