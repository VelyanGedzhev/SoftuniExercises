using System;

namespace _4._ArrayRotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine()
                .Split();

            int rotations = int.Parse(Console.ReadLine());

            if(rotations == input.Length)
            {
                Console.WriteLine(String.Join(" ", input));
            }
            else
            {
                for (int i = 0; i < rotations; i++)
                {
                    string temp = input[0];
                    for (int j = 0; j < input.Length - 1; j++)
                    {
                        input[j] = input[j + 1];
                    }
                    input[input.Length - 1] = temp;

                }
                Console.WriteLine(String.Join(" ", input));
            }
            
        }
    }
}
