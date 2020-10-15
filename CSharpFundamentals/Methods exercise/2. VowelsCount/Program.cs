using System;

namespace _2._VowelsCount
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(VowelsCount(Console.ReadLine()));
        }
        static int VowelsCount (string input)
        {
            int vowelsCount = 0;
            string vowels = "aAeEiIoOuU";

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];

                for (int j = 0; j < vowels.Length; j++)
                {
                    if(currentChar == vowels[j])
                    {
                        vowelsCount++;
                    }
                }

            }
            return vowelsCount;
        }
    }
}
