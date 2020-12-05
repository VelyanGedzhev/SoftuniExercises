using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Guns
{
    class Rifle : Gun
    {
        private const int FIRE_RATE = 10;

        public Rifle(string name, int bulletsCount)
            : base(name, bulletsCount)
        {
        }

        protected override int FireRate => FIRE_RATE;
    }
}
