using System;
using System.Text;
using System.Text.RegularExpressions;

namespace _2._MessageTranslator
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string pattern = @"!(?<command>[A-Z]{1}[a-z]{2,})!:\[(?<message>[A-Za-z]{8,})]";
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                if (Regex.IsMatch(input,pattern))
                {
                    Match match = Regex.Match(input, pattern);

                    foreach (var item in match.Groups["message"].Value)
                    {
                        sb.Append((int)item + " ");
                    }
                    Console.WriteLine($"{match.Groups["command"].Value}: {sb.ToString().Trim()}");
                }
                else
                {
                    Console.WriteLine("The message is invalid");
                }
            }
        }
    }
}
