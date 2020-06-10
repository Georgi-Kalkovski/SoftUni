namespace MuOnline.Core.Factories.Contracts
{
    using Models.Items.Contracts;

    public interface IItemFactory
    {
        IItem Create(string itemType);
    }
}
