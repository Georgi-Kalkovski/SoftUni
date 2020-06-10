using PlayersAndMonsters.Models.Players.Contracts;
using PlayersAndMonsters.Repositories.Contracts;

namespace PlayersAndMonsters.Models.Players
{
    public class Beginner : Player, IPlayer
    {
        private const int BeginnerPlayerInitialHealth = 50;

        public Beginner(ICardRepository cardRepository, string username) 
            : base(cardRepository, username, BeginnerPlayerInitialHealth)
        {
        }
    }
}