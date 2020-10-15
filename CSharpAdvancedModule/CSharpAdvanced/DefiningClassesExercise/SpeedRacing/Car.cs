using System;
using System.Collections.Generic;
using System.Text;

namespace SpeedRacing
{
    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumption = fuelConsumption;
            TravelledDistance = 0;
        }
        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumption { get; set; }
        public double TravelledDistance { get; set; }
        
        public void Drive(int amountOfKm)
        {
            bool canMove = FuelAmount - (FuelConsumption * amountOfKm) >= 0;
            if (canMove)
            {
                FuelAmount -= (FuelConsumption * amountOfKm);
                TravelledDistance += amountOfKm;
            }
            else
            {
                Console.WriteLine($"Insufficient fuel for the drive");
            }
        }
    }
}
