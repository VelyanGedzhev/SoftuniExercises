using System;
using System.Collections.Generic;
using System.Text;

namespace TemplatePattern.Models.Breads
{
    public class TwelveGrain : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Baking 12-grain bread (25min).");
        }

        public override void MixIngridients()
        {
            Console.WriteLine("Gathering and mixing ingredients for 12-grain bread.");
        }
    }
}
