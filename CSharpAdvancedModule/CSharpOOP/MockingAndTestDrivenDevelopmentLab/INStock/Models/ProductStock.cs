using INStock.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace INStock.Models
{
    public class ProductStock : IProductStock
    {
        public IProduct this[int index] { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int Count { get; }

        public void Add(IProduct product)
        {
            throw new NotImplementedException();
        }

        public bool Contains(IProduct product)
        {
            throw new NotImplementedException();
        }

        public IProduct Find(int index)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IProduct> FindAllByPrice(decimal price)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IProduct> FindAllInPriceRange(decimal bottomPrice, int topPrice)
        {
            throw new NotImplementedException();
        }

        public IProduct FindByLabel(string label)
        {
            throw new NotImplementedException();
        }

        public IProduct FindMostExpensiveProducts(int price)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<IProduct> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public bool Remove(IProduct product)
        {
            throw new NotImplementedException();
        }
    }
}
