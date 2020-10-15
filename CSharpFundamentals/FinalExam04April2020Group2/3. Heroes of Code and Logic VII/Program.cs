using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Heroes_of_Code_and_Logic_VII
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Hero> heroes = new Dictionary<string, Hero>();
            for (int i = 1; i <= n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split()
                    .ToArray();
                Hero hero = new Hero(input);
                heroes.Add(input[0], hero);
            }

            string command = Console.ReadLine();
            while (command != "End")
            {
                if (command.Contains("CastSpell"))
                {
                    string[] splitted = command
                        .Split(" - ");

                    string heroName = splitted[1];
                    int mp = int.Parse(splitted[2]);
                    string spell = splitted[3];

                    if (heroes[heroName].MP >= mp)
                    {
                        heroes[heroName].MP -= mp;
                        Console.WriteLine($"{heroName} has successfully " +
                            $"cast {spell} and now has {heroes[heroName].MP} MP!");
                    }
                    else
                    {

                        Console.WriteLine($"{heroName} does not have enough MP to cast {spell}!");
                    }
                }
                else if (command.Contains("TakeDamage"))
                {
                    string[] splitted = command
                        .Split(" - ");

                    string heroName = splitted[1];
                    int damage = int.Parse(splitted[2]);
                    string attacker = splitted[3];

                    if (heroes[heroName].HP - damage > 0)
                    {
                        heroes[heroName].HP -= damage;
                        Console.WriteLine($"{heroName} was hit for {damage} HP by " +
                            $"{attacker} and now has {heroes[heroName].HP} HP left!");
                    }
                    else
                    {
                        Console.WriteLine($"{heroName} has been killed by {attacker}!");
                        heroes.Remove(heroName);
                    }
                }
                else if (command.Contains("Recharge"))
                {
                    string[] splitted = command
                        .Split(" - ");

                    string heroName = splitted[1];
                    int amount = int.Parse(splitted[2]);
                    int mp = 0;

                    if (heroes[heroName].MP + amount <= 200)
                    {
                        mp = amount;
                    }
                    else
                    {
                        mp = 200 - heroes[heroName].MP;
                    }

                    heroes[heroName].MP += mp;
                    Console.WriteLine($"{heroName} recharged for {mp} MP!");
                }
                else if (command.Contains("Heal"))
                {
                    string[] splitted = command
                        .Split(" - ");

                    string heroName = splitted[1];
                    int amount = int.Parse(splitted[2]);
                    int hp = 0;

                    if (heroes[heroName].HP + amount <= 100)
                    {
                        hp = amount;
                    }
                    else
                    {
                        hp = 100 - heroes[heroName].HP;
                    }

                    heroes[heroName].HP += hp;
                    Console.WriteLine($"{heroName} healed for {hp} HP!");
                }

                command = Console.ReadLine();
            }
            var sorted = heroes.OrderByDescending(h => h.Value.HP)
                .ThenBy(h => h.Key);

            foreach (var hero in sorted)
            {
                Console.WriteLine(hero.Key);
                Console.WriteLine($"  HP: {hero.Value.HP}");
                Console.WriteLine($"  MP: {hero.Value.MP}");
            }
        }
    }
    public class Hero
    {
        public int HP { get; set; }
        public int MP { get; set; }

        public Hero(string[] input)
        {
            this.HP = int.Parse(input[1]);
            this.MP = int.Parse(input[2]);
        }
    }
}
