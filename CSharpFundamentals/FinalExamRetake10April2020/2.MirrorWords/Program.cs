using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _2.MirrorWords
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"(?<separator>[@,#])(?<firstWord>[A-Za-z]{3,})\k<separator>\k<separator>(?<secondWord>[A-Za-z]{3,})\k<separator>";
            string input = Console.ReadLine();
            List<string> validWords = new List<string>();

            MatchCollection matches = Regex.Matches(input, pattern);

            foreach (Match item in matches)
            {
                var firstWord = item.Groups["firstWord"].Value;
                var secondWord = item.Groups["secondWord"].Value;
                var reversed = string.Concat(firstWord.Reverse());

                if (reversed == secondWord)
                {
                    validWords.Add(firstWord + " <=> " + secondWord);
                }
            }

            if (matches.Count > 0)
            {
                Console.WriteLine($"{matches.Count} word pairs found!");

                if (validWords.Count > 0)
                {
                    Console.WriteLine("The mirror words are:");
                    Console.WriteLine(string.Join(", ", validWords));
                }
                else
                {
                    Console.WriteLine("No mirror words!");
                }
            }
            else
            {
                Console.WriteLine("No word pairs found!");
                Console.WriteLine("No mirror words!");
            }
        }
    }
}
