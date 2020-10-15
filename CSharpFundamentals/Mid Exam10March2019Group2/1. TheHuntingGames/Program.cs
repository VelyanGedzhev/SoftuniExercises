using System;

namespace _1._TheHuntingGames
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int playersCount = int.Parse(Console.ReadLine());
            double groupsEnergy = double.Parse(Console.ReadLine());
            double waterPerPersonPerDay = double.Parse(Console.ReadLine());
            double foodPerPersonPerDay = double.Parse(Console.ReadLine());
           
            double energy = groupsEnergy;
            double totalWater = waterPerPersonPerDay * playersCount * days;
            double totalFood = foodPerPersonPerDay * playersCount * days;

            for (int i = 1; i <= days; i++)
            {
                double energyLoss = double.Parse(Console.ReadLine());
                energy -= energyLoss;

                if (energy <= 0)
                {
                    Console.WriteLine($"You will run out of energy." +
                        $" You will be left with {totalFood:f2} food and {totalWater:f2} water.");
                    return;
                }
                if (i % 2 == 0)
                {
                    energy += energy * 0.05;
                    totalWater -= totalWater * 0.30;
                }
                else if (i % 3 == 0)
                {
                    totalFood -= totalFood / playersCount;
                    energy += energy * 0.10;
                }
            }
            Console.WriteLine($"You are ready for the quest. You will be left with - " +
                $"{energy:f2} energy!");
        }
    }
}
