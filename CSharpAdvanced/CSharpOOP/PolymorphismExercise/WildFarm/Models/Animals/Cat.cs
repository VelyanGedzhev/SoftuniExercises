using System;
using System.Collections.Generic;
using System.Text;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Cat : Feline
    {
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        public override double WeightMultiplier => 0.3;

        public override ICollection<Type> PreferredFoods => new List<Type> { typeof(Meat), typeof(Vegetable) };

        public override string ProduceSound()
        {
            return "Meow";
        }
    }
}
