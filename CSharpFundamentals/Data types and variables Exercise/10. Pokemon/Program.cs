using System;

namespace _10._Pokemon
{
    class Program
    {
        static void Main(string[] args)
        {
            int startingPokePower = int.Parse(Console.ReadLine());
            int distance = int.Parse(Console.ReadLine());
            int exhaustion = int.Parse(Console.ReadLine());
            int targetsPoked = 0;

            int pokePower = startingPokePower;
            while (pokePower >= distance)
            {
                pokePower -= distance;
                targetsPoked++;
                if (pokePower * 2 == startingPokePower && exhaustion > 0)
                {
                    pokePower /= exhaustion;
                }
            }
            Console.WriteLine(pokePower);
            Console.WriteLine(targetsPoked);
        }
    }
}
