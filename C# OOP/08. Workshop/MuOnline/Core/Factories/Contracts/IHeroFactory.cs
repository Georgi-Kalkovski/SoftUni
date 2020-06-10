namespace MuOnline.Core.Factories.Contracts
{
    using Models.Heroes.HeroContracts;

    public interface IHeroFactory
    {
        IHero Create(string heroType, string username);
    }
}
