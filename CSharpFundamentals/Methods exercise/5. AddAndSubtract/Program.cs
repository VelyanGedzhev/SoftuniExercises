using System;

namespace _5._AddAndSubtract
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            Console.WriteLine(SumOfIntegers(a,b)-SubtractFromSum(c));
        }
        static int SumOfIntegers(int a, int b)
        {
            int result = a + b;
            return result;
        }
        static int SubtractFromSum(int a)
        {
            return a;
        }
    }
}
