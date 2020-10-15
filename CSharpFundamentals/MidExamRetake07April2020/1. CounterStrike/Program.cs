using System;
using System.Linq;

namespace _1._CounterStrike
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingEnergy = int.Parse(Console.ReadLine());
            
            int energy = startingEnergy;
            int winsCount = 0;
            string command = Console.ReadLine();

            while (command != "End of battle")
            {
                if (winsCount % 3 == 0)
                {
                    energy += winsCount;
                }
                int distance = int.Parse(command);

                if (distance <= energy)
                {
                    energy -= distance;
                    winsCount++;
                }
                else
                {
                    Console.WriteLine($"Not enough energy! Game ends with {winsCount}" +
                        $" won battles and {energy} energy");
                    return;
                }
               

                command = Console.ReadLine();
            }
            

            Console.WriteLine($"Won battles: {winsCount}. Energy left: {energy}");
        }
    }
}
