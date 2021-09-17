using System;
using System.Collections.Generic;
using System.Linq;

namespace SantasPresentFactory
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Stack<int> materials = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            Queue<int> magic = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            Dictionary<string, int> toys = new Dictionary<string, int>();
            toys.Add("Doll", 0);
            toys.Add("Wooden train", 0);
            toys.Add("Teddy bear", 0);
            toys.Add("Bicycle", 0);

            while (materials.Count > 0 && magic.Count > 0)
            {
                int currentValue = materials.Peek() * magic.Peek();
                bool isCrafted = false;
                if (materials.Peek() == 0)
                {
                    materials.Pop();
                }
                if (magic.Peek() == 0)
                {
                    magic.Dequeue();
                }
                if (currentValue == 150)
                {
                    toys["Doll"]++;
                    isCrafted = true;
                }
                else if (currentValue == 250)
                {
                    toys["Wooden train"]++;
                    isCrafted = true;
                }
                else if (currentValue == 300)
                {
                    toys["Teddy bear"]++;
                    isCrafted = true;
                }
                else if (currentValue == 400)
                {
                    toys["Bicycle"]++;
                    isCrafted = true;
                }
                if (isCrafted)
                {
                    materials.Pop();
                    magic.Dequeue();
                }
                else
                {
                    if (currentValue < 0)
                    {
                        int sum = materials.Pop() + magic.Dequeue();
                        materials.Push(sum);
                    }
                    else if (currentValue > 0)
                    {
                        magic.Dequeue();
                        materials.Push(materials.Pop() + 15);
                    }
                }
                
            }
            if ((toys["Doll"] > 0 && toys["Wooden train"] > 0)
                || (toys["Teddy bear"] > 0 && toys["Bicycle"] > 0))
            {
                Console.WriteLine("The presents are crafted! Merry Christmas!");
            }
            else
            {
                Console.WriteLine("No presents this Christmas!");
            }
            if (materials.Count > 0)
            {
                Console.WriteLine($"Materials left: {string.Join(", ", materials)}");
            }
            if (magic.Count > 0)
            {
                Console.WriteLine($"Magic left: {string.Join(", ", magic)}");
            }
            foreach (var item in toys.OrderBy(x=>x.Key).Where(v =>v.Value >= 1))
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
