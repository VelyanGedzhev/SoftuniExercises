using System;

namespace _9._Padawan_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {
            double availableMoney = double.Parse(Console.ReadLine());
            int studentsCount = int.Parse(Console.ReadLine());
            double lightsaberPrice = double.Parse(Console.ReadLine());
            double robePrice = double.Parse(Console.ReadLine());
            double beltPrice = double.Parse(Console.ReadLine());

            double additionalLightsabers = Math.Ceiling(studentsCount * 0.1);
            double freeBelts = Math.Floor(studentsCount *1.0 / 6.0);

            double totalSum = (studentsCount + additionalLightsabers) * lightsaberPrice +
                studentsCount * robePrice + (studentsCount - freeBelts) * beltPrice;

            if(totalSum <= availableMoney)
            {
                Console.WriteLine($"The money is enough - it would cost {totalSum:f2}lv.");
            }
            else
            {
                Console.WriteLine($"Ivan Cho will need {totalSum-availableMoney:f2}lv more.");
            }
        }
    }
}
