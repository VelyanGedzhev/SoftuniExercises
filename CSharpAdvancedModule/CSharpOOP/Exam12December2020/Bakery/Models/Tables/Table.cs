using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private readonly ICollection<IDrink> drinks;
        private readonly ICollection<IBakedFood>food;
        private int peopleCount;
        private int capacity;
        private bool isReserved;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            TableNumber = tableNumber;
            Capacity = capacity;
            PricePerPerson = pricePerPerson;

            isReserved = false;

            drinks = new List<IDrink>();
            food = new List<IBakedFood>();
        }

        public int TableNumber { get; private set; }

        public int Capacity
        {
            get => capacity;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }

                capacity = value;
            }
        }

        public decimal PricePerPerson { get; private set; }

        public int NumberOfPeople
        {
            get => peopleCount;

            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }

                peopleCount = value;
            }
        }

        public bool IsReserved => isReserved;

        public decimal Price => (decimal)(NumberOfPeople * PricePerPerson);

        public void Clear()
        {
            this.food.Clear();
            this.drinks.Clear();
            isReserved = false;
            peopleCount = 0;
        }

        public decimal GetBill()
        {
            decimal foodSum = this.food.Sum(x => x.Price);
            decimal drinkSum = this.drinks.Sum(x => x.Price);

            return foodSum + drinkSum;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Table: {TableNumber}")
                .AppendLine($"Type: {GetType().Name}")
                .AppendLine($"Capacity: {Capacity}")
                .AppendLine($"Price per Person: {PricePerPerson}");

            return sb.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinks.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            this.food.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            isReserved = true;
            NumberOfPeople = numberOfPeople;
        }
    }
}
