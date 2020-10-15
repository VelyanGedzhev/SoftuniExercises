using System;

namespace _1._SmallestOfThreeNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int firstNumber = int.Parse(Console.ReadLine());
            int secondNumber = int.Parse(Console.ReadLine());
            int thirdNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(GetSmallestNumber(firstNumber,secondNumber,thirdNumber));
        }
        static int GetSmallestNumber (int first, int second, int third)
        {

            int minValue = int.MaxValue;
            int[] arr = new int[] { first, second, third };

            foreach (int number in arr)
            {
                if (number < minValue)
                {
                    minValue = number;
                }
            }
//----------------------------------------------------------------------------------//
            //int minValue = int.MaxValue;
            //int[] arr = new int[] { first, second, third };

            //for (int i = 0; i < arr.Length; i++)
            //{
            //    int compare = arr[i].CompareTo(minValue);

            //    if (compare < 0)
            //    {
            //        minValue = arr[i];
            //    }
            //}
//----------------------------------------------------------------------------------//
            //int minValue = int.MaxValue;
            //int[] arr = new int[] { first, second, third };

            //for (int i = 0; i < arr.Length; i++)
            //{
            //    if(arr[i] < minValue)
            //    {
            //        minValue = arr[i];
            //    }
            //}

            return minValue;
        }
    }
}
