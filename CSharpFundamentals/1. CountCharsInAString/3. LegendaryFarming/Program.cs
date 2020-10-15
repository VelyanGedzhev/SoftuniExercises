using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _3._LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> keyResources = new Dictionary<string, int>();
            keyResources.Add("shards", 0);
            keyResources.Add("fragments", 0);
            keyResources.Add("motes", 0);
            Dictionary<string, int> junk = new Dictionary<string, int>();
            string legendaryItem = string.Empty;
            bool isObtained = false;

            while (isObtained == false)
            {
                string[] input = Console.ReadLine()
                     .Split()
                     .ToArray();

                for (int i = 0; i < input.Length; i++)
                {
                    int value = 0;
                    string material = string.Empty;

                    if (i % 2 == 0)
                    {
                        value = int.Parse(input[i]);
                        material = input[i + 1].ToLower();
                    }
                    if (keyResources.ContainsKey("shards") && keyResources["shards"] >= 250)
                    {
                        legendaryItem = "Shadowmourne";
                        keyResources["shards"] -= 250;
                        isObtained = true;
                        break;
                    }
                    if (keyResources.ContainsKey("fragments") && keyResources["fragments"] >= 250)
                    {
                        legendaryItem = "Valanyr";
                        keyResources["fragments"] -= 250;
                        isObtained = true;
                        break;
                    }
                    if (keyResources.ContainsKey("motes") && keyResources["motes"] >= 250)
                    {
                        legendaryItem = "Dragonwrath";
                        keyResources["motes"] -= 250;
                        isObtained = true;
                        break;
                    }
                    if (material == "")
                    {
                        continue;
                    }
                    if (material == "shards" || material == "fragments" ||
                        material == "motes")
                    {
                        if (keyResources.ContainsKey(material))
                        {
                            keyResources[material] += value;
                        }

                    }
                    else
                    {
                        if (junk.ContainsKey(material))
                        {
                            junk[material] += value;
                        }
                        else
                        {
                            junk.Add(material, value);
                        }
                    }
                }
            }
            Console.WriteLine($"{legendaryItem} obtained!");
            Dictionary<string, int> sortedKeyMaterials = new Dictionary<string, int>();
            Dictionary<string, int> sortedJunk = junk
                .OrderBy(x => x.Key)
                .ToDictionary(a => a.Key, a => a.Value);

            if (keyResources["shards"] == keyResources["fragments"] ||
                keyResources["shards"] == keyResources["motes"] ||
                keyResources["fragments"] == keyResources["motes"])
            {
                sortedKeyMaterials = keyResources
                .OrderByDescending(kvp => kvp.Value)
                .ThenBy(kvp => kvp.Key)
                .ToDictionary(a => a.Key, a => a.Value);

                foreach (var keyMaterial in sortedKeyMaterials)
                {
                    Console.WriteLine($"{keyMaterial.Key}: {keyMaterial.Value}");
                }
            }
            else
            {
                sortedKeyMaterials = keyResources
                .OrderByDescending(kvp => kvp.Value)
                .ToDictionary(a => a.Key, a => a.Value);

                foreach (var keyMaterial in sortedKeyMaterials)
                {
                    Console.WriteLine($"{keyMaterial.Key}: {keyMaterial.Value}");
                }
            }
            foreach (var material in sortedJunk)
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }
        }
    }
}
