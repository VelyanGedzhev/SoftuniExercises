using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace _3.WordCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> occurances = new Dictionary<string, int>();

            using (StreamReader text = new StreamReader("../../../text.txt"))
            {
                using (StreamReader words = new StreamReader("../../../words.txt"))
                {
                    string[] allWords = words.ReadLine().Split();
                    //string[] fullText = text.ReadLine().Split();
                    string line = text.ReadLine();
                    StringBuilder allLines = new StringBuilder();
                    while (line != null)
                    {
                        allLines.Append(line + " " );
                        line = text.ReadLine();
                    }
                    string[] fullText = allLines.ToString().Split();
                    for (int i = 0; i < allWords.Length; i++)
                    {
                        string currentWord = allWords[i];

                        if (!occurances.ContainsKey(currentWord))
                        {
                            occurances.Add(currentWord, 0);
                        }

                        for (int j = 0; j < fullText.Length; j++)
                        {
                            if (currentWord.ToLower() == fullText[j].ToLower())
                            {
                                occurances[currentWord]++;
                            }
                        }
                    }
                }
                using (StreamWriter writer = new StreamWriter("../../../output.txt"))
                {
                    foreach (var word in occurances.OrderByDescending(x => x.Value))
                    {
                        writer.WriteLine($"{word.Key} - {word.Value}");
                    }
                }
            }
        }
    }
}
