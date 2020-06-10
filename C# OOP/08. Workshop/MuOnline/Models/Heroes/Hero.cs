namespace MuOnline.Models.Heroes
{
    using System;
    using System.Linq;

    using HeroContracts;
    using Inventories;
    using Inventories.Contracts;

    public abstract class Hero : IHero, IIdentifiable, IProgress
    {
        private string username;
        private int strength;
        private int agility;
        private int stamina;
        private int energy;
        private int experience;
        private int level;
        private int resets;
        private int totalAgilityPoints;
        private int totalEnergyPoints;
        private int totalStaminaPoints;

        protected Hero(
            string username,
            int strength, int agility, int stamina, int energy)
        {
            this.Username = username;
            this.Strength = strength;
            this.Agility = agility;
            this.Stamina = stamina;
            this.Energy = energy;
            this.Experience = 0;
            this.Level = 0;
            this.Resets = 0;

            this.Inventory = new Inventory();
        }

        public IInventory Inventory { get; }

        public bool IsAlive
            => this.totalStaminaPoints > 0;

        public string Username
        {
            get
            {
                return this.username;
            }
            private set
            {
                if (value == null)
                {
                    throw new ArgumentException("Username cannot be null!");
                }

                this.username = value;
            }
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
                    throw new ArgumentException("Strength cannot be less than zero!");
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
                    throw new ArgumentException("Agility cannot be less than zero!");
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
                    throw new ArgumentException("Stamin cannot be less than zero!");
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
                    throw new ArgumentException("Energy cannot be less than zero!");
                }

                this.energy = value;
            }
        }

        public int Experience
        {
            get
            {
                return this.experience;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Experience cannot be less than zero!");
                }

                this.experience = value;
            }
        }

        public int Level
        {
            get
            {
                return this.level;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Levels cannot be less than zero!");
                }

                this.level = value;
            }
        }

        public int Resets
        {
            get
            {
                return this.resets;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Resets cannot be less than zero!");
                }

                this.resets = value;
            }
        }

        public void TakeDamage(int damagePoints)
        {
            if (this.TotalAgilityPoints > 0)
            {
                this.TotalAgilityPoints -= damagePoints;
            }
            else
            {
                this.TotalStaminaPoints -= damagePoints;
            }
        }

        public void AddExperience(int experience)
        {
            if (this.IsAlive)
            {
                throw new InvalidOperationException("Hero is not alive!");
            }

            this.Experience += experience;

            if (this.Experience >= 9000)
            {
                AddLevel();
            }

            if (this.Level >= 400)
            {
                AddReset();
            }
        }

        private void AddReset()
        {
            throw new NotImplementedException();
        }

        private void AddLevel()
        {
            throw new NotImplementedException();
        }

        public int TotalAttackPoints
            => this.Strength +
               this.Agility * 10 / 100 +
               this.Energy * 5 / 100 +
               this.Inventory.Items.Sum(x => x.Strength);


        public int TotalEnergyPoints
            => this.Energy +
               this.Inventory.Items.Sum(x => x.Energy);

        public int TotalAgilityPoints
        {
            get
            {
                return this.totalAgilityPoints;
            }
            private set
            {
                this.totalAgilityPoints = this.Agility +
                                          this.Inventory.Items.Sum(x => x.Agility);
            }
        }

        public int TotalStaminaPoints
        {
            get
            {
                return this.totalStaminaPoints;
            }
            private set
            {
                this.totalStaminaPoints = this.Stamina +
                    this.Inventory.Items.Sum(x => x.Stamina);
            }
        }
    }
}
