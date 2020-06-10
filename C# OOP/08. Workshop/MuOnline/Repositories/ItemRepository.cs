namespace MuOnline.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using MuOnline.Models.Items.Contracts;

    public class ItemRepository : IRepository<IItem>
    {
        private readonly List<IItem> itemRepository;

        public ItemRepository()
        {
            this.itemRepository = new List<IItem>();
        }

        public IReadOnlyCollection<IItem> Repository
            => this.itemRepository.AsReadOnly();

        public void Add(IItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Item cannot be null!");
            }

            this.itemRepository.Add(item);
        }

        public bool Remove(IItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Item cannot be null!");
            }

            bool isRemoved = this.itemRepository.Remove(item);

            return isRemoved;
        }

        public IItem Get(string item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Item cannot be null!");
            }

            var targetItem = this.itemRepository.FirstOrDefault(x => x.GetType().Name == item);

            return targetItem;
        }
    }
}
