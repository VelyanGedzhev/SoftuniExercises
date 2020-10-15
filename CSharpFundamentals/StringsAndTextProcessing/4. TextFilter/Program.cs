﻿using System;
using System.Linq;

namespace _4._TextFilter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] bannedWords = Console.ReadLine()
                .Split(", ")
                .ToArray();

            string text = Console.ReadLine();


            for (int i = 0; i < bannedWords.Length; i++)
            {
                text = text.Replace(bannedWords[i], new string('*', bannedWords[i].Length));
            }
            Console.WriteLine(text);
        }
    }
}
