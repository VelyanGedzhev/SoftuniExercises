using System;
using System.Collections.Generic;
using System.Text;

namespace CompositePattern
{
    public class SingleGift : BaseGift
    {
        public SingleGift(decimal price, string name) 
            : base(price, name)
        {
        }

        public override decimal CalculateTotalPrice()
        {
            return Price;
        }
    }
}
