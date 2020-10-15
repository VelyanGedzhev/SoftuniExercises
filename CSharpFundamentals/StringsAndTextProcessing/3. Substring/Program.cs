using System;

namespace _3._Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();
            string text = Console.ReadLine();
            int startIndex = text.IndexOf(word);

            while (startIndex != -1)
            {
                text = text.Remove(startIndex, word.Length);
                startIndex = text.IndexOf(word);
            }
            Console.WriteLine(text);
        }
    }
}
