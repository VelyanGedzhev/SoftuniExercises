using Bakery.Core.Contracts;
using Bakery.Models.BakedFoods;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Enums;
using Bakery.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bakery.Core
{
    public class Controller : IController
    {
        private readonly ICollection<IDrink> drinks;
        private readonly ICollection<IBakedFood> foods;
        private readonly ICollection<ITable> tables;
        private  decimal income;

        public Controller()
        {
            this.drinks = new List<IDrink>();
            this.foods = new List<IBakedFood>();
            this.tables = new List<ITable>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;

            if (type == DrinkType.Tea.ToString())
            {
                drink = new Tea(name, portion, brand);
            }
            if (type == DrinkType.Water.ToString())
            {
                drink = new Water(name, portion, brand);
            }

            if (drink == null)
            {
                throw new ArgumentException();
            }
            else
            {
                drinks.Add(drink);

                return $"Added {drink.Name} ({drink.Brand}) to the drink menu";
            }

        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = null;

            if (type == BakedFoodType.Bread.ToString())
            {
                food = new Bread(name, price);
            }
            if (type == BakedFoodType.Cake.ToString())
            {
                food = new Cake(name, price);
            }

            if (food == null)
            {
                throw new ArgumentException();
            }
            else
            {
                this.foods.Add(food);

                return string.Format(OutputMessages.FoodAdded, name, food.GetType().Name);
            }
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;

            if (type == TableType.InsideTable.ToString())
            {
                table = new InsideTable(tableNumber, capacity);
            }
            if (type == TableType.OutsideTable.ToString())
            {
                table = new OutsideTable(tableNumber, capacity);
            }

            if (table == null)
            {
                throw new ArgumentException();
            }
            else
            {
                tables.Add(table);

                return $"Added table number {table.TableNumber} in the bakery";
            }
        }

        public string GetFreeTablesInfo()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var table in tables)
            {
                if (table.IsReserved == false)
                {
                    sb.AppendLine(table.GetFreeTableInfo());
                }
            }

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            return $"Total income: {income:f2}";
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            if (table == null)
            {
                throw new ArgumentException(string.Format(OutputMessages.WrongTableNumber, tableNumber));
            }
           decimal bill =  table.GetBill() + table.Price;
           

            income += bill;

            table.Clear();
            return $"Table: {tableNumber}" + Environment.NewLine + $"Bill: {bill}";
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            if (!tables.Any(x => x.TableNumber == tableNumber))
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            if (!drinks.Any(x => x.Name == drinkName && x.Brand == drinkBrand))
            {
                return string.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }

            IDrink drink = drinks.FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand);
            ITable table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            table.OrderDrink(drink);

            //tables.FirstOrDefault(x => x.TableNumber == tableNumber).OrderDrink(drinks.FirstOrDefault(x => x.Name == drinkName && x.Brand == drinkBrand));

            return $"Table {tableNumber} ordered {drinkName} {drinkBrand}";
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            if (!tables.Any(x => x.TableNumber == tableNumber))
            {
                return string.Format(OutputMessages.WrongTableNumber, tableNumber);
            }

            if (!this.foods.Any(x => x.Name == foodName))
            {
                return string.Format(OutputMessages.NonExistentFood, foodName);
            }

            IBakedFood food = this.foods.FirstOrDefault(x => x.Name == foodName);

            ITable table = tables.FirstOrDefault(x => x.TableNumber == tableNumber);

            table.OrderFood(food);

            //tables.FirstOrDefault(x => x.TableNumber == tableNumber).OrderFood(food.FirstOrDefault(x => x.Name == foodName));

            return string.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = tables.FirstOrDefault(x => x.IsReserved == false && x.Capacity >= numberOfPeople);

            if (table == null)
            {
                return string.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }

            table.Reserve(numberOfPeople);

            return string.Format(OutputMessages.TableReserved, table.TableNumber, numberOfPeople);
        }
    }
}
