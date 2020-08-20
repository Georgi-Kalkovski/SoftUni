using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public class Tank : BaseMachine, ITank
    {
        private const double InitialHealthPoints = 100.0;
        public Tank(string name, double attackPoints, double defensePoints)
            : base(name, attackPoints, defensePoints, InitialHealthPoints)
        {
        }
        public bool DefenseMode { get; private set; }

        public void ToggleDefenseMode()
        {

            if (DefenseMode == true)
            {
                this.AttackPoints -= 40.0;
                this.DefensePoints += 30.0;
            }
            else
            {
                this.AttackPoints += 40.0;
                this.DefensePoints -= 30.0;
            }
            DefenseMode = false;
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
                sb.AppendLine($" *Targets: None");
            }

            else
            {
                sb.AppendLine($" *Targets: {string.Join(",", Targets)}");
            }
            if (DefenseMode == true)
            {
                sb.AppendLine($" *Defense: ON");
            }

            else
            {
                sb.AppendLine($" *Defense: OFF");
            }

            return sb.ToString().Trim();
        }
    }
}
