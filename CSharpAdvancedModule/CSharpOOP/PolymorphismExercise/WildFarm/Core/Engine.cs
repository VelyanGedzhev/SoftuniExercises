using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WildFarm.Core.Interfaces;
using WildFarm.Factories;
using WildFarm.Models.Animals;
using WildFarm.Models.Foods;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private readonly ICollection<Animal> animals;

        private readonly AnimalFactory animalFactory;
        private readonly FoodFactory foodFactory;
     
        public Engine()
        {
            animals = new HashSet<Animal>();
            animalFactory = new AnimalFactory();
            foodFactory = new FoodFactory();
        }
        public void Run()
        {
            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                string[] animalArgs = command
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string type = animalArgs[0];
                string name = animalArgs[1];
                double weight = double.Parse(animalArgs[2]);
                string[] args = animalArgs
                    .Skip(3)
                    .ToArray();

                Animal animal = null;

                try
                {
                    animal = animalFactory.Create(type, name, weight, args);

                    animals.Add(animal);
                    Console.WriteLine(animal.ProduceSound());
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);
                    
                }

                string[] foodArgs = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string foodType = foodArgs[0];
                int foodQty = int.Parse(foodArgs[1]);

                try
                {
                    Food food = foodFactory.CreateFood(foodType, foodQty);

                    animal?.Feed(food);

                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine(ioe.Message);

                }
            }

            foreach (Animal animal in animals)
            {
                
                Console.WriteLine(animal);
            }
        }
    }
}
