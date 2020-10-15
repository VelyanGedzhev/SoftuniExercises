using System;

namespace _5._DecryptingMessages
{
    class Program
    {
        static void Main(string[] args)
        {
            short key = short.Parse(Console.ReadLine());
            short count = short.Parse(Console.ReadLine());
            string output = string.Empty;

            for (int i = 0; i < count; i++)
            {
                char symbol = char.Parse(Console.ReadLine());
                int currentSymbol = symbol + key;
                output += (char)currentSymbol;
            }
            Console.WriteLine(output);
        }
    }
}
