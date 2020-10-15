using System;

namespace _1._FirstTask
{
    class Program
    {
        static void Main(string[] args)
        {
            int studentsCount = int.Parse(Console.ReadLine());
            int lecturesCount = int.Parse(Console.ReadLine());
            int initialBonus = int.Parse(Console.ReadLine());
            double maxBonusPoints = 0;
            int maxAttendances = 0;

            for (int i = 0; i < studentsCount; i++)
            {
                int studentAttendances = int.Parse(Console.ReadLine());
                double currentBonus = (studentAttendances * 1.0 / lecturesCount) * (5 + initialBonus);

                if (currentBonus > maxBonusPoints)
                {
                    maxBonusPoints = currentBonus;
                    maxAttendances = studentAttendances;
                }
            }
            Console.WriteLine($"Max Bonus: {Math.Ceiling(maxBonusPoints)}.");
            Console.WriteLine($"The student has attended {maxAttendances} lectures.");
        }
    }
}
