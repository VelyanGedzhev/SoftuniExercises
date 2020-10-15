using System;
using System.Linq;
using System.Text;

namespace _11._ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] command = input.Split();

                if (command[0] == "exchange")
                {
                    int index = int.Parse(command[1]);

                    if (index < 0 || index > arr.Length - 1)
                    {
                        Console.WriteLine("Invalid index");
                        continue;
                    }
                    ExchangeArr(arr, index);
                }
                else if (command[0] == "max")
                {
                    if (command[1] == "even")
                    {
                        if (MaxEven(arr) == -1)
                        {
                            Console.WriteLine("No matches");
                            continue;
                        }

                        Console.WriteLine(MaxEven(arr));
                    }
                    else
                    {
                        if (MaxOdd(arr) == -1)
                        {
                            Console.WriteLine("No matches");
                            continue;
                        }
                        
                        Console.WriteLine(MaxOdd(arr));
                    }
                }
                else if (command[0] == "min")
                {
                    if (command[1] == "even")
                    {
                        if (MaxEven(arr) == -1)
                        {
                            Console.WriteLine("No matches");
                            continue;
                        }
                        Console.WriteLine(MinEven(arr));
                    }
                    else if (command[1] == "odd")
                    {
                        if (MaxEven(arr) == -1)
                        {
                            Console.WriteLine("No matches");
                            continue;
                        }
                        Console.WriteLine(MinOdd(arr));
                    }
                }
                else if (command[0] == "first")
                {
                    int count = int.Parse(command[1]);
                    if (count > arr.Length)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }
                    if (command[2] == "even")
                    {
                        FirstEven(arr,count);
                    }
                    else if(command[2] == "odd")
                    {
                        FirstOdd(arr, count);
                    }
                }
                else if (command[0] == "last")
                {
                    int count = int.Parse(command[1]);
                    if (count > arr.Length)
                    {
                        Console.WriteLine("Invalid count");
                        continue;
                    }
                    if (command[2] == "even")
                    {
                        LastEven(arr, count);
                    }
                    else if (command[2] == "odd")
                    {
                        LastOdd(arr, count);
                    }
                }

            }
        }
        static void ExchangeArr(int[] array, int index)
        {
            int[] arr1 = new int[array.Length - index - 1];
            int[] arr2 = new int[index + 1];
            int arr1Counter = 0;

            for (int i = index + 1; i < array.Length; i++)
            {
                arr1[arr1Counter] = array[i];
                arr1Counter++;
            }

            for (int i = 0; i <= index; i++)
            {
                arr2[i] = array[i];
            }

            for (int i = 0; i < arr1.Length; i++)
            {
                array[i] = arr1[i];
            }

            for (int i = 0; i < arr2.Length; i++)
            {
                array[arr1.Length + i] = arr2[i];
            }
            Console.WriteLine($"[{String.Join(", ", array)}]");
        }
        static int MaxEven(int[] array)
        {
            int maxEven = int.MinValue;
            int index = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    if (array[i] >= maxEven)
                    {
                        maxEven = array[i];
                        index = i;
                    }
                }
            }
            return index;
        }
        static int MaxOdd(int[] array)
        {
            int maxOdd = int.MinValue;
            int index = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    if (array[i] >= maxOdd)
                    {
                        maxOdd = array[i];
                        index = i;
                    }
                }
            }
            return index;
        }
        static int MinEven(int[] array)
        {
            int minEven = int.MaxValue;
            int index = -1;

            for (int i = 0; i < array.Length; i++)
            {

                if (array[i] % 2 == 0)
                {

                    if (array[i] <= minEven)
                    {
                        minEven = array[i];
                        index = i;
                    }

                }
                
            }
            
            return index;
        }
        static int MinOdd(int[] array)
        {
            int MidOdd = int.MaxValue;
            int index = -1;

            for (int i = 0; i < array.Length; i++)
            {

                if (array[i] % 2  != 0)
                {

                    if (array[i] <= MidOdd)
                    {
                        MidOdd = array[i];
                        index = i;
                    }

                }
            }

            return index;
        }
        static void FirstEven(int[] array, int count)
        {
            string numbers = String.Empty;
            int counter = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 == 0)
                {
                    numbers += array[i] + " ";
                    counter++;
                }

                if (counter == count)
                {
                    break;
                }
            }

            var result = numbers.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (counter == 0)
            {
                Console.WriteLine("[]");
            }
            else
            {
                Console.WriteLine("[" + String.Join(", ", result) + "]");
            }
        }
        static void FirstOdd(int[] array, int count)
        {
            string numbers = String.Empty;
            int counter = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] % 2 != 0)
                {
                    numbers += array[i] + " ";
                    counter++;
                }

                if (counter == count)
                {
                    break;
                }
            }

            var result = numbers.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (counter == 0)
            {
                Console.WriteLine("[]");
            }
            else
            {
                Console.WriteLine("[" + String.Join(", ", result) + "]");
            }
        }
        static void LastEven(int[] array, int count)
        {
            StringBuilder numbers = new StringBuilder();
            int counter = 0;

            for (int i = 0; i < array.Length - 1; i++)
            {

                if (array[i] % 2 == 0)
                {
                    counter++;
                    numbers.Append(array[i] + " ");
                }

                if (counter == count)
                {
                    break;
                }
            }

            if (counter == 0)
            {
                Console.WriteLine("[]");
            }
            else
            {
                Console.WriteLine($"[{numbers.ToString()}]");
            }
        }
        static void LastOdd(int[] array, int count)
        {
            StringBuilder numbers = new StringBuilder();
            int counter = 0;

            for (int i = 0; i < array.Length - 1; i++)
            {

                if (array[i] % 2 != 0)
                {
                    counter++;
                    numbers.Append(array[i]);
                }

                if (counter == count)
                {
                    break;
                }
            }

            if (counter == 0)
            {
                Console.WriteLine("[]");
            }
            else
            {
                Console.WriteLine($"[{numbers.ToString()}]");
            }
        }
//---------------------------------Sanya-----------------------------------------//

//        static void Main()
//        {
//            int[] arr = Console.ReadLine()
//                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
//                .Select(int.Parse)
//                .ToArray();

//            string input = String.Empty;
//            while ((input = Console.ReadLine()) != "end")
//            {
//                string[] command = input.Split();


//                if (command[0] == "exchange")
//                {
//                    int index = int.Parse(command[1]);

//                    if (index < 0 || index > arr.Length - 1)
//                    {
//                        Console.WriteLine("Invalid index");
//                        continue;
//                    }

//                    Exchange(arr, index);
//                }
//                else if (command[0] == "max")
//                {
//                    if (command[1] == "even")
//                    {
//                        if (MaxEven(arr) == -1)
//                        {
//                            Console.WriteLine("No matches");
//                            continue;
//                        }
//                        Console.WriteLine(MaxEven(arr));
//                    }
//                    else
//                    {
//                        if (MaxOdd(arr) == -1)
//                        {
//                            Console.WriteLine("No matches");
//                            continue;
//                        }
//                        Console.WriteLine(MaxOdd(arr));
//                    }
//                }
//                else if (command[0] == "min")
//                {
//                    if (command[1] == "even")
//                    {
//                        if (MinEven(arr) == -1)
//                        {
//                            Console.WriteLine("No matches");
//                            continue;
//                        }
//                        Console.WriteLine(MinEven(arr));
//                    }
//                    else
//                    {
//                        if (MinOdd(arr) == -1)
//                        {
//                            Console.WriteLine("No matches");
//                            continue;
//                        }
//                        Console.WriteLine(MinOdd(arr));
//                    }
//                }
//                else if (command[0] == "first")
//                {
//                    int count = int.Parse(command[1]);

//                    if (count > arr.Length)
//                    {
//                        Console.WriteLine("Invalid count");
//                        continue;
//                    }

//                    if (command[2] == "even")
//                    {
//                        ReturnFirstEven(arr, count);
//                    }
//                    else
//                    {
//                        ReturnFirstOdd(arr, count);
//                    }

//                }
//                else if (command[0] == "last")
//                {
//                    int count = int.Parse(command[1]);

//                    if (count > arr.Length)
//                    {
//                        Console.WriteLine("Invalid count");
//                        continue;
//                    }
//                    if (command[2] == "even")
//                    {
//                        ReturnLastEven(arr, count);
//                    }
//                    else
//                    {
//                        ReturnLastOdd(arr, count);
//                    }

//                }
//            }

//            Console.WriteLine("[" + String.Join(", ", arr) + "]");
//        }


//        static void Exchange(int[] array, int index)
//        {
//            int[] firstArray = new int[array.Length - index - 1];
//            int[] secondArray = new int[index + 1];

//            int firstArrCounter = 0;
//            for (int i = index + 1; i < array.Length; i++)
//            {
//                firstArray[firstArrCounter] = array[i];
//                firstArrCounter++;
//            }

//            for (int i = 0; i < index + 1; i++)
//            {
//                secondArray[i] = array[i];
//            }

//            for (int i = 0; i < firstArray.Length; i++)
//            {
//                array[i] = firstArray[i];
//            }

//            for (int i = 0; i < secondArray.Length; i++)
//            {
//                array[firstArray.Length + i] = secondArray[i];
//            }
//        }

//        static int MaxEven(int[] array)
//        {
//            int maxEven = int.MinValue;
//            int index = -1;

//            for (int i = 0; i < array.Length; i++)
//            {
//                if (array[i] % 2 == 0)
//                {
//                    if (array[i] >= maxEven)
//                    {
//                        maxEven = array[i];
//                        index = i;
//                    }
//                }
//            }
//            return index;
//        }

//        static int MaxOdd(int[] array)
//        {
//            int maxOdd = int.MinValue;
//            int index = -1;

//            for (int i = 0; i < array.Length; i++)
//            {
//                if (array[i] % 2 != 0)
//                {
//                    if (array[i] >= maxOdd)
//                    {
//                        maxOdd = array[i];
//                        index = i;
//                    }
//                }
//            }
//            return index;
//        }
//        static int MinEven(int[] array)
//        {
//            int minEven = int.MaxValue;
//            int index = -1;

//            for (int i = 0; i < array.Length; i++)
//            {
//                if (array[i] % 2 == 0)
//                {
//                    if (array[i] <= minEven)
//                    {
//                        minEven = array[i];
//                        index = i;
//                    }
//                }
//            }
//            return index;
//        }
//        static int MinOdd(int[] array)
//        {
//            int minOdd = int.MaxValue;
//            int index = -1;

//            for (int i = 0; i < array.Length; i++)
//            {
//                if (array[i] % 2 != 0)
//                {
//                    if (array[i] <= minOdd)
//                    {
//                        minOdd = array[i];
//                        index = i;
//                    }
//                }
//            }
//            return index;
//        }

//        static void ReturnFirstEven(int[] array, int count)
//        {
//            string numbers = String.Empty;
//            int counter = 0;

//            for (int i = 0; i < array.Length; i++)
//            {
//                if (array[i] % 2 == 0)
//                {
//                    numbers += array[i] + " ";
//                    counter++;
//                }

//                if (counter == count)
//                {
//                    break;
//                }
//            }

//            var result = numbers.Split(' ', StringSplitOptions.RemoveEmptyEntries);

//            if (counter == 0)
//            {
//                Console.WriteLine("[]");
//            }
//            else
//            {
//                Console.WriteLine("[" + String.Join(", ", result) + "]");
//            }
//        }

//        static void ReturnFirstOdd(int[] array, int count)
//        {
//            string numbers = String.Empty;
//            int counter = 0;

//            for (int i = 0; i < array.Length; i++)
//            {
//                if (array[i] % 2 != 0)
//                {
//                    numbers += array[i] + " ";
//                    counter++;
//                }

//                if (counter == count)
//                {
//                    break;
//                }
//            }

//            var result = numbers.Split(' ', StringSplitOptions.RemoveEmptyEntries);

//            if (counter == 0)
//            {
//                Console.WriteLine("[]");
//            }
//            else
//            {
//                Console.WriteLine("[" + String.Join(", ", result) + "]");
//            }
//        }

//        static void ReturnLastEven(int[] array, int count)
//        {
//            string numbers = String.Empty;
//            int counter = 0;

//            for (int i = array.Length - 1; i >= 0; i--)
//            {
//                if (array[i] % 2 == 0)
//                {
//                    counter++;
//                    numbers += array[i] + " ";
//                }

//                if (counter == count)
//                {
//                    break;
//                }
//            }

//            var result = numbers.Split(' ', StringSplitOptions.RemoveEmptyEntries).Reverse();

//            if (counter == 0)
//            {
//                Console.WriteLine("[]");
//            }
//            else
//            {
//                Console.WriteLine("[" + String.Join(", ", result) + "]");
//            }

//        }

//        static void ReturnLastOdd(int[] array, int count)
//        {
//            string numbers = String.Empty;
//            int counter = 0;

//            for (int i = array.Length - 1; i >= 0; i--)
//            {
//                if (array[i] % 2 != 0)
//                {
//                    counter++;
//                    numbers += array[i] + " ";
//                }

//                if (counter == count)
//                {
//                    break;
//                }
//            }

//            var result = numbers.Split(' ', StringSplitOptions.RemoveEmptyEntries).Reverse();

//            if (counter == 0)
//            {
//                Console.WriteLine("[]");
//            }
//            else
//            {
//                Console.WriteLine("[" + String.Join(", ", result) + "]");
//            }

//        }
//    }
    }
}
