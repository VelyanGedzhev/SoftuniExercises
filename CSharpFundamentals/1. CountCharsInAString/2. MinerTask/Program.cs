using System;
using System.Collections.Generic;

namespace _2._MinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = string.Empty;
            Dictionary<string, int> resources = new Dictionary<string, int>();

            while ((command = Console.ReadLine()) != "stop")
            {
                int value = int.Parse(Console.ReadLine());

                if (resources.ContainsKey(command))
                {
                    resources[command] += value;
                }
                else
                {
                    resources.Add(command, value);

                }
            }
            foreach (var resource in resources)
            {
                Console.WriteLine($"{resource.Key} -> {resource.Value}");
            }
        }
    }
}
