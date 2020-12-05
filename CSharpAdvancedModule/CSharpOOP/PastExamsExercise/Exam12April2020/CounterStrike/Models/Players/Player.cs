using CounterStrike.Models.Guns.Contracts;
using CounterStrike.Models.Players.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace CounterStrike.Models.Players
{
    public abstract class Player : IPlayer
    {
        private string username;
        private int health;
        private int armor;
        private IGun gun;

        protected Player(string username, int health, int armor, IGun gun)
        {
            Username = username;
            Health = health;
            Armor = armor;
            Gun = gun;
        }

        public string Username
        {
            get => username;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerName);
                }

                username = value;
            }
        }

        public int Health
        {
            get => health;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerHealth);
                }

                health = value;
            }
        }

        public int Armor
        {
            get => armor;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPlayerArmor);
                }

                armor = value;
            }
        }

        public IGun Gun
        {
            get => gun;

            private set
            {
                if (value == null)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidGun);
                }

                gun = value;
            }
        }

        public bool IsAlive => Health > 0;

        public void TakeDamage(int points)
        {
            if (armor - points >= 0)
            {
                armor -= points;
                return;
            }
            else if(armor > 0)
            {
                points -= armor;
                armor = 0;
            }

            health -= points;
        }
    }
}
