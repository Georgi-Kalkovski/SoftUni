namespace MuOnline.Models.Items.Contracts
{
    public interface IItem
    {
        int Strength { get; }

        int Agility { get; }

        int Stamina { get; }

        int Energy { get; }
    }
}
