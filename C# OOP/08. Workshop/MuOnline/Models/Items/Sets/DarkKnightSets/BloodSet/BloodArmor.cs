namespace MuOnline.Models.Items.Sets.DarkKnightSets.BloodSet
{
    public class BloodArmor : Item
    {
        private const int strengthPoints = 10;
        private const int agilityPoints = 30;
        private const int energyPoints = 0;
        private const int staminaPoints = 25;

        public BloodArmor() 
            : base(strengthPoints, agilityPoints, energyPoints, staminaPoints)
        {
        }
    }
}
