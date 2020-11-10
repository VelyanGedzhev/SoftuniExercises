using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Animals.Interfaces;
using WildFarm.Models.Foods.Interfaces;

namespace WildFarm.Models.Animals
{
    public abstract class Animal 
        : IAnimal, IFeedable, ISoundable
    {
        private const string INVALID_FOOD = "{0} does not eat {1}!";

        protected Animal(string name, double weight)
        {
            Name = name;
            Weight = weight;
        }

        public string Name { get; }

        public double Weight { get; private set; }

        public int FoodEaten { get; private set; }

        public abstract double WeightMultiplier { get; }

        public abstract ICollection<Type> PreferredFoods { get; }

        public void Feed(IFood food)
        {
            if (!PreferredFoods.Contains(food.GetType()))
            {
                throw new InvalidOperationException(string.Format(INVALID_FOOD, GetType().Name, food.GetType().Name));
            }
            FoodEaten += food.Quantity;
            Weight += food.Quantity * WeightMultiplier;
        }

        public abstract string ProduceSound();
        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, ";
        }
    }
}
