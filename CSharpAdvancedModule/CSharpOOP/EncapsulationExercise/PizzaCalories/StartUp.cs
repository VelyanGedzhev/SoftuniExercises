using PizzaCalories.Ingredients;
using System;

namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            


            try
            {
                string[] pizzaArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string name = pizzaArgs[1];

                string[] doughtArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string flour = doughtArgs[1];
                string technique = doughtArgs[2];
                double weight = double.Parse(doughtArgs[3]);

                Dough dough = new Dough(flour, technique, weight);
                Pizza pizza = new Pizza(name, dough);

                string input = string.Empty;

                while ((input = Console.ReadLine()) != "END")
                {
                    string[] toppingArgs = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    string toppingName = toppingArgs[1];
                    double toppingWeight = double.Parse(toppingArgs[2]);

                    Topping topping = new Topping(toppingName, toppingWeight);

                    pizza.AddTopping(topping);
                    
                }

                Console.WriteLine($"{pizza.Name} - {pizza.Calories():f2} Calories.");
            }
            catch (ArgumentException ex)
            {

                Console.WriteLine(ex.Message);
            }
        }
    }
}
