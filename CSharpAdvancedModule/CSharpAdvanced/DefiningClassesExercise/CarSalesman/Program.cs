using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            List<Engine> engines = new List<Engine>();

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string model = string.Empty;
                string power = string.Empty;
                string discplacement = string.Empty;
                string efficiency = string.Empty;

                if (input.Length == 2)
                {
                     model = input[0];
                     power = input[1];
                     discplacement = "n/a";
                     efficiency = "n/a";
                }
                else if (input.Length == 3)
                {
                     model = input[0];
                     power = input[1];
                     discplacement = input[2];
                     efficiency = "n/a";
                }
                else
                {
                     model = input[0];
                     power = input[1];
                     discplacement = input[2];
                     efficiency = input[3];
                }
                
                Engine engine = new Engine(model, power, discplacement, efficiency);
                engines.Add(engine);
            }
            int m = int.Parse(Console.ReadLine());

            for (int i = 0; i < m; i++)
            {
                string[] input = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                var engine = engines.Where(x => x.Model == input[1]).FirstOrDefault();
                string weight = string.Empty;
                string color = string.Empty;

                if (input.Length == 2)
                {
                    weight = "n/a";
                    color = "n/a";
                }
                else if (input.Length == 3)
                {
                    weight = input[2];
                    color = "n/a";
                }
                else
                {
                    weight = input[2];
                    color = input[3];
                }

                Car car = new Car(model, engine, weight, color);
                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");
                Console.WriteLine($"    Discplacement: {car.Engine.Discplacement}");
                Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
                Console.WriteLine($"  Weight: {car.Weight}");
                Console.WriteLine($"  Color: {car.Color}");
            }
        }
    }
}
