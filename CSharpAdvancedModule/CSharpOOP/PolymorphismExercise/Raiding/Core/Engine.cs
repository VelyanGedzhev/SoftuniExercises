using Raiding.Core.Interfaces;
using Raiding.Factories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Raiding.Core
{
    class Engine : IEngine
    {
        private readonly List<BaseHero> party;
        private readonly HeroFactory heroFactory;
        public Engine()
        {
            heroFactory = new HeroFactory();
            party = new List<BaseHero>();
        }

        public void Run()
        {
            int n = int.Parse(Console.ReadLine());

            while (n > party.Count)
            {
                try
                {
                    BaseHero currentHero = GetHeroInfo();
                    if (currentHero != null)
                    {
                        party.Add(currentHero);
                    }
                }
                catch (ArgumentException ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            int bossPower = int.Parse(Console.ReadLine());
            int heroesCombinedPower = 0;

            foreach (BaseHero hero in party)
            {
                Console.WriteLine(hero.CastAbility());
                heroesCombinedPower += hero.Power;
            }
            if (heroesCombinedPower >= bossPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
        private BaseHero GetHeroInfo()
        {
            string name = Console.ReadLine();
            string heroClass = Console.ReadLine();

            return heroFactory.CreateHero(name, heroClass);
        }
    }

}
