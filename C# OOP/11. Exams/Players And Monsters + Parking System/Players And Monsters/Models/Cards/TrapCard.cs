using PlayersAndMonsters.Models.Cards.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlayersAndMonsters.Models.Cards
{
    class TrapCard : Card, ICard
    {
        public const int magicCardDamagePoints = 120;
        public const int magicCardDHealthPoints = 5;
        public TrapCard(string name) 
            : base(name, magicCardDamagePoints, magicCardDHealthPoints)
        {
        }
    }
}
