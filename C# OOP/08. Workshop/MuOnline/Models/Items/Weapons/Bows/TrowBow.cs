namespace MuOnline.Models.Items.Weapons.Bows
{
    public class TrowBow : Item
    {
        private const int strengthPoints = 25;
        private const int agilityPoints = 5;
        private const int energyPoints = 10;
        private const int staminaPoints = 0;

        public TrowBow() 
            : base(strengthPoints, agilityPoints, energyPoints, staminaPoints)
        {
        }
    }
}
