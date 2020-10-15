using System;

namespace _6._MiddleCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            GetMiddleCharacters(input);
        }
        static void GetMiddleCharacters (string input)
        {
            if(input.Length % 2 == 0) 
            {
                Console.WriteLine((input[(input.Length / 2) - 1]).ToString()+
                    (input[input.Length / 2]).ToString());
            }
            else
            {
                Console.WriteLine((input[(input.Length - 1) / 2]).ToString());
            }
        }

    }
}
