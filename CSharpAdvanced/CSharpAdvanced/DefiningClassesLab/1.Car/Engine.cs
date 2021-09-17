using System;
using System.Collections.Generic;
using System.Text;

namespace _1.Car
{
    public class Engine
    {
        public Engine(int horsePower, double cubicCapacity)
        {
            HorsePower = horsePower;
            CubicCapactity = cubicCapacity;
        }

        public int HorsePower { get; set; }
        public double CubicCapactity { get; set; }
    }
}
