using System;
using System.Numerics;

namespace _11._Snowballs
{
    class Program
    {
        static void Main(string[] args)
        {
            short snowballsCount = short.Parse(Console.ReadLine());
            BigInteger bestQuality = int.MinValue;
            int snowballSnow = 0;
            int snowballTime = 0;
            int snowballQuality = 0;

            for (int i = 0; i < snowballsCount; i++)
            {
                int currentSnowballSnow = int.Parse(Console.ReadLine());
                int currentSnowballTime = int.Parse(Console.ReadLine());
                int currentSnowballQuality = int.Parse(Console.ReadLine());
                BigInteger currentQuality =BigInteger.Pow((currentSnowballSnow / currentSnowballTime),currentSnowballQuality);

                if(currentQuality > bestQuality)
                {
                    bestQuality = currentQuality;
                    snowballSnow = currentSnowballSnow;
                    snowballTime = currentSnowballTime;
                    snowballQuality = currentSnowballQuality;
                }
            }
            Console.WriteLine($"{snowballSnow} : {snowballTime} = {bestQuality} ({snowballQuality})");
        }
    }
}
