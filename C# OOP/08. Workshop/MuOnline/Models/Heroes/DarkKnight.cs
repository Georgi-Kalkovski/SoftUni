namespace MuOnline.Models.Heroes
{
    public class DarkKnight : Hero
    {
        private const int strength = 60;
        private const int agility = 40;
        private const int stamina = 30;
        private const int energy = 20;

        public DarkKnight(string username)
            : base(username, strength, agility, stamina, energy)
        {
        }
    }
}
