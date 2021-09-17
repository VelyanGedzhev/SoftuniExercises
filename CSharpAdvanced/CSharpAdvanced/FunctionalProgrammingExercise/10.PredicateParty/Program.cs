using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.PredicateParty
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> guests = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            
            string input = Console.ReadLine();
            while (input != "Party!")
            {
                string[] commandInput = input.Split();
                string commandType = commandInput[0];
                string commandName = commandInput[1];
                string argument = commandInput[2];

                if (commandType == "Remove")
                {
                    if (commandName == "StartsWith")
                    {
                        guests = guests.Where(g => !g.StartsWith(argument)).ToList();
                    }
                    else if (commandName == "EndsWith")
                    {
                        guests = guests.Where(g => !g.EndsWith(argument)).ToList();
                    }
                    else if (commandName == "Length")
                    {
                        guests = guests.Where(g => g.Length == int.Parse(argument)).ToList();
                    }
                }
                else if (commandType == "Double")
                {
                    if (commandName == "StartsWith")
                    {
                        for (int i = 0; i < guests.Count; i++)
                        {
                            if (guests[i].StartsWith(argument))
                            {
                                guests.Insert(i + 1, guests[i]);
                                i++;
                            }
                        }
                    }
                    else if (commandName == "EndsWith")
                    {
                        for (int i = 0; i < guests.Count; i++)
                        {
                            if (guests[i].EndsWith(argument))
                            {
                                guests.Insert(i + 1, guests[i]);
                                i++;
                            }
                        }
                    }
                    else if (commandName == "Length")
                    {
                        for (int i = 0; i < guests.Count; i++)
                        {
                            if (guests[i].Length == int.Parse(argument))
                            {
                                guests.Insert(i + 1, guests[i]);
                                i++;
                            }
                        }
                    }
                }

                input = Console.ReadLine();
            }
            if (guests.Count > 0)
            {
                Console.WriteLine($"{string.Join(", ",guests)} are going to the party!");
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
