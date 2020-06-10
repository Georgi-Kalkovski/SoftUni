using System;

namespace MuOnline.Models.Items
{
    using Contracts;

    public abstract class Item : IItem
    {
        private int strength;
        private int agility;
        private int stamina;
        private int energy;

        protected Item(int strength, int agility, int stamina, int energy)
        {
            this.Strength = strength;
            this.Agility = agility;
            this.Stamina = stamina;
            this.Energy = energy;
        }

        public int Strength
        {
            get
            {
                return this.strength;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Strength cannot be less than zero");
                }

                this.strength = value;
            }
        }

        public int Agility
        {
            get
            {
                return this.agility;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Agility cannot be less than zero");
                }

                this.agility = value;
            }
        }

        public int Stamina
        {
            get
            {
                return this.stamina;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Stamina cannot be less than zero");
                }

                this.stamina = value;
            }
        }

        public int Energy
        {
            get
            {
                return this.energy;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Energy cannot be less than zero");
                }

                this.energy = value;
            }
        }
    }
}
