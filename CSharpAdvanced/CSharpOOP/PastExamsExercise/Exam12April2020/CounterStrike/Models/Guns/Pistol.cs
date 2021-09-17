using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Guns
{
    public class Pistol : Gun
    {
        private const int FIRE_RATE = 1;

        public Pistol(string name, int bulletsCount) 
            : base(name, bulletsCount)
        {
        }

        protected override int FireRate => FIRE_RATE;
    }
}
