using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories.Ingredients
{
    public class Dough
    {
        private const double BASE_CALORIES = 2;

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weigth)
        {
            FlourType = flourType;
            BakingTechnique = bakingTechnique;
            Weigth = weigth;
        }

        public string FlourType
        {
            get
            {
                return flourType;
            }
            private set
            {
                switch (value.ToLower())
                {
                    case "white":
                    case "wholegrain":
                        flourType = value;
                        break;
                    default:
                        throw new ArgumentException("Invalid type of dough.");
                }
            }
        }
        public string BakingTechnique
        {
            get
            {
                return bakingTechnique;
            }
            private set
            {
                switch (value.ToLower())
                {
                    case "crispy":
                    case "chewy":
                    case "homemade":
                        bakingTechnique = value;
                        break;
                    default:
                        throw new ArgumentException("Invalid type of dough.");
                }
            }
        }
        public double Weigth
        {
            get
            {
                return weight;
            }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                weight = value;
            }
        }

        public double GetCalories()
        {
            double flourModifier = 0;
            double techniqueModifier = 0;

            switch (FlourType.ToLower())
            {
                case "white":
                    flourModifier = 1.5;
                    break;
                case "wholegrain":
                    flourModifier = 1.0;
                    break;
            }
            switch (BakingTechnique.ToLower())
            {
                case "crispy":
                    techniqueModifier = 0.9;
                    break;
                case "chewy":
                    techniqueModifier = 1.1;
                    break;
                case "homemade":
                    techniqueModifier = 1.0;
                    break;
            }

            return (2 * Weigth) * flourModifier * techniqueModifier;
        }
    }
}
