using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Heroes
{
    public class HeroRepository
    {
        private List<Hero> heroes;

        public HeroRepository()
        {
            heroes = new List<Hero>();
        }
        public int Count => heroes.Count;

        public void Add(Hero hero)
        {
            heroes.Add(hero);
        }
        public void Remove(string name)
        {
            heroes.Remove(heroes.FirstOrDefault(n => n.Name == name));
        }
        public Hero GetHeroWithHighestStrength()
        {
            return heroes.OrderByDescending(s => s.Item.Strength).FirstOrDefault();
        }
        public Hero GetHeroWithHighestAbility()
        {
            return heroes.OrderByDescending(s => s.Item.Ability).FirstOrDefault();
        }
        public Hero GetHeroWithHighestIntelligence()
        {
            return heroes.OrderByDescending(s => s.Item.Intelligence).FirstOrDefault();
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (Hero hero in heroes)
            {
                sb.AppendLine(hero.ToString());
                
            }
            return sb.ToString().Trim();
        }
    }
}
