using System;

namespace _2._CommonElements
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr1 = Console.ReadLine()
                .Split();
            string[] arr2 = Console.ReadLine()
                .Split();

            string commonElements = string.Empty;

            for (int i = 0; i < arr1.Length; i++)
            {
                for (int j = 0; j < arr2.Length; j++)
                {
                    if(arr1[i] == arr2[j])
                    {
                        commonElements += arr2[j] + " ";
                    }
                }
            }
            Console.WriteLine(commonElements);       
        }
    }
}
