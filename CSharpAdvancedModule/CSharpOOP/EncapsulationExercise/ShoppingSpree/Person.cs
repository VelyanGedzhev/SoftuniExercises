using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class Person
    {
        private const string LACK_OF_FUNDS = "{0} can't afford {1}";
        private const string PURCHASE_IS_MADE = "{0} bought {1}";

        private string name;
        private decimal money;
        private readonly ICollection<Product> productsBag;

        public Person(string name, decimal money)
        {
            Name = name;
            Money = money;
            productsBag = new List<Product>();
        }

        public string Name
        {
            get
            {
                return name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(GlobalConstants.INVALID_NAME);
                }
                name = value;
            }
        }
        public decimal Money
        {
            get
            {
                return money;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(GlobalConstants.INVALID_MONEY);
                }
                money = value;
            }
        }

        public IReadOnlyCollection<Product> ProdcutsBag
        {
            get
            {
                return (IReadOnlyCollection<Product>)productsBag;
            }
        }

        public string BuyProducts(Product product)
        {
            if (Money < product.Cost)
            {
                return String.Format(LACK_OF_FUNDS, Name, product.Name);
            }
            Money -= product.Cost;
            productsBag.Add(product);
            return String.Format(PURCHASE_IS_MADE, Name, product.Name);
        }
        public override string ToString()
        {
            string productOutput = productsBag.Count > 0 ? String.Join(", ", productsBag) : "Nothing bought";
            return $"{Name} - {productOutput}";
        }
    }
}
