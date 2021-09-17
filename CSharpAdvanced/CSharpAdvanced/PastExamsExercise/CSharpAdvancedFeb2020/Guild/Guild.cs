using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> guildList;
        

        public Guild(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            guildList = new List<Player>();
        }

        public string Name { get; set; }
        public int Capacity { get; set; }

        public int Count
        {
            get
            {
                return guildList.Count;
            }
        }

        public void AddPlayer(Player player)
        {
            if (Count < Capacity)
            {
                guildList.Add(player);
            }
        }
        public bool RemovePlayer(string name)
        {
            bool isRemoved = false;

            foreach (Player player in guildList)
            {
                if (player.Name == name)
                {
                    guildList.Remove(player);
                    isRemoved = true;
                    break;
                }
            }
            return isRemoved;
        }
        public void PromotePlayer(string name)
        {
            for (int i = 0; i < Count; i++)
            {
                if (guildList[i].Name == name && guildList[i].Rank != "Member")
                {
                    guildList[i].Rank = "Member";
                }
            }
        }
        public void DemotePlayer(string name)
        {
            foreach (Player player in guildList)
            {
                if (player.Name == name && player.Rank != "Trial")
                {
                    player.Rank = "Trial";
                }
                break;
            }
        }
        public Player[] KickPlayersByClass(string @class)
        {
            var arr = guildList.Where(c => c.Class == @class).ToArray();
            guildList.RemoveAll(c => c.Class == @class);
            return arr;
        }
        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Players in the guild: {Name}");

            foreach (Player player in guildList)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
