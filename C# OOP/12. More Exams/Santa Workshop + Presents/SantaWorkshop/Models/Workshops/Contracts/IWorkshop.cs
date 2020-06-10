namespace SantaWorkshop.Models.Workshops.Contracts
{
    using System;

    using SantaWorkshop.Models.Dwarfs.Contracts;
    using SantaWorkshop.Models.Presents.Contracts;

    public interface IWorkshop
    {
        void Craft(IPresent present, IDwarf dwarf);
    }
}
