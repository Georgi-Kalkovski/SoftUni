using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private Dictionary<string, IPlayer> collectionOfPlayers;

        public PlayerRepository()
        {
            this.collectionOfPlayers = new Dictionary<string, IPlayer>();
        }

        public int Count => this.collectionOfPlayers.Count;

        public IReadOnlyCollection<IPlayer> Players => this.collectionOfPlayers.Values.ToList().AsReadOnly();

        public void Add(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }
            if (this.collectionOfPlayers.ContainsKey(player.Username))
            {
                throw new ArgumentException($"Player {player.Username} already exists!");
            }
            this.collectionOfPlayers.Add(player.Username, player);
        }

        public bool Remove(IPlayer player)
        {
            if (player == null)
            {
                throw new ArgumentException("Player cannot be null");
            }
            return this.collectionOfPlayers.Remove(player.Username);
        }

        public IPlayer Find(string username)
        {
            IPlayer usernameFound = null;

            if (this.collectionOfPlayers.ContainsKey(username))
            {
                usernameFound = this.collectionOfPlayers[username];
            }

            return usernameFound;
        }
    }
}
