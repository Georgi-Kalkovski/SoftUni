namespace MuOnline.Models.Inventories
{
    using System.Collections.Generic;
    using Contracts;
    using Items.Contracts;

    public class Inventory : IInventory
    {
        public IReadOnlyCollection<IItem> Items { get; set; }

        public void AddItem(IItem item)
        {
            throw new System.NotImplementedException();
        }

        public bool RemoveItem(IItem item)
        {
            throw new System.NotImplementedException();
        }

        public IItem GetItem(string item)
        {
            throw new System.NotImplementedException();
        }
    }
}
