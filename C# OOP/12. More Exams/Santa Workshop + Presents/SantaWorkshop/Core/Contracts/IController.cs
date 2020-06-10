namespace SantaWorkshop.Core.Contracts
{
    using System;

    public interface IController
    {
        string AddDwarf(string dwarfType, string dwarfName);

        string AddInstrumentToDwarf(string dwarfName, int power);

        string AddPresent(string presentName, int energyRequired);

        string CraftPresent(string presentName);

        string Report();
    }
}
