using System;
using System.Text.RegularExpressions;


namespace _6._ExtractEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = @"(?<=\s)(?<user>[A-Za-z0-9]+[.-]*\w*)*@(?<host>[a-z]+?([.-][a-z]*)*(\.[a-z]{2,}))";

            MatchCollection matches = Regex.Matches(input, pattern);

            Console.WriteLine(String.Join(Environment.NewLine, matches));
        }
    }
}
