using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Models.Dwarfs
{
    public class HappyDwarf : Dwarf
    {
        private const int initialEnergy = 100;
        public HappyDwarf(string name) 
            : base(name, initialEnergy)
        {
        }

        public override void Work()
        {
            Energy -= 10;
            if (Energy < 0)
            {
                Energy = 0;
            }
        }
    }
}
