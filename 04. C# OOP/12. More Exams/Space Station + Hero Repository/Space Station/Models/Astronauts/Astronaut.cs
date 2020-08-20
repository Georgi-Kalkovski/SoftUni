using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Bags;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public abstract class Astronaut : IAstronaut
    {
        private string name;
        private double oxygen;
        protected double breathUnits = 10;

        protected Astronaut(string name, double oxygen)
        {
            Name = name;
            Oxygen = oxygen;

        }

        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException(String.Format(ExceptionMessages.InvalidAstronautName));
                }
                name = value;
            }
        }

        public double Oxygen
        {
            get => oxygen;
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidOxygen));
                }
                oxygen = value;
            }
        }

        public bool CanBreath
        {
            get
            {
                if (Oxygen > 0)
                {
                    return true;
                }
                return false;
            }
        }

        public IBag Bag { get; }

        public virtual void Breath()
        {

            Oxygen -= breathUnits;
            if (Oxygen < 0)
            {
                Oxygen = 0;
            }
        }
    }
}
