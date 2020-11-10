using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods.Interfaces;

namespace WildFarm.Models.Animals.Interfaces
{
    public interface IFeedable
    {
        public void Feed(IFood food);

        public int FoodEaten { get; }
        public double WeightMultiplier { get; }
        public ICollection<Type> PreferredFoods { get; }
    }
}
