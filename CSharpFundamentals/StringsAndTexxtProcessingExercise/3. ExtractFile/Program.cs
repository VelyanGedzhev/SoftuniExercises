using System;
using System.IO;
using System.Linq;

namespace _3._ExtractFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string[] filePath = input
                .Split('\\')
                .ToArray();

            foreach (string item in filePath)
            {
                if (item.Contains('.')) //По-добре да се използваа последния елемент, 
                                        //вместо '.' за да не се вземе "папка".
                {
                    string[] result = item
                        .Split('.')
                        .ToArray();

                    Console.WriteLine($"File name: {result[0]}");
                    Console.WriteLine($"File extension: {result[1]}");
                    break;
                }
            }
        }
    }
}
