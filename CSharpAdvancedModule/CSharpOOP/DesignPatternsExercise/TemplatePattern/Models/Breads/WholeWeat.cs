using System;
using System.Collections.Generic;
using System.Text;

namespace TemplatePattern.Models.Breads
{
    public class WholeWeat : Bread
    {
        public override void Bake()
        {
            Console.WriteLine("Baking wholeweat bread (15min).");
        }

        public override void MixIngridients()
        {
            Console.WriteLine("Gathering and mixing ingredients for wholeweat bread.");
        }
    }
}
