using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Bus : Vehicle
    {
        private const double SUMMER_CONSUMPTION_MODIFIER = 1.4;
        public Bus(double fuel, double fuelConsumption, double tankCapacity) : base(fuel, fuelConsumption, tankCapacity)
        {
        }
        //To rework the fuel consumption of the bus!!!
        public override double FuelConsumption => base.FuelConsumption + SUMMER_CONSUMPTION_MODIFIER;

    }
}
