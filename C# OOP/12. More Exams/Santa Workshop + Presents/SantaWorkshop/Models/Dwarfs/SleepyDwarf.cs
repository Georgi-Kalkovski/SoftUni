using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Models.Dwarfs
{
    public class SleepyDwarf : Dwarf
    {
        private const int InitialEnergy = 50;
        public SleepyDwarf(string name)
            : base(name, InitialEnergy)
        {
        }
        public override void Work()
        {
            if (Energy - 15 >= 0)
            {
                Energy -= 15;
            }
            if (Energy < 0)
            {
                Energy = 0;
            }
        }
    }
}
}
