using BorderControl.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BorderControl.Models
{
    class Rebel : IBuyer
    {
        public Rebel(string name, string id)
        {
            Name = name;
            Id = id;
        }

        public int Food { get; private set; }

        public string Name { get; private set; }
        public string Id { get; private set; }

        

        public int BuyFood()
        {
            Food += 5;
            return 5;
        }
    }
}
