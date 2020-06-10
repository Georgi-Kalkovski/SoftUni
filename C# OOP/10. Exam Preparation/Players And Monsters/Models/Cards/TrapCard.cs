using PlayersAndMonsters.Models.Cards.Contracts;

namespace PlayersAndMonsters.Models.Cards
{
    public class TrapCard : Card, ICard
    {
        private const int TrapCardInitialDamagePoints = 120;
        private const int TrapCardInitialHealthPoints = 5;

        public TrapCard(string name) 
            : base(name, TrapCardInitialDamagePoints, TrapCardInitialHealthPoints)
        {
        }
    }
}