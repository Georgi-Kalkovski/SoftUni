using SantaWorkshop.Models.Dwarfs.Contracts;
using SantaWorkshop.Models.Presents.Contracts;
using SantaWorkshop.Models.Workshops.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SantaWorkshop.Models.Workshops
{
    public class Workshop : IWorkshop
    {
        public Workshop()
        {
        }

        public void Craft(IPresent present, IDwarf dwarf)
        {
            while (present.EnergyRequired != 0 && dwarf.Energy > 0 && dwarf.Instruments.Count > 0)
            {
                dwarf.Work();
                present.GetCrafted();
            }
        }
    }
}
