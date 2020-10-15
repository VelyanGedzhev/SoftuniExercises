using System;
using System.Runtime.ExceptionServices;

namespace _9._GreaterOfTwoValues
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            if(type == "int")
            {
                int firstNum = int.Parse(Console.ReadLine());
                int secondNum = int.Parse(Console.ReadLine());
                Console.WriteLine(ReturnBiggerValue(firstNum, secondNum));
            }
            else if (type == "char")
            {
                char firstChar = char.Parse(Console.ReadLine());
                char secondChar = char.Parse(Console.ReadLine());
                Console.WriteLine(ReturnBiggerValue(firstChar, secondChar));
            }
            else if (type == "string")
            {
                string firstString = Console.ReadLine();
                string secondString = Console.ReadLine();
                Console.WriteLine(ReturnBiggerValue(firstString, secondString));
            }
        }
        static string ReturnBiggerValue(string firstString,string secondString)
        {
            int compare = firstString.CompareTo(secondString);
            if(compare > 0)
            {
                return firstString;
            }
            else
            {
                return secondString;
            }
        }
        static int ReturnBiggerValue(int firstNum, int secondNum)
        {
            int compare = firstNum.CompareTo(secondNum);
            if(compare > 0)
            {
                return firstNum;
            }
            else
            {
                return secondNum;
            }
        }
        static char ReturnBiggerValue(char firstChar, char secondChar)
        {
            int compare = firstChar.CompareTo(secondChar);
            if(compare > 0)
            {
                return firstChar;
            }
            else
            {
                return secondChar;
            }
        }

    }
}
