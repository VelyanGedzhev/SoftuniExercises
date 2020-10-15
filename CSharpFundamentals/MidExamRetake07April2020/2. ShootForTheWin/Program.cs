using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._ShootForTheWin
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            string command = string.Empty;
            int counter = 0;

            while ((command = Console.ReadLine()) != "End")
            {
                int currentTarget = int.Parse(command);

                if(currentTarget >= 0 && currentTarget <= sequence.Count - 1)
                {
                    int currentValue = sequence[currentTarget];
                    sequence[currentTarget] = -1;
                    counter++;

                    for (int i = 0; i < sequence.Count; i++)
                    {
                        if (i == currentTarget || sequence[i] == -1)
                        {
                            continue;
                        }
                        if (sequence[i] > currentValue)
                        {
                            sequence[i] -= currentValue;
                        }
                        else
                        {
                            sequence[i] += currentValue;
                        }
                    }
                }
                
            }
            Console.WriteLine($"Shot targets: {counter} -> {String.Join(" ", sequence)}");
        }
    }
}
