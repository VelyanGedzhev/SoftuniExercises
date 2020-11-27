using System;
using System.Collections.Generic;
using System.Text;

namespace INStock.Interfaces
{
    public interface IProduct
    {
        public string Label { get; }
        public decimal Price { get; }
        public int Quantity { get; }
    }
}
