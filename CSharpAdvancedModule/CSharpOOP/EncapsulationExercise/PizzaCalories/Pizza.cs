using PizzaCalories.Ingredients;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private Dough dough;
        private List<Topping> toppings;

        public Pizza()
        {
            toppings = new List<Topping>();
        }
        public Pizza(string name, Dough dough)
            :this()
        {
            Name = name;
            Dough = dough;
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (String.IsNullOrEmpty(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                name = value;
            }
        }
        public Dough Dough { get; set; }
        public int ToppingsCount
        {
            get
            {
                return toppings.Count;
            }
        }

        public void AddTopping(Topping topping)
        {
            if (toppings.Count > 9)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }
            toppings.Add(topping);
        }

        public double Calories()
        {
            double toppingsCalories = 0;

            foreach (Topping topping in toppings)
            {
                toppingsCalories += topping.GetCalories();
            }

            return toppingsCalories + Dough.GetCalories();
        }
    }
}
