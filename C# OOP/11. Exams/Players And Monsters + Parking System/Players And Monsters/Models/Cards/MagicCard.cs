using PlayersAndMonsters.Models.Cards.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards
{
    public class MagicCard : Card, ICard
    {
        public const int magicCardDamagePoints = 5;
        public const int magicCardDHealthPoints = 80;
        public MagicCard(string name) 
            : base(name, magicCardDamagePoints, magicCardDHealthPoints)
        {
        }
    }
}
