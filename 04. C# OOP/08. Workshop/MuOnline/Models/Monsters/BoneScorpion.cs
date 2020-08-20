namespace MuOnline.Models.Monsters
{
    public class BoneScorpion : Monster
    {
        private const int attackPoints = 1000;
        private const int defensePoints = 80;

        public BoneScorpion()
            : base(attackPoints, defensePoints)
        {
        }
    }
}
