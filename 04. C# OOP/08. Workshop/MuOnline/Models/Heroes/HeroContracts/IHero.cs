using MuOnline.Models.Inventories.Contracts;

namespace MuOnline.Models.Heroes.HeroContracts
{
    public interface IHero
    {
        int Strength { get; }

        int Agility { get; }

        int Stamina { get; }

        int Energy { get; }

        IInventory Inventory { get; }

        bool IsAlive { get; }

        void TakeDamage(int damagePoints);

        int TotalAttackPoints { get; }

        int TotalStaminaPoints { get; }

        int TotalAgilityPoints { get; }

        int TotalEnergyPoints { get; }
    }
}
