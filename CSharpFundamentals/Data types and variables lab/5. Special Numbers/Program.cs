using System;

namespace _5._Special_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());

            for (int i = 1; i <= num; i++)
            {
                bool isTrue = false;
                int temp = 0;
                int sum = 0;
                temp = i;
                while(temp != 0)
                {
                    sum += temp % 10;
                    temp /= 10;
                }
                if(sum == 5 || sum == 7 || sum == 11)
                {
                    isTrue = true;
                }
                Console.WriteLine($"{i} -> {isTrue}");
            }
        }
    }
}
