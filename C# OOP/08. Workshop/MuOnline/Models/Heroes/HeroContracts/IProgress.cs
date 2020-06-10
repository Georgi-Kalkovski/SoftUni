namespace MuOnline.Models.Heroes.HeroContracts
{
    public interface IProgress
    {
        int Experience { get; }

        int Level { get; }

        int Resets { get; }

        void AddExperience(int experience);
    }
}
