namespace MuOnline.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;
    using Models.Items.Contracts;

    public class ItemFactory : IItemFactory
    {
        public IItem Create(string itemType)
        {
            var type = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(x => x.Name.ToLower() == itemType);

            if (type == null)
            {
                throw new ArgumentNullException("Invalid item type!");
            }

            var item = (IItem)Activator.CreateInstance(type);

            return item;
        }
    }
}
