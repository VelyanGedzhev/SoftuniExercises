using System;
using System.Collections.Generic;
using System.Linq;

namespace ThirdTask
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, int> plantsRarity = new Dictionary<string, int>();
            Dictionary<string, List<double>> plantsRating = new Dictionary<string, List<double>>();

            for (int i = 1; i <= n; i++)
            {
                string input = Console.ReadLine();
                string[] info = input.Split("<->");
                string plantName = info[0];
                int rarity = int.Parse(info[1]);

                if (!plantsRarity.ContainsKey(plantName))
                {
                    plantsRarity.Add(plantName, rarity);
                }
                else
                {
                    plantsRarity[plantName] = rarity;
                }
            }

            string input2 = Console.ReadLine();
            while (input2 != "Exhibition")
            {
                string[] info = input2.Split();
                string plantName = info[1];

                if (input2.Contains("Rate"))
                {
                    double rating = double.Parse(info[3]);
                    if (!plantsRating.ContainsKey(plantName))
                    {

                        plantsRating.Add(plantName, new List<double>());
                        plantsRating[plantName].Add(rating);
                    }
                    else
                    {
                        plantsRating[plantName].Add(rating);
                    }

                }
                else if (input2.Contains("Update"))
                {
                    int rarity = int.Parse(info[3]);
                    plantsRarity[plantName] = rarity;
                }
                else if (input2.Contains("Reset"))
                {
                    plantsRating[plantName] = null;
                }
                else
                {
                    Console.WriteLine("error");
                }
                input2 = Console.ReadLine();
            }
            foreach (var item in plantsRarity.OrderByDescending(x => x.Value))
            {          
               Console.WriteLine($"{item.Key}, Rarity: {item.Value}, Rating: {plantsRating[item.Key].Sum() / plantsRating[item.Key].Count()}");
            }
        }
    }
}
