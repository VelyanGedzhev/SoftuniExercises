using System;
using System.Text;

namespace _4._CeasarCipher
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            char[] arr = input
                .ToCharArray();
            StringBuilder sb = new StringBuilder();
            foreach (char symbol in arr)
            {
                int encryptedChar =(int)symbol + 3;
                sb.Append((char)encryptedChar);
            }
            Console.WriteLine(sb);
        }
    }
}
