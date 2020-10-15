using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._BombNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = ReadsNumberSequence();
            List<int> bomb = ReadsBombNumAndPower();
            DetonatesBomb(numbers, bomb);

        }
        static List<int> ReadsNumberSequence()
        {
            List<int> input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            return input;
        }
        static List<int> ReadsBombNumAndPower()
        {
            List<int> input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            return input;
        }
        static void DetonatesBomb(List<int> numbers, List<int> bomb)
        {
            int bombNum = bomb[0];
            int bombPower = bomb[1];
            int bombIndex = numbers.IndexOf(bombNum);

            while (bombIndex != -1)
            {
                int leftExplosion = bombIndex - bombPower;
                int rightExplosion = bombIndex + bombPower;

                if (leftExplosion < 0)
                {
                    leftExplosion = 0;
                }
                if (rightExplosion > numbers.Count -1)
                {
                    rightExplosion = numbers.Count - 1;
                }

                numbers.RemoveRange(leftExplosion, rightExplosion - leftExplosion + 1);
                bombIndex = numbers.IndexOf(bombNum);
            }
            Console.WriteLine(numbers.Sum());
        }
    }
}
