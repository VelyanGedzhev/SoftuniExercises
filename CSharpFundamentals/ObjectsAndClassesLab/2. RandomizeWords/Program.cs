using System;

namespace _2._RandomizeWords
{
    class Program
    {
        static void Main(string[] args)
        {
            Randomizer randomizer = new Randomizer();
            randomizer.Words = Console.ReadLine().Split();
            randomizer.Randomise();
            randomizer.PrintWords();
        }
    }
    public class Randomizer
    {
        public string[] Words;

        public void Randomise()
        {
            Random rand = new Random();
            for (int i = 0; i < Words.Length; i++)
            {
                int randomPosition = rand.Next(0, Words.Length);
                string temp = Words[i];
                Words[i] = Words[randomPosition];
                Words[randomPosition] = temp;
            }
        }

        public void PrintWords()
        {
            Console.WriteLine(String.Join(Environment.NewLine, Words));
        }
    }
}
