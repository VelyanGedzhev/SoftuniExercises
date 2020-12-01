using System;
using TemplatePattern.Models.Breads;

namespace TemplatePattern
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Sourdough sourdough = new Sourdough();
            sourdough.Make();
            Console.WriteLine();

            TwelveGrain twelveGrain = new TwelveGrain();
            twelveGrain.Make();
            Console.WriteLine();

            WholeWeat wholeWeat = new WholeWeat();
            wholeWeat.Make();
        }
    }
}
