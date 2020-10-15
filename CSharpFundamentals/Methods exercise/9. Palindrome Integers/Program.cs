using System;
using System.Text;

namespace _9._Palindrome_Integers
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            while (input != "END")
            {
                Console.WriteLine(GetPalindrome(input).ToString().ToLower());
                input = Console.ReadLine();
            }
        }
        static bool GetPalindrome(string input)
        {
            bool isPalindrome = false;
            string result = string.Empty;

            for (int i = input.Length - 1; i >= 0; i--)
            {
                result += input[i];
            }

            if(result == input)
            {
                isPalindrome = true;
            }
            return isPalindrome;
        }
    }
}
