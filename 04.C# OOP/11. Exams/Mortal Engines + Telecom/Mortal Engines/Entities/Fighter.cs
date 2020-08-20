using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Fighter : BaseMachine, IFighter
    {
        private const double InitialHealthPoints = 200.0;
        public Fighter(string name, double attackPoints, double defensePoints) 
            : base(name, attackPoints, defensePoints, InitialHealthPoints)
        {
        }
        public bool AggressiveMode { get; private set; }

        public void ToggleAggressiveMode()
        {
            
            if (AggressiveMode == true)
            {
                this.AttackPoints += 50.0;
                this.DefensePoints -= 25.0;
            }
            else 
            {
                this.AttackPoints -= 50.0;
                this.DefensePoints += 25.0;
            }
            AggressiveMode = false;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"- {base.Name}");
            sb.AppendLine($" *Type: {base.Name.GetType()}");
            sb.AppendLine($" *Health: {this.HealthPoints}");
            sb.AppendLine($" *Attack: {this.AttackPoints}");
            sb.AppendLine($" *Defense: {this.DefensePoints}");

            if (Targets == null)
            {
                sb.AppendLine($"*Targets: None");
            }

            else
            {
                sb.AppendLine($" *Targets: {string.Join(",", Targets)}");
            }
            if (AggressiveMode == true)
            {
                sb.AppendLine($" *Aggressive: ON");
            }

            else
            {
                sb.AppendLine($" *Aggressive: OFF");
            }

            return sb.ToString().Trim();
        }
    }
}
