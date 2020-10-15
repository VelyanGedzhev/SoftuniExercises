using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._ForceBook
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Dictionary<string, List<string>> forceBook = new Dictionary<string, List<string>>();

            while(true)
            {
                string command = Console.ReadLine();

                if (command == "Lumpawaroo")
                {
                    break;
                }
                string forceSide = string.Empty;
                string forceUser = string.Empty;

                if (command.Contains(" | "))
                {
                    string[] input = command
                        .Split(" | ")
                        .ToArray();

                    forceSide = input[0];
                    forceUser = input[1];

                    if (!forceBook.ContainsKey(forceSide))
                    {
                        forceBook.Add(forceSide, new List<string>());

                        if (!forceBook[forceSide].Contains(forceUser))
                        {
                            forceBook[forceSide].Add(forceUser);
                        }
                    }
                    else
                    {
                        if (!forceBook[forceSide].Contains(forceUser))
                        {
                            forceBook[forceSide].Add(forceUser);
                        }
                    }
                }
                else if (command.Contains(" -> "))
                {
                    string[] input = command
                        .Split(" -> ")
                        .ToArray();

                    forceSide = input[1];
                    forceUser = input[0];
                    
                    foreach (var user in forceBook.Values)
                    {
                        if (user.Contains(forceUser) && 
                            (!forceBook[forceSide].Contains(forceUser)))
                        {
                            user.Remove(forceUser);
                            forceBook[forceSide].Add(forceUser);
                            Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                            break;
                        }
                    }
                    if (!forceBook[forceSide].Contains(forceUser) && forceBook.ContainsKey(forceSide))
                    {
                        forceBook[forceSide].Add(forceUser);
                        Console.WriteLine($"{forceUser} joins the {forceSide} side!");
                    }
                    else if(!forceBook[forceSide].Contains(forceUser) && !forceBook.ContainsKey(forceSide))
                    {
                        forceBook.Add(forceSide, new List<string>());
                        forceBook[forceSide].Add(forceUser);
                    }
                }
                
            }
            Dictionary<string, List<string>> sortedUsers = forceBook
                 .Where(x => x.Value.Count() >= 1)
                 .OrderByDescending(x => x.Value.Count())
                 .ThenBy(x => x.Key)
                 .ToDictionary(x => x.Key, x => x.Value);

            foreach (var side in sortedUsers)
            {
                Console.WriteLine($"Side: {side.Key}, Members: {side.Value.Count()}");

                foreach (var member in side.Value.OrderBy(x => x))
                {
                    Console.WriteLine($"! {member}");
                }
            }
        }
    }
}
