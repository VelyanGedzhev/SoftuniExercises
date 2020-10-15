using System;
using System.Text;

namespace _7._StringExplosion
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder sb = new StringBuilder();
            int power = 0;

            for (int i = 0; i < input.Length; i++)
            {
                char currentChar = input[i];

                if (currentChar == '>')
                {
                    power += int.Parse(input[i + 1].ToString());
                    sb.Append(currentChar);
                }
                else if(power == 0)
                {
                    sb.Append(currentChar);
                }
                else
                {
                    power--;
                }
            }
            Console.WriteLine(sb);
        }
    }
}
