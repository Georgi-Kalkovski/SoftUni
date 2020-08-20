using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const double personalOxygen = 70.0;

        public Biologist(string name)
            : base(name, personalOxygen)
        {
        }
    }
}
