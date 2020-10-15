using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._HouseParty
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            List<string> guests = new List<string>();
            
            

            for (int i = 0; i < count; i++)
            {
                string input = Console.ReadLine();
                List<string> currentGuest = input
                    .Split()
                    .ToList();

                if (currentGuest[2] == "going!")
                {
                    if (guests.Contains(currentGuest[0]))
                    {
                        Console.WriteLine($"{currentGuest[0]} is already in the list!");
                    }
                    else
                    {
                        guests.Add(currentGuest[0]);
                    }
                }
                else
                {
                    if (guests.Contains(currentGuest[0]))
                    {
                        guests.Remove(currentGuest[0]);
                    }
                    else
                    {
                        Console.WriteLine($"{currentGuest[0]} is not in the list!");
                    }
                }
               
            }

            for (int i = 0; i < guests.Count; i++)
            {
                Console.WriteLine($"{guests[i]}");
            }
        }
        
    }
}
