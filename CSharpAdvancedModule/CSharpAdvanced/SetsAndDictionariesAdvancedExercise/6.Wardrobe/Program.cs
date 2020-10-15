using System;
using System.Collections.Generic;

namespace _6.Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine()
                    .Split(" -> ");
                var clothes = input[1].Split(",");

                if (!wardrobe.ContainsKey(input[0]))
                {
                    wardrobe.Add(input[0], new Dictionary<string, int>());
                }
                for (int j = 0; j < clothes.Length; j++)
                {
                    if (!wardrobe[input[0]].ContainsKey(clothes[j]))
                    {
                        wardrobe[input[0]].Add(clothes[j], 0);
                    }
                    wardrobe[input[0]][clothes[j]]++;
                }
            }
            string[] input2 = Console.ReadLine().Split();
            

            foreach (var item in wardrobe)
            {
                bool isFoundColor = false;

                if (item.Key == input2[0])
                {
                    isFoundColor = true;
                }
                Console.WriteLine($"{item.Key} clothes:");
                foreach (var cloth in item.Value)
                {
                    bool isFoundCloth = false;
                    if (cloth.Key == input2[1])
                    {
                        isFoundCloth = true;
                    }
                    if (isFoundColor && isFoundCloth)
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {cloth.Key} - {cloth.Value}");
                    }
                    
                }
            }
        }
    }
}
