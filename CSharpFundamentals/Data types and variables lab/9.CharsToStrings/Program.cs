using System;

namespace _9.CharsToStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string result = "";
            for (int i = 0; i < 3; i++)
            {
                char currentChar = char.Parse(Console.ReadLine());
                result += currentChar;
            }
            Console.WriteLine(result);
        }
    }
}
