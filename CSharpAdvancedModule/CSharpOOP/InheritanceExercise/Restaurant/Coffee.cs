using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        private const double COFFEE_MILLILITERS = 50;
        private const decimal COFFEEP_PRICE = 3.5m;
        public Coffee(string name, double caffeine) 
            : base(name, COFFEEP_PRICE, COFFEE_MILLILITERS)
        {
            Caffeine = caffeine;
        }
        public double Caffeine  { get; set; }
    }
}
