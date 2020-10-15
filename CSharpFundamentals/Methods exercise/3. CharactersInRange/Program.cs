using System;
using System.Text;

namespace _3._CharactersInRange
{
    class Program
    {
        static void Main(string[] args)
        {
            char firstChar = char.Parse(Console.ReadLine());
            char secondChar = char.Parse(Console.ReadLine());
            Console.WriteLine(CharactersInBetween(firstChar, secondChar));
        }
        static string CharactersInBetween(char firstChar, char secondChar)
        {
            StringBuilder result = new StringBuilder();
            int start = Math.Min(firstChar, secondChar);
            int end = Math.Max(firstChar,secondChar);

            for (int i = start + 1; i < end; i++)
            {
                result.Append((char)i + " ");
            }

            return result.ToString();
        }

    }
}
