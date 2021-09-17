using System;
using System.Collections.Generic;
using System.Text;

namespace TemplatePattern.Models.Breads
{
    public class Sourdough : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Baking sourdough bread (20min).");
        }

        public override void MixIngridients()
        {
            Console.WriteLine("Gathering and mixing ingredients for sourdough bread.");
        }
    }
}
