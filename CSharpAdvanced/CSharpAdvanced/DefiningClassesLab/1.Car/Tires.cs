using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Car
{
    public class Tires
    {
        public Tires(int year, double pressure)
        {
            Year = year;
            pressure = pressure;
        }

        public int Year { get; set; }
        public double Pressure { get; set; }
    }
}
