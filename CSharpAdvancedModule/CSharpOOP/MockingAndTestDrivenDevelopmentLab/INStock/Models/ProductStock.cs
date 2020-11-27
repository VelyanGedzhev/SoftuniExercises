using INStock.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace INStock.Models
{
    public class ProductStock
    {
        private readonly IList<IProduct> products;
        public ProductStock(IList<IProduct> repo)
        {
            products = repo;
        }
        public int Count
        {
            get => products.Count;

        }
        public IProduct this[int index]
        {
            get => products[index];

            private set
            {
                products[index] = value;
            }
        }
        public void Add(IProduct product)
        {
            if (product == null)
            {
                throw new ArgumentException("Product cannot be null.");
            }
            if (products.Contains(product))
            {
                throw new ArgumentException("Product label must be unique.");
            }
            products.Add(product);
        }
        public bool Contains(IProduct product)
        {
            return products.Any(p => p.Label == product.Label);
        }

        public IProduct Find(int index)
        {
            if (index < 0 || index > products.Count)
            {
                throw new InvalidOperationException("Invalid index.");
            }
            return products[index];
        }

    }
}
