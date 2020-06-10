using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ViceCity.Models.Guns.Contracts
{
    public abstract class Gun : IGun
    {
        private string name;
        private int bulletsPerBarrel;
        private int totalBullets;
        private int bulletsPerShot;
        private int currentBullets;

        protected Gun(string name, int bulletsPerBarrel, int totalBullets)
        {
            this.Name = name;
            this.BulletsPerBarrel = bulletsPerBarrel;
            this.TotalBullets = totalBullets;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException("Name cannot be null or a white space!");
                }
                this.name = value;
            }
        }

        public int BulletsPerBarrel
        {
            get
            {
                return this.bulletsPerBarrel;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Bullets cannot be below zero!");
                }
                this.bulletsPerBarrel = value;
            }
        }
        public int TotalBullets
        {
            get
            {
                return this.totalBullets;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Total bullets cannot be below zero!");
                }
                this.totalBullets = value;
            }
        }
        public bool CanFire => this.bulletsPerBarrel > 0 && this.totalBullets > 0;

        public int CountOfBullets { get; }

        public int Fire()
        {
            if (this.currentBullets >= bulletsPerShot)
            {
                this.currentBullets -= bulletsPerShot;
                return bulletsPerShot;
            }
            else if (this.Reload())
            {
                return this.Fire();
            }
            return 0;
        }

        public bool Reload()
        {
            if (this.TotalBullets == 0) return false;
            if (this.TotalBullets > this.BulletsPerBarrel)
            {
                this.TotalBullets -= BulletsPerBarrel;
                this.currentBullets = this.BulletsPerBarrel;
                return true;
            }
            this.currentBullets = this.TotalBullets;
            this.TotalBullets = 0;
            return true;
        }
    }
}
