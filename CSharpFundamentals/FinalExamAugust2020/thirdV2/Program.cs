using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace thirdV2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, Plant> plants = new Dictionary<string, Plant>();

            for (int i = 1; i <= n; i++)
            {
                string input = Console.ReadLine();
                string[] info = input.Split("<->");
                string plantName = info[0];
                double rarity = double.Parse(info[1]);

                if (!plants.ContainsKey(plantName))
                {
                    Plant plant = new Plant(rarity);
                    plants.Add(plantName, plant);
                }
                else
                {
                    plants[plantName].Rarity = rarity;
                }
            }
            string secondInput = Console.ReadLine();
            while (secondInput != "Exhibition")
            {
                string[] info = secondInput.Split();
                string plantName = info[1];


                if (secondInput.Contains("Rate"))
                {
                    double rating = double.Parse(info[3]);
                    plants[plantName].Rating.Add(rating);
                }
                else if (secondInput.Contains("Update"))
                {
                    double rarity = double.Parse(info[3]);
                    plants[plantName].Rarity = rarity;
                }
                else if (secondInput.Contains("Reset"))
                {
                    plants[plantName].Rating = new List<double>(){
                        0.0 };
                }
                else
                {
                    Console.WriteLine("error");
                }
                secondInput = Console.ReadLine();
            }
            var sortedPlants = plants.OrderByDescending(x => x.Value.Rarity)
                .ThenByDescending(x => x.Value.Rating.Average());

            Console.WriteLine("Plants for the exhibition:");

            foreach (var item in sortedPlants)
            {
                Console.WriteLine($"- {item.Key}; Rarity: {item.Value.Rarity}; " +
                    $"Rating: {item.Value.Rating.Average():f2}");
            }
        }
        public class Plant
        {
            public double Rarity { get; set; }
            public List<double> Rating;

            public Plant(double rarity)
            {
                this.Rarity = rarity;
                Rating = new List<double>();
            }

        }
    }

}
