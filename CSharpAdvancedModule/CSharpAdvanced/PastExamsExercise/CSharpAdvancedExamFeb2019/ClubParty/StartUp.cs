using System;
using System.Collections.Generic;
using System.Linq;

namespace ClubParty
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int maxCapacity = int.Parse(Console.ReadLine());
            
            Stack<string> inputData = new Stack<string>(Console.ReadLine().Split());
            Queue<char> halls = new Queue<char>();
            List<int> people = new List<int>();
            int currentCapacity = 0;

            while (inputData.Count > 0)
            {
                var currentElement = inputData.Pop();

                if (Char.IsLetter(currentElement[0]))
                {
                    halls.Enqueue(char.Parse(currentElement));
                }
                else
                {
                    if (halls.Count < 1)
                    {
                        continue;
                    }
                    if (currentCapacity + int.Parse(currentElement) > maxCapacity)
                    {
                        Console.WriteLine($"{halls.Dequeue()} -> {string.Join(", ", people)}");
                        currentCapacity = 0;
                        people.Clear();
                    }
                    if (halls.Count > 0)
                    {
                        people.Add(int.Parse(currentElement));
                        currentCapacity += int.Parse(currentElement);
                    }
                }
               
            }

        }
    }
}
