namespace MuOnline.Models.Monsters
{
    public class BudgeDragon : Monster
    {
        private const int attackPoints = 20;
        private const int defensePoints = 50;

        public BudgeDragon()
            : base(attackPoints, defensePoints)
        {
        }
    }
}
