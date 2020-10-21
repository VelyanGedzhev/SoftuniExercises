using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowerWreaths
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int[] liliesSequence = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] rosesSequence = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Stack<int> lilies = new Stack<int>(liliesSequence);
            Queue<int> roses = new Queue<int>(rosesSequence);

            int wreathsCounter = 0;
            int storedSum = 0;

            while (lilies.Count > 0 && roses.Count > 0)
            {
                if (lilies.Peek() + roses.Peek() == 15)
                {
                    wreathsCounter++;
                    lilies.Pop();
                    roses.Dequeue();
                }
                else if (lilies.Peek() + roses.Peek() > 15)
                {
                    int currentLily = lilies.Pop() - 2;
                    lilies.Push(currentLily);
                }
                else
                {
                    storedSum += (lilies.Pop() + roses.Dequeue());
                }
            }
            if (storedSum >= 15)
            {
                wreathsCounter += (int)Math.Floor(storedSum / 15.0);
            }
            if (wreathsCounter >= 5)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreathsCounter} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {5 - wreathsCounter} wreaths more!");
            }
        }
    }
}
