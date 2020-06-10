using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Models.Dwarfs
{
    public class HappyDwarf : Dwarf
    {
        private const int InitialEnergy = 100;
        public HappyDwarf(string name)
            : base(name, InitialEnergy)
        {
        }
        public override void Work()
        {
            if (Energy - 10 >= 0)
            {
                Energy -= 10;
            }
            if (Energy < 0)
            {
                Energy = 0;
            }
        }
    }
}
