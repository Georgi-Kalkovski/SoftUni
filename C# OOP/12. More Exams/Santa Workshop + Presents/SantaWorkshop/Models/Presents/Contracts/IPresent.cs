namespace SantaWorkshop.Models.Presents.Contracts
{
    using System;

    public interface IPresent
    {
        string Name { get; }

        int EnergyRequired { get; }

        void GetCrafted();

        bool IsDone();
    }
}
