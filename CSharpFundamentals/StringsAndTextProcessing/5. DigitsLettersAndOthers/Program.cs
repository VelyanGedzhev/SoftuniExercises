using System;
using System.Text;

namespace _5._DigitsLettersAndOthers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            StringBuilder digits = new StringBuilder();
            StringBuilder letters = new StringBuilder();
            StringBuilder symbols = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];

                if (char.IsDigit(currentChar))
                {
                    digits.Append(currentChar);
                }
                else if (char.IsLetter(currentChar))
                {
                    letters.Append(currentChar);
                }
                else //if (char.IsSymbol(currentChar))
                {
                    symbols.Append(currentChar);
                }
            }
            Console.WriteLine(string.Join("",digits));
            Console.WriteLine(string.Join("",letters));
            Console.WriteLine(string.Join("",symbols));
        }
    }
}
