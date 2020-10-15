using System;

namespace GenericArrayCreator
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string[] array = ArrayCreator.Create(5, "pesho");

            Console.WriteLine(array.Length);
            Console.WriteLine(string.Join(", ", array));
        }
    }
}
