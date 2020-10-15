using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace _6._ReplaceRepeatingChars
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();


            for (int i = 0; i < input.Length; i++)
            {
                int counter = 0;

                for (int j = i + 1; j < input.Length; j++)
                {
                    if (input[i] == input[j])
                    {
                        counter++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (counter > 0)
                {
                    input = input.Remove(i, counter);
                    
                }
            }
            Console.WriteLine(input);
        }     
    }
}
