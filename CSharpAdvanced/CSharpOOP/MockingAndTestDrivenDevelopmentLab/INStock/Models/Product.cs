using INStock.Interfaces;
using System;

namespace INStock.Models
{
    public class Product : IProduct
    {
        private string label;
        private decimal price;
        private int quantity;
            
        public Product(string label, decimal price, int quantity)
        {
            Label = label;
            Price = price;
            Quantity = quantity;
        }

        public string Label
        {
            get => label;

            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Label cannot be null or empty");
                }
                label = value;
            }
        }

        public decimal Price
        {
            get => price;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price cannot be below zero.");
                }
                price = value;
            }
        }

        public int Quantity
        {
            get => quantity;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Quantity cannot be negative");
                }
                quantity = value;
            }
        }

        public int CompareTo(IProduct other)
        {
            return this.Price.CompareTo(other.Price);
        }
    }
}
