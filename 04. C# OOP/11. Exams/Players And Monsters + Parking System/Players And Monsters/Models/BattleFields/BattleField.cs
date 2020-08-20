using PlayersAndMonsters.Models.BattleFields.Contracts;
using PlayersAndMonsters.Models.Players;
using PlayersAndMonsters.Models.Players.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PlayersAndMonsters.Models.BattleFields
{
    public class BattleField : IBattleField
    {
        public void Fight(IPlayer attackPlayer, IPlayer enemyPlayer)
        {
            //•	If one of the users is dead, throw new ArgumentException with message "Player is dead!"
            if (attackPlayer.IsDead || enemyPlayer.IsDead)
            {
                throw new ArgumentException("Player is dead!");
            }
            //•	If the player is a beginner, increase his health with 40 points and increase all damage points of all cards for the user with 30.
            if (attackPlayer.GetType().Name == "Beginner")
            {
                attackPlayer.Health += 40;

                foreach (var card in attackPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }
            //•	If the player is a beginner, increase his health with 40 points and increase all damage points of all cards for the user with 30.
            if (enemyPlayer.GetType().Name == "Beginner")
            {
                enemyPlayer.Health += 40;

                foreach (var card in enemyPlayer.CardRepository.Cards)
                {
                    card.DamagePoints += 30;
                }
            }

            attackPlayer.Health +=
                attackPlayer
                .CardRepository
                .Cards
                .Select(x => x.HealthPoints)
                .Sum();

            enemyPlayer.Health +=
                enemyPlayer
                .CardRepository
                .Cards
                .Select(x => x.HealthPoints)
                .Sum();

            while (true)
            {
                if (attackPlayer.IsDead || enemyPlayer.IsDead)
                {
                    break;
                }

                var attackerDamage = 0;

                foreach (var card in attackPlayer.CardRepository.Cards)
                {
                    attackerDamage += card.DamagePoints;
                }
                enemyPlayer.TakeDamage(attackerDamage);


                if (enemyPlayer.IsDead)
                {
                    break;
                }

                var enemyDamage = 0;

                foreach (var card in enemyPlayer.CardRepository.Cards)
                {
                    enemyDamage += card.DamagePoints;
                }
                attackPlayer.TakeDamage(enemyDamage);

                if (attackPlayer.IsDead)
                {
                    break;
                }
            }
        }
    }
}
