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
            Fuel = fuel;
        }

        public double Fuel 
        {
            get
            {
                return fuel;
            }
            protected set
            {
                if (value > TankCapacity)
                {
                    fuel = 0;
                }
                else
                {
                    fuel = value;
                }
            }
        }
        
        public virtual double FuelConsumption { get; protected set; }

        public double TankCapacity { get; protected set; }

        public virtual string Drive(double kilometers)
        {
            double fuelNeeded = kilometers * this.FuelConsumption;

            if (Fuel < fuelNeeded)
            {
                string excMsg = string.Format(ExceptionMessages.NOT_ENOUGH_FUEL, GetType().Name);
                throw new InvalidOperationException(excMsg);
            }

            Fuel -= fuelNeeded;

            return string.Format(ENOUGH_FUEL, GetType().Name, kilometers);
        }

        public virtual void Refuel(double amount)
        {
            if (amount <= 0)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.INVALID_FUEL_QUANTITY));
            }
            else if (Fuel + amount > TankCapacity)
            {
                throw new InvalidOperationException(string.Format(ExceptionMessages.NOT_ENOUGH_TANK_CAPACITY, amount));
            }
            else
                Fuel += amount;
        }

        public virtual string DriveEmpty(double kilometers)
        {
            return string.Format(ENOUGH_FUEL, GetType().Name, kilometers);
        }

        public override string ToString()
        {
            return $"{GetType().Name}: {Fuel:f2}";
        }
    }
}
