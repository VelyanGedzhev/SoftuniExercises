using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters
{
    public abstract class Hero
    {
        public Hero(string username, int level)
        {
            Username = username;
            Level = level;
        }

        public string Username { get; private set; }
        public int Level { get; set; }

        public override string ToString()
        {
            return $"Type: {GetType().Name} Username: {Username} Level :{Level}";
        }
    }
}
