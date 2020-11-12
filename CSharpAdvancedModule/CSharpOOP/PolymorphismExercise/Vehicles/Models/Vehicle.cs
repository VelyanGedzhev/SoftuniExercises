using System;
using Vehicles.Models.Common;
using Vehicles.Models.Interfaces;

namespace Vehicles.Models
{
    public abstract class Vehicle : IDrive, IRefuel
    {
        private const string ENOUGH_FUEL = "{0} travelled {1} km";

        private double fuel;
        protected Vehicle(double fuel, double fuelConsumption, double tankCapacity)
        {
            FuelConsumption = fuelConsumption;
            TankCapacity = tankCapacity;
            if (fuel >= TankCapacity)
            {
                fuel = 0;
            }
            Fuel = fuel;

        }

        public double Fuel { get; protected set; }
        //{
        //    get => fuel;
        //    protected set
        //    {
        //        if (value > TankCapacity)
        //        {
        //            fuel = 0;
        //        }
        //        else
        //        {
        //            fuel = value;
        //        }
        //    }
        //}
        public virtual double FuelConsumption { get; protected set; }
  

        public double TankCapacity { get; protected set; }

        public string Drive(double kilometers)
        {
            double fuelNeeded = kilometers * FuelConsumption;

            if (fuelNeeded <= Fuel)
            {
                Fuel -= fuelNeeded;
                return string.Format(ENOUGH_FUEL, GetType().Name, kilometers);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NOT_ENOUGH_FUEL, GetType().Name));
            }
        }
        public string DriveEmpty(double Kilometers)
        {
            double fuelNeeded = Kilometers * (FuelConsumption- 1.4);

            if (fuelNeeded <= Fuel)
            {
                Fuel -= fuelNeeded;
                return string.Format(ENOUGH_FUEL, GetType().Name, Kilometers);
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NOT_ENOUGH_FUEL, GetType().Name));
            }
        }

        public virtual void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.INVALID_FUEL_QUANTITY));
            }
            else if (Fuel + amount <= TankCapacity)
            {
                Fuel += amount;
            }
            else
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NOT_ENOUGH_TANK_CAPACITY, amount));
            }
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {Fuel:f2}";
        }
    }
}
