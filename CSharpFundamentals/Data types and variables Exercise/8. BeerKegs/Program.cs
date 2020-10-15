using System;

namespace _8._BeerKegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            double maxVolume = double.MinValue;
            string biggestKeg = "";
            
            for (int i = 0; i < count; i++)
            {
                string kegModel = Console.ReadLine();
                float kegRadius = float.Parse(Console.ReadLine());
                int kegHeight = int.Parse(Console.ReadLine());
                double kegVolume = Math.PI * kegRadius * kegRadius * kegHeight;
                if (kegVolume > maxVolume)
                {
                    maxVolume = kegVolume;
                    biggestKeg = kegModel;
                }
            }
            Console.WriteLine(biggestKeg);
        }
    }
}
