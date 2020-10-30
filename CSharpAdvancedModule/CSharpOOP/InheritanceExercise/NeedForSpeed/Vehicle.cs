using System;
using System.Collections.Generic;
using System.Text;

namespace NeedForSpeed
{
    public class Vehicle
    {
        private const double DEFAULT_FUEL_CONSUMPTION = 1.25;
        public Vehicle(int horsePower, double fuel)
        {
            HorsePower = horsePower;
            Fuel = fuel;
        }
        
        public virtual double FuelConsumption
        {
            get
            {
                return DEFAULT_FUEL_CONSUMPTION;
            }
        }
        public int HorsePower { get; set; }
        public double Fuel { get; set; }
        
        public virtual void Drive(double kilometers)
        {
            Fuel -= kilometers * FuelConsumption;
        }
    }
}
