using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Models.Guns.Contracts;

namespace ViceCity.Models.Guns
{
    public class Pistol : Gun, IGun
    {
        private const int PistolBulletsPerBarrel = 10;
        private const int PistolTotalBullets = 100;

        public Pistol(string name) 
            : base(name, PistolBulletsPerBarrel, PistolTotalBullets)
        {
        }
    }
}
