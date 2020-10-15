using System;
using System.Linq;

namespace _2._MuOnline
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] rooms = Console.ReadLine()
                .Split("|")
                .ToArray();

            int health = 100;
            int coins = 0;

            for (int i = 0; i < rooms.Length; i++)
            {
                string[] input = rooms[i]
                    .Split()
                    .ToArray();
                int potionValue = int.Parse(input[1]);

                if (input[0] == "potion")
                {
                    int value = 0;

                    if (potionValue < 100 - health)
                    {
                        value = potionValue;
                    }
                    else
                    {
                        value = 100 - health;
                    }

                    health += value;
                    Console.WriteLine($"You healed for {value} hp.");
                    Console.WriteLine($"Current health: {health} hp.");
                }
                else if (input[0] == "chest")
                {
                    int coinsValue = int.Parse(input[1]);
                    Console.WriteLine($"You found {coinsValue} bitcoins.");
                    coins += coinsValue;
                }
                else
                {
                    string monster = input[0];
                    int monsterAttack = int.Parse(input[1]);
                    health -= monsterAttack;

                    if (health <= 0)
                    {
                        Console.WriteLine($"You died! Killed by {monster}.");
                        Console.WriteLine($"Best room: {i + 1}");
                        return;
                    }
                    else
                    {
                        Console.WriteLine($"You slayed {monster}.");
                    }
                }
            }
            Console.WriteLine($"You've made it!");
            Console.WriteLine($"Bitcoins: {coins}");
            Console.WriteLine($"Health: {health}");
        }
    }
}
