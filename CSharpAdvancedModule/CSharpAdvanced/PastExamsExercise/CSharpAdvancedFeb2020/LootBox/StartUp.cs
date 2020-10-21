using System;
using System.Collections.Generic;
using System.Linq;

namespace LootBox
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Queue<int> firstLootBox = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Stack<int> secondLootBox = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int lootedSum = 0;

            while (firstLootBox.Count > 0 && secondLootBox.Count > 0)
            {
                int currentSum = firstLootBox.Peek() + secondLootBox.Peek();

                if (currentSum % 2 == 0)
                {
                    lootedSum += (firstLootBox.Dequeue() + secondLootBox.Pop());
                }
                else
                {
                    firstLootBox.Enqueue(secondLootBox.Pop());
                }
            }
            if (firstLootBox.Count < 1)
            {
                Console.WriteLine("First lootbox is empty");
            }
            else
            {
                Console.WriteLine("Second lootbox is empty");
            }
            if (lootedSum >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {lootedSum}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {lootedSum}");
            }
        }
    }
}
