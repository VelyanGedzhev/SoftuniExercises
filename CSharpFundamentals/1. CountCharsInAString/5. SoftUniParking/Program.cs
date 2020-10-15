using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._SoftUniParking
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            Dictionary<string, string> parkingLot = new Dictionary<string, string>();
            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine()
                    .Split()
                    .ToArray();

                string command = input[0];
                string userName = input[1];
                

                if (command == "register")
                {
                    string licensePlateNumber = input[2];

                    if (parkingLot.ContainsKey(userName))
                    {
                        Console.WriteLine($"ERROR: already registered with " +
                            $"plate number {parkingLot[userName]}");
                    }
                    else
                    {
                        parkingLot.Add(userName, licensePlateNumber);
                        Console.WriteLine($"{userName} registered {licensePlateNumber} " +
                            $"successfully");
                    }
                }
                else
                {
                    if (parkingLot.ContainsKey(userName))
                    {
                        parkingLot.Remove(userName);
                        Console.WriteLine($"{userName} unregistered successfully");
                    }
                    else
                    {
                        Console.WriteLine($"ERROR: user {userName} not found");
                    }
                }
            }
            foreach (var user in parkingLot)
            {
                Console.WriteLine($"{user.Key} => {user.Value}");
            }
        }
    }
}
