using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace _2._Race
{
    class Program
    {
        static void Main(string[] args)
        {
            string names = Console.ReadLine();
            string namePattern = @"[A-Za-z]";
            string distancePattern = @"\d";
            string[] participants = names
                .Split(", ")
                .ToArray();
            Dictionary<string, int> racers = new Dictionary<string, int>();

            string input = Console.ReadLine();
            

            while (input != "end of race")
            {
                MatchCollection nameMatch = Regex.Matches(input, namePattern);
                MatchCollection distanceMatch = Regex.Matches(input, distancePattern);
                string currentName = String.Concat(nameMatch);
                var distance = distanceMatch.Select(x => int.Parse(x.Value)).Sum();

                if (participants.Contains(currentName))
                {
                    if (!racers.ContainsKey(currentName))
                    {
                        racers.Add(currentName, distance);
                    }
                    else
                    {
                        racers[currentName] += distance;
                    }
                }
                input = Console.ReadLine();
            }
            var sorted = racers.OrderByDescending(x => x.Value)
                .Select(x => x.Key)
                .ToList();

            Console.WriteLine("1st place: " + sorted[0]);
            Console.WriteLine("2nd place: " + sorted[1]);
            Console.WriteLine("3rd place: " + sorted[2]);
        }
    }
}
