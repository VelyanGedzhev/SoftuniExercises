using System;

namespace _1.MathFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"\b[A-Z][a-z]+ [A-Z][a-z]+\b";
            string input = Console.ReadLine();
            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match name in matches)
            {
                Console.Write(name.Value + " ");
            }
        }
    }
}
