﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Vehicles.Models
{
    public class Truck : Vehicle
    {
        private const double SUMMER_CONSUMPTION_MODIFIER = 1.6;
        private const double REFUEL_EFFICIENCY = 0.95;

        public Truck(double fuel, double fuelConsumption, double tankCapacity) : base(fuel, fuelConsumption, tankCapacity)
        {
        }

        public override double FuelConsumption => base.FuelConsumption + SUMMER_CONSUMPTION_MODIFIER;
        public override void Refuel(double amount)
        {
            base.Refuel(amount);
            Fuel += amount * REFUEL_EFFICIENCY;
            
        }
    }
}
