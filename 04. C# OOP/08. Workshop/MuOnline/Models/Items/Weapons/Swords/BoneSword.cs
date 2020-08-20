namespace MuOnline.Models.Items.Weapons.Swords
{
    public class BoneSword : Item
    {
        private const int strengthPoints = 25;
        private const int agilityPoints = 5;
        private const int energyPoints = 10;
        private const int staminaPoints = 0;

        public BoneSword()
            : base(strengthPoints, agilityPoints, energyPoints, staminaPoints)
        {
        }
    }
}
