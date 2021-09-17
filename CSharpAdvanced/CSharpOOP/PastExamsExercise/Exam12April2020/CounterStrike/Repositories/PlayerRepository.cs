using CounterStrike.Models.Players.Contracts;
using CounterStrike.Repositories.Contracts;
using CounterStrike.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CounterStrike.Repositories
{
    class PlayerRepository : IRepository<IPlayer>
    {
        private List<IPlayer> players;

        public PlayerRepository()
        {
            players = new List<IPlayer>();
        }
        public IReadOnlyCollection<IPlayer> Models => players.AsReadOnly();

        public void Add(IPlayer model)
        {
            if (model == null)
            {
                throw new ArgumentException(ExceptionMessages.InvalidPlayerRepository);
            }

            players.Add(model);
        }

        public IPlayer FindByName(string name)
        {
            return players.FirstOrDefault(p => p.Username == name);
        }

        public bool Remove(IPlayer model)
        {
            return players.Remove(model);
        }
    }
}
