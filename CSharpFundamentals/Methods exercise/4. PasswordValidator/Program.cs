using System;
using System.Runtime;

namespace _4._PasswordValidator
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = Console.ReadLine();

            if (PasswordLengthValidator(password) && CheckingForSymbols(password) && CheckForMinDigit(password))
            {
                Console.WriteLine("Password is valid");
            }
            else
            {
                if (!PasswordLengthValidator(password))
                {
                    Console.WriteLine("Password must be between 6 and 10 characters");
                }
                if (!CheckingForSymbols(password))
                {
                    Console.WriteLine("Password must consist only of letters and digits");
                }
                if (!CheckForMinDigit(password))
                {
                    Console.WriteLine("Password must have at least 2 digits");
                }
            }
           
        }
        static bool PasswordLengthValidator(string input)
        {
            bool isLongEnough = true;

            if(input.Length < 6 || input.Length > 10)
            {
                isLongEnough = false;
            }
            return isLongEnough;
        }
        static bool CheckingForSymbols(string input)
        {
            bool isCorrect = true;

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];
                if (!Char.IsLetterOrDigit(currentChar))
                {
                    isCorrect = false;
                }
            }
            return isCorrect;
        }
        static bool CheckForMinDigit(string input)
        {
            int counter = 0;
            bool areDigitsEnough = false;

            for (int i = 0; i < input.Length; i++)
            {
                char currenChar = input[i];

                if (char.IsDigit(currenChar))
                {
                    counter++;
                }
            }

            if(counter >= 2)
            {
                areDigitsEnough = true;
            }

            return areDigitsEnough;
        }
    }
}
