using System;
using System.Linq;
using System.Text;

namespace _5._MultiplyBigNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstNumber = Console.ReadLine();
            int secondNumber = int.Parse(Console.ReadLine());

            if (secondNumber == 0)
            {
                Console.WriteLine(0);
                return;
            }

            while (firstNumber[0] == '0')
            {
                firstNumber = firstNumber.Substring(1);
            }

            StringBuilder sb = new StringBuilder();
            int reminder = 0;

            for (int i = firstNumber.Length - 1; i >= 0; i--)
            {
                int result = int.Parse(firstNumber[i].ToString()) * secondNumber + reminder;
                reminder = 0;

                if (result > 9)
                {
                    reminder = result / 10;
                    result %= 10;
                }

                sb.Append(result);
            }
            if (reminder != 0)
            {
                sb.Append(reminder);
            }
            StringBuilder output = new StringBuilder();

            for (int i = sb.Length - 1; i >= 0; i--)
            {
                output.Append(sb[i]);
            } 
            Console.WriteLine(output);
        }
    }
}
