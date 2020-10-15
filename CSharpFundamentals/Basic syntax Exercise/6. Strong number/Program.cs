using System;

namespace _6._Strong_number
{
    class Program
    {
        static void Main(string[] args)
        {
            int num = int.Parse(Console.ReadLine());
            int currentNum = num;
            string strNum = "";
            strNum += num;
            int sum = 0;

            for (int i = 0; i < strNum.Length; i++)
            {
                int currentDigit = currentNum % 10;
                currentNum = (currentNum - currentDigit) / 10;
                int factorial = 1;

                for (int j = 1; j <= currentDigit; j++)
                {
                    factorial *= j;
                }
                sum += factorial;
            }
            if(sum == num)
            {
                Console.WriteLine("yes");
            }
            else
            {
                Console.WriteLine("no");
            }
        }
    //    int num = int.Parse(Console.ReadLine());
    //    int tempNum = num;
    //    int factorialSum = 0;

    //        while(tempNum > 0)
    //        {
    //            int digit = tempNum % 10;
    //    tempNum /= 10;
    //            int currentFactorialSum = 1;
    //            for(int i = 1; i <= digit; i++)
    //            {
    //                currentFactorialSum *= i;
    //            }
    //factorialSum += currentFactorialSum;
    //        }
    //        if (factorialSum == num)
    //        {
    //            Console.WriteLine("yes");
    //        }
    //        else
    //        {
    //            Console.WriteLine("no");
    //        }
    }
}
