using INStock.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace INStock.Models
{
    public class ProductStock : IProductStock
    {
        private readonly List<IProduct> productByIndex;
        private readonly HashSet<string> productsByLabels;
        private readonly Dictionary<string, IProduct> productsByLabel;
        private readonly Dictionary<int, List<IProduct> >productsByQuantity;
        private readonly SortedDictionary<decimal, List<IProduct>> productsByPrice;

        public ProductStock()
        {
            productByIndex = new List<IProduct>();
            productsByLabels = new HashSet<string>();
            productsByLabel = new Dictionary<string, IProduct>();
            productsByPrice = new SortedDictionary<decimal, List<IProduct>>(Comparer<decimal>.Create((first, second) => second.CompareTo(first)));
            productsByQuantity = new Dictionary<int, List<IProduct>>();
        }

        public int Count => productByIndex.Count;

        public void Add(IProduct product)
        {
            ValidateNullProduct(product);

            if (productsByLabels.Contains(product.Label))
            {
                throw new ArgumentException($"Cannot duplicate label! A {product.Label} already exists.");
            }
            InitializeCollections(product);

            productsByLabels.Add(product.Label);
            productByIndex.Add(product);
            productsByLabel[product.Label] = product;       
            productsByQuantity[product.Quantity].Add(product);
            productsByPrice[product.Price].Add(product);
           
        }

        public bool Contains(IProduct product)
        {
            ValidateNullProduct(product);
            return productsByLabels.Contains(product.Label);
        }

        public IProduct Find(int index)
        {
            if (index < 0 || index >= productByIndex.Count)
            {
                throw new IndexOutOfRangeException("Invalid index.");
            }

            return productByIndex[index];
        }
       

        public IEnumerable<IProduct> FindAllByPrice(decimal price)
        {
            if (!productsByPrice.ContainsKey(price))
            {
                return Enumerable.Empty<IProduct>();
            }

            return productsByPrice[price];
        }

        public IEnumerable<IProduct> FindAllByQuantity(int quantity)
        {
            if (!productsByQuantity.ContainsKey(quantity))
            {
                return Enumerable.Empty<IProduct>();
            }
            return productsByQuantity[quantity];
        }

        public IEnumerable<IProduct> FindAllInPriceRange(decimal bottomPrice, int topPrice)
        {
            var result = new List<IProduct>();

            foreach (var (price, products) in productsByPrice)
            {
                if (price <= topPrice && price >= bottomPrice)
                {
                    result.AddRange(products);
                }
                if (price < bottomPrice)
                {
                    break;
                }
            }

            return result;
        }

        public IProduct FindByLabel(string label)
        {
            if (string.IsNullOrEmpty(label))
            {
                throw new ArgumentException("Label cannot be null or empty.");
            }

            if (!productsByLabels.Contains(label))
            {
                throw new ArgumentException($"Label {label} cannot be found.");
            }

            return productsByLabel[label];
        }

        public IProduct FindMostExpensiveProduct()
        {
            if (!productsByPrice.Any())
            {
                throw new ArgumentException("No products in stock.");
            }
            var mostExpensiveProducts = productsByPrice.First().Value;
            var firstAddedExpensiveProduct = mostExpensiveProducts.First();

            return firstAddedExpensiveProduct;
        }


        public bool Remove(IProduct product)
        {
            ValidateNullProduct(product);

            var label = product.Label;

            if (!productsByLabels.Contains(label))
            {
                return false;
            }
            
            productByIndex.RemoveAll(pr => pr.Label == label);

            RemoveProductFromCollections(product);
          
            return true;
        }

        public IProduct this[int index] 
        { 
            get => Find(index);
            
            set
            {
                ValidateNullProduct(value);

                InitializeCollections(value);

                RemoveProductFromCollections(value);

                productByIndex[index] = value;
            }
        }
        public IEnumerator<IProduct> GetEnumerator()
        {
           return productByIndex.GetEnumerator();
        }

        private void ValidateNullProduct(IProduct product)
        {
            if (product == null)
            {
                throw new ArgumentException("Product cannot be null.");
            }
        }

        private void InitializeCollections(IProduct product)
        {
            if (!productsByQuantity.ContainsKey(product.Quantity))
            {
                productsByQuantity[product.Quantity] = new List<IProduct>();
            }

            if (!productsByPrice.ContainsKey(product.Price))
            {
                productsByPrice[product.Price] = new List<IProduct>();
            }
        }

        private void RemoveProductFromCollections(IProduct product)
        {
            var label = product.Label;

            productsByLabels.Remove(label);

            productsByLabel.Remove(label);

            var allWithProductQuantity = productsByQuantity[product.Quantity];

            allWithProductQuantity.RemoveAll(pr => pr.Label == label);

            var allWithProductPrice = productsByPrice[product.Price];

            allWithProductPrice.RemoveAll(pr => pr.Label == label);
        }
    }
}
