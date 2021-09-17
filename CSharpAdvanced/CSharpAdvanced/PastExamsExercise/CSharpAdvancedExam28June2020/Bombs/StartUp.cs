using System;
using System.Collections.Generic;
using System.Linq;


namespace Bombs
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> bombs = new Dictionary<string, int>();

            int[] bombEffectsInfo = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] bombCasingInfo = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> bombCasings = new Stack<int>(bombCasingInfo);
            Queue<int> bombEffects = new Queue<int>(bombEffectsInfo);
            bool isFull = false;
            bool materialsLeft = true;
            bombs.Add("Smoke Decoy Bombs", 0);
            bombs.Add("Cherry Bombs", 0);
            bombs.Add("Datura Bombs", 0);

            while (isFull == false && materialsLeft == true)
            {
                int currentSum = bombEffects.Peek() + bombCasings.Peek();

                if (currentSum == 120)
                {
                    //if (!bombs.ContainsKey("Smoke Decoy Bombs"))
                    //{
                    //    bombs.Add("Smoke Decoy Bombs", 0);
                    //}
                    bombs["Smoke Decoy Bombs"]++;
                    bombEffects.Dequeue();
                    bombCasings.Pop();
                }
                else if (currentSum == 60)
                {
                    //if (!bombs.ContainsKey("Cherry Bomb"))
                    //{
                    //    bombs.Add("Cherry Bomb", 0);
                    //}
                    bombs["Cherry Bombs"]++;
                    bombEffects.Dequeue();
                    bombCasings.Pop();
                }
                else if (currentSum == 40)
                {
                    //if (!bombs.ContainsKey("Datura Bomb"))
                    //{
                    //    bombs.Add("Datura Bomb", 0);
                    //}
                    bombs["Datura Bombs"]++;
                    bombEffects.Dequeue();
                    bombCasings.Pop();
                }
                else
                {
                    int newCasingValue = bombCasings.Pop() - 5;
                    bombCasings.Push(newCasingValue);
                }
                if (bombEffects.Count < 1 || bombCasings.Count < 1)
                {
                    materialsLeft = false;
                }
                if (bombs["Datura Bombs"] >= 3 
                    && bombs["Cherry Bombs"] >= 3
                    && bombs["Smoke Decoy Bombs"] >= 3)
                {
                    isFull = true;
                }

            }
            if (isFull)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }
            if (bombEffects.Count > 0)
            {
                List<int> effectsLeft = new List<int>();
                while (bombEffects.Count != 0)
                {
                    effectsLeft.Add(bombEffects.Dequeue());
                }
                Console.WriteLine($"Bomb Effects: {string.Join(", ",effectsLeft)}");
            }
            else
            {
                Console.WriteLine("Bomb Effects: empty");
            }
            if (bombCasings.Count > 0)
            {
                List<int> casingsLeft = new List<int>();
                while (bombCasings.Count != 0)
                {
                    casingsLeft.Add(bombCasings.Pop());
                }
                Console.WriteLine($"Bomb Casings: {string.Join(", ", casingsLeft)}");
            }
            else
            {
                Console.WriteLine("Bomb Casings: empty");
            }

            foreach (var bomb in bombs.OrderBy(x =>x.Key))
            {
                Console.WriteLine($"{bomb.Key}: {bomb.Value}");
            }

        }

    }
}
