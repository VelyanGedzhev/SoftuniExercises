using System;
using System.IO;
using System.Linq;

namespace _2.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("../../../../text.txt");
            string[] newLines = new string[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                int countOfLetters = CountOfLetters(line);
                int countOfSymbols = CountOfSymbols(line);

                newLines[i] = $"Line {i + 1}: {line} ({countOfLetters})({countOfSymbols})";
            }
            File.WriteAllLines("../../../output.txt", newLines);
        }
        public static int CountOfLetters(string line)
        {
            int counter = 0;
            for (int i = 0; i < line.Length; i++)
            {
                char currentSymbol = line[i];
                if (char.IsLetter(currentSymbol))
                {
                    counter++;
                }
            }
            return counter;
        }
        public static int CountOfSymbols (string line)
        {
            char[] symbols = { '-', ',', '.', '!', '?','\'', ';', ':'};
            int counter = 0;
            for (int i = 0; i < line.Length; i++)
            {
                char currentSymbol = line[i];

                if (symbols.Contains(currentSymbol))
                {
                    counter++;
                }
            }
            return counter;
        }
    }
}
