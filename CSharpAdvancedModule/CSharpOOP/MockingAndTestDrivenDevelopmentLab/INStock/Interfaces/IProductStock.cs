using System;
using System.Collections.Generic;
using System.Text;

namespace INStock.Interfaces
{
    public interface IProductStock
    {
        public int Count { get; }
        IProduct this[int index] { get; set; }
        bool Contains(IProduct product);
        void Add(IProduct product);
        bool Remove(IProduct product);
        IProduct Find(int index);
        IProduct FindByLabel(string label);
        IEnumerable<IProduct> FindAllInPriceRange(decimal bottomPrice, int topPrice);
        IEnumerable<IProduct> FindAllByPrice(decimal price);
        IProduct FindMostExpensiveProducts(int price);
        IEnumerable<IProduct> FindAllByQuantity(int quantity);

    }
}
