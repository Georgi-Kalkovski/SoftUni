using MortalEngines.Entities.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MortalEngines.Entities
{
    public abstract class BaseMachine : IMachine
    {
        private string name;
        private double attackPoints;
        private double defensePoints;
        private double healthPoints;

        protected BaseMachine(string name, double attackPoints, double defensePoints, double healthPoints)
        {
            this.name = name;
            this.attackPoints = attackPoints;
            this.defensePoints = defensePoints;
            this.healthPoints = healthPoints;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException($"Machine name cannot be null or empty.");
                }
                this.name = value;
            }
        }

        public IPilot Pilot
        {
            get
            {
                return this.Pilot;
            }
            set
            {
                if (string.IsNullOrEmpty(value.Name))
                {
                    throw new NullReferenceException("Pilot cannot be null.");
                }
                this.Pilot = value;
            }
        }
        public double HealthPoints { get; set; }

        public double AttackPoints { get; protected set; }

        public double DefensePoints { get; protected set; }

        public IList<string> Targets { get; private set; }

        public void Attack(IMachine target)
        {
            if (target is null)
            {
                throw new NullReferenceException("Target cannot be null");
            }

            while (target.HealthPoints != 0.0)
            {
                target.HealthPoints -= this.AttackPoints - target.DefensePoints;
                if (target.HealthPoints < 0.0)
                {
                    target.HealthPoints = 0.0;
                }
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"- {this.name}");
            sb.AppendLine($" *Type: {this.name.GetType()}");
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

            return sb.ToString().Trim();
        }
    }
}
