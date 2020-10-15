using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _3._NikuldensMeals
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            Dictionary<string, List<string>> guests = new Dictionary<string, List<string>>();
            int unliked = 0;

            while (command != "Stop")
            {
                string[] input = command
                    .Split("-");
                string guestName = input[1];
                string meal = input[2];

                if (command.Contains("Like"))
                {
                    if (!guests.ContainsKey(guestName))
                    {
                        guests.Add(guestName, new List<string>());
                        guests[guestName].Add(meal);
                    }
                    else if (guests.ContainsKey(guestName))
                    {
                        bool isFound = false;

                        foreach (var item in guests[guestName])
                        {
                            if (item == meal)
                            {
                                isFound = true;
                            }
                        }

                        if (isFound == false)
                        {
                            guests[guestName].Add(meal);
                        }
                    }
                }
                else if (command.Contains("Unlike"))
                {

                    if (!guests.ContainsKey(guestName))
                    {
                        Console.WriteLine($"{guestName} is not at the party.");
                    }
                    else
                    {
                        bool isFound = false;

                        foreach (var item in guests[guestName])
                        {
                            if (item == meal)
                            {
                                isFound = true;
                                guests[guestName].Remove(item);
                                Console.WriteLine($"{guestName} doesn't like the {meal}.");
                                unliked++;
                                break;
                            }
                        }

                        if (isFound == false)
                        {
                            Console.WriteLine($"{guestName} doesn't have the {meal} " +
                                $"in his/her collection.");
                        }
                    }
                }
                command = Console.ReadLine();
            }
            var sortedGuests = guests.OrderByDescending(x => x.Value.Count)
                .ThenBy(x => x.Key);

            foreach (var guest in sortedGuests)
            {
                Console.WriteLine($"{guest.Key}: {string.Join(", ", guest.Value)}");
                
            }
            Console.WriteLine($"Unliked meals: {unliked}");
        }   
    }
}
