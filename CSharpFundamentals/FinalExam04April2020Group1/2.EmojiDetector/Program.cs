using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace _2.EmojiDetector
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string emojiPattern = @"(:{2}|\*{2})(?<emoji>[A-Z][a-z]{2,})\1";
            string digitsPattern = @"(?<num>[\d])";
            int threshold = 1;
            List<string> validEmojis = new List<string>();
            MatchCollection emojiMatches = Regex.Matches(input, emojiPattern);
            MatchCollection numbersMatches = Regex.Matches(input, digitsPattern);

            foreach (Match digit in numbersMatches)
            {
                threshold *= int.Parse(digit.Groups["num"].Value);
            }

            foreach (Match emoji in emojiMatches)
            {
                int emojiSum = 0;
                foreach (var item in emoji.Groups["emoji"].Value)
                {
                    emojiSum += item;
                }

                if (emojiSum > threshold)
                {
                    validEmojis.Add(emoji.ToString());
                }
            }
            Console.WriteLine($"Cool threshold: {threshold}");
            Console.WriteLine($"{emojiMatches.Count} emojis found in the text. The cool ones are:");
            if (validEmojis.Count > 0)
            {
                Console.WriteLine(string.Join(Environment.NewLine, validEmojis));
            }
        }
    }
}
