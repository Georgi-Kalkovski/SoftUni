using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Players
{
    public class Advanced : Player, IPlayer
    {
        private const int advancedPlayerInitialHealthPoints = 250;
        public Advanced(ICardRepository cardRepository, string username) 
            : base(cardRepository, username, advancedPlayerInitialHealthPoints)
        {
        }
    }
}
