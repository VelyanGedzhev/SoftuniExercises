using System;

namespace _1._Ages
{
    class Program
    {
        static void Main(string[] args)
        {
            int age = int.Parse(Console.ReadLine());
            string personType = string.Empty;

            if(age >= 0 && age <= 2)
            {
                personType = "baby";
            }
            else if(age >=3 && age <= 13)
            {
                personType = "child";
            }
            else if(age >= 14 && age <= 19)
            {
                personType = "teenager";
            }
            else if (age >= 20 && age <= 65)
            {
                personType = "adult";
            }
            else
            {
                personType = "elder";
            }
            Console.WriteLine(personType);
        }
    }
}
