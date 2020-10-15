using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.P_rates
{
    class Program
    {
        public class Settlement
        {
            public int Population { get; set; }
            public int Wealth { get; set; }
            public Settlement(string[] town)
            {
                this.Population = int.Parse(town[1]);
                this.Wealth = int.Parse(town[2]);
            }
        }
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Dictionary<string, Settlement> ports = new Dictionary<string, Settlement>();

            while (input != "Sail")
            {
                string[] town = input
                    .Split("||");
                string townName = town[0];
                if (ports.ContainsKey(townName))
                {
                    
                    int population = int.Parse(town[1]);
                    int gold = int.Parse(town[2]);

                    ports[townName].Wealth += gold;
                    ports[townName].Population += population;
                }
                else
                {
                    Settlement settlement = new Settlement(town);
                    ports.Add(townName, settlement);

                }

                input = Console.ReadLine();
            }
            input = Console.ReadLine();
            while (input != "End")
            {
                string[] command = input
                        .Split("=>");
                string townName = command[1];

                if (input.Contains("Plunder"))
                {
                    int people = int.Parse(command[2]);
                    int gold = int.Parse(command[3]);
                    ports[townName].Population -= people;
                    ports[townName].Wealth -= gold;
                    Console.WriteLine($"{townName} plundered! {gold} gold stolen, {people} citizens killed.");

                    if (ports[townName].Wealth <= 0 || ports[townName].Population <= 0)
                    {
                        ports.Remove(townName);
                        Console.WriteLine($"{townName} has been wiped off the map!");
                    }
                }
                else if (input.Contains("Prosper"))
                {
                    int gold = int.Parse(command[2]);

                    if (gold < 0)
                    {
                        Console.WriteLine("Gold added cannot be a negative number!");
                    }
                    else
                    {
                        ports[townName].Wealth += gold;
                        Console.WriteLine($"{gold} gold added to the city treasury. {townName} now has {ports[townName].Wealth} gold.");
                    }
                }
                input = Console.ReadLine();
            }
            if (ports.Count > 0)
            {
                var sortedPorts = ports.OrderByDescending(x => x.Value.Wealth)
                .ThenBy(x => x.Key);
                Console.WriteLine($"Ahoy, Captain! There are {ports.Count} wealthy settlements to go to:");
                foreach (var port in sortedPorts)
                {
                    Console.WriteLine($"{port.Key} -> Population: {port.Value.Population} citizens, Gold: {port.Value.Wealth} kg");
                }
            }
            else
            {
                Console.WriteLine("Ahoy, Captain! All targets have been plundered and destroyed!");
            }
            
        }
    }
}
