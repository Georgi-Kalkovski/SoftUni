using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;

        protected Astronaut(IBag Bag, string name, double oxygen)
        {
            this.name = name;
            this.oxygen = oxygen;
            this.Bag = Bag;
        }

        public string Name
        {
            get => this.name;
            private set 
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAstronautName);
                }
                this.name = value; 
            }
        }

        public double Oxygen
        {
            get => this.oxygen;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOxygen);
                }
                this.oxygen = value;
            }
        }

        public bool CanBreath => this.Oxygen > 0.0;

        public IBag Bag { get; }

        public void Breath()
        {
            double oxygenUnits = 10.0;

            if (this.Name == "Biologist")
            {
                oxygenUnits = 5.0;
            }

            if (this.Oxygen < 0.0)
            {
                throw new ArgumentException("Oxygen units cannot be less than zero");
            }

            if (this.Oxygen - oxygenUnits >= 0.0)
            {
                this.Oxygen -= oxygenUnits;
            }
            else
            {
                this.Oxygen = 0.0;
            }
        }
    }
}
