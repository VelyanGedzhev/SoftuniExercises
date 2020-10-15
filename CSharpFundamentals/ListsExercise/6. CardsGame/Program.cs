using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._CardsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayer = ReadsPlayersDeck();
            List<int> secondPlayer = ReadsPlayersDeck();

            while (firstPlayer.Count != 0 && secondPlayer.Count != 0)
            {

                    if (firstPlayer[0] > secondPlayer[0])
                    {
                        firstPlayer.Add(firstPlayer[0]);
                        firstPlayer.Add(secondPlayer[0]);
                        firstPlayer.RemoveAt(0);
                        secondPlayer.RemoveAt(0);

                    }
                    else if (firstPlayer[0] < secondPlayer[0])
                    {
                        secondPlayer.Add(secondPlayer[0]);
                        secondPlayer.Add(firstPlayer[0]);
                        firstPlayer.RemoveAt(0);
                        secondPlayer.RemoveAt(0);

                    }
                    else
                    {
                        firstPlayer.RemoveAt(0);
                        secondPlayer.RemoveAt(0);
                    }
            }
            if (firstPlayer.Count > secondPlayer.Count)
            {
                Console.WriteLine($"First player wins! Sum: {firstPlayer.Sum()}");
            }
            else
            {
                Console.WriteLine($"Second player wins! Sum: {secondPlayer.Sum()}");
            }
        }
        static List<int> ReadsPlayersDeck()
        {
            List<int> cards = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            return cards;
        }
        //static void FirstPlayerWinsRound(List<int> firstPlayer, List<int> secondPlayer)
        //{
        //    firstPlayer.Add(firstPlayer[i])
        //}
    }
}
