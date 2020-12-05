using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Guns
{
    public abstract class Gun : IGun
    {
        private string name;
        private int bulletsCount;

        public Gun(string name, int bulletsCount)
        {
            Name = name;
            BulletsCount = bulletsCount;
        }

        public string Name
        {
            get => name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGunName);
                }

                name = value;
            }
        }

        public int BulletsCount
        {
            get => bulletsCount;

            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGunBulletsCount);
                }

                bulletsCount = value;
            }
        }
        abstract protected int FireRate {get;}

        public  int Fire()
        {
            if (BulletsCount - FireRate >= 0)
            {
                BulletsCount -= FireRate;
                return FireRate;
            }
            else
            {
                int resultingBullet = BulletsCount;
                BulletsCount = 0;
                return resultingBullet;
            }
        }
    }
}
