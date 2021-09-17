using System;
using System.Collections.Generic;
using System.Text;

namespace CarSalesman
{
    public class Engine
    {

        public Engine(string model, string power, string discplacement, string efficiency)
        {
            Model = model;
            Power = power;
            Discplacement = discplacement;
            Efficiency = efficiency;
        }

        public string Model { get; set; }
        public string Power { get; set; }
        public string Discplacement { get; set; }
        public string Efficiency { get; set; }
    }
}
