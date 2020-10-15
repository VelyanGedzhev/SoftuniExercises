using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace _1._ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split(", ")
                .ToArray();

            StringBuilder validNames = new StringBuilder();

            foreach (string name in input)
            {
                bool isValid = true;
                if (name.Length >= 3 && name.Length <= 16)
                {
                    foreach (char symbol in name)
                    {
                        
                        if (char.IsWhiteSpace(symbol) || char.IsSymbol(symbol)
                            || char.IsPunctuation(symbol))
                            //!(char.IsLetterOrDigit() || symbol == '-' || symbol == '_')
                        {
                            if (symbol != '-' && symbol != '_')
                            {
                                isValid = false;
                            }
                        }
                    }
                    if (isValid)
                    {
                        validNames.AppendLine(name);
                    }
                }
            }
            string result = validNames.ToString();
            Console.WriteLine(result);
        }
    }
}
