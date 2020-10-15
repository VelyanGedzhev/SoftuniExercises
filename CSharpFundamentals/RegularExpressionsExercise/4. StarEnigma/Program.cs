using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _4._StarEnigma
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            string pattern = @"[sStTaArR]";
            List<string> attacked = new List<string>();
            List<string> destroyed = new List<string>();


            for (int i = 1; i <= number; i++)
            {
                string input = Console.ReadLine();
                MatchCollection matches = Regex.Matches(input, pattern);
                int count = matches.Count;

                string decryptedMessage = string.Empty;

                foreach (var symbol in input)
                {
                    decryptedMessage += ((char)(symbol - count));
                }
                string secondPattern = @"@(?<planet>[A-Za-z]+)[^@\-!:>]*:(?<population>\d*)[^@\-!:>]*!(?<type>A?D?)![^@\-!:>]*->(?<soldiers>\d+)";
                MatchCollection info = Regex.Matches(decryptedMessage, secondPattern);

                foreach (Match item in info)
                {
                    if (item.Groups["type"].Value == "A")
                    {
                        attacked.Add("-> " + item.Groups["planet"].Value);
                    }
                    else
                    {
                        destroyed.Add("-> " + item.Groups["planet"].Value);
                    }
                }
            }
            Console.WriteLine($"Attacked planets: {attacked.Count}");
            if (attacked.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, attacked.OrderBy(x => x)));
            }
            Console.WriteLine($"Destroyed planets: {destroyed.Count}");
            if (destroyed.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, destroyed.OrderBy(x => x)));
            }
        }
    }
}
