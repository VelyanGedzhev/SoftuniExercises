using System;
using System.Collections.Generic;
using System.Text;

namespace CompositePattern
{
    public abstract class BaseGift
    {
        protected BaseGift(decimal price, string name)
        {
            Price = price;
            Name = name;
        }

        public decimal Price { get; set; }
        public string  Name { get; set; }


        public abstract decimal CalculateTotalPrice();
    }
}
