using System;
using System.Linq;
using System.Text;

namespace _2._RepeatStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split()
                .ToArray();
            StringBuilder text = new StringBuilder();
            foreach (string word in input)
            {
                for (int i = 0; i < word.Length; i++)
                {
                    text.Append(word);   
                }
            }
            string result = text.ToString();
            Console.WriteLine(result);
        }
    }
}
