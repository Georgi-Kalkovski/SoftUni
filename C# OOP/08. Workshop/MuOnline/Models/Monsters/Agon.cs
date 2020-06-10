namespace MuOnline.Models.Monsters
{
    public class Agon : Monster
    {
        private const int attackPoints = 20;
        private const int defensePoints = 50;

        public Agon() 
            : base(attackPoints, defensePoints)
        {
        }
    }
}
