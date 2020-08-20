using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Geodesist : Astronaut
    {
        private const double InitialOxygen = 50;
        public Geodesist(string name)
            : base(name, InitialOxygen)
        {
        }
    }
}
