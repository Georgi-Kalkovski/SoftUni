using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Models.Astronauts
{
    public class Meteorologist : Astronaut
    {
        private const double personalOxygen = 90.0;

        public Meteorologist(string name)
            : base(name, personalOxygen)
        {
        }
    }
}
