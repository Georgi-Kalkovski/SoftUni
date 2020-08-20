namespace MuOnline.Core.Factories.Contracts
{
    using Models.Monsters.Contracts;

    public interface IMonsterFactory
    {
        IMonster Create(string monsterType, int attackPoints, int defensePoints);
    }
}
