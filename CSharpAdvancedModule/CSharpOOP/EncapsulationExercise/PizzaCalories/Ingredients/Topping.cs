using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories.Ingredients
{
    public  class Topping
    {
        private const double BASE_CALORIES = 2;
        private const string INVALID_TYPE = "Cannot place {0} on top of your pizza.";
        private const string INVALID_WEIGHT = "{0} weight should be in the range [1..50].";

        private double weight;
        private string type;

        public Topping(string type, double weight)
        {

            Type = type;
            Weight = weight;
        }

        public double Weight
        {
            get
            {
                return weight;
            }
            private set
            {
                if (value < 0 || value > 50)
                {
                    throw new ArgumentException(String.Format(INVALID_WEIGHT, Type));
                }
                weight = value;
            }
        }
        public string Type
        {
            get
            {
                return type;
            }
            private set
            {
                switch (value.ToLower())
                {
                    case "meat":
                    case "veggies":
                    case "cheese":
                    case "sauce":
                        type = value;
                        break;
                    default:
                        throw new ArgumentException(String.Format(INVALID_TYPE,value));
                }
            }
        }
        public double GetCalories()
        {
            double toppingModifier = 0;
            switch (Type.ToLower())
            {
                case "meat":
                    toppingModifier = 1.2;
                    break;
                case "veggies":
                    toppingModifier = 0.8;
                    break;
                case "cheese":
                    toppingModifier = 1.1;
                    break;
                case "sauce":
                    toppingModifier = 0.9;
                    break;
            }
            return Weight * BASE_CALORIES * toppingModifier;
        }
    }
}
