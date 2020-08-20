namespace SantaWorkshop.Models.Dwarfs.Contracts
{
    using System;
    using System.Collections.Generic;

    using SantaWorkshop.Models.Instruments.Contracts;

    public interface IDwarf
    {
        string Name { get; }

        int Energy { get; }

        ICollection<IInstrument> Instruments { get; }

        abstract void Work();

        void AddInstrument(IInstrument instrument);
    }
}
