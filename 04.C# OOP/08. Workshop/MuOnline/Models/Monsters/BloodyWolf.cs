namespace MuOnline.Models.Monsters
{
    public class BloodyWolf : Monster
    {
        private const int attackPoints = 80;
        private const int defensePoints = 50;

        public BloodyWolf() 
            : base(attackPoints, defensePoints)
        {
        }
    }
}
