namespace MuOnline.Core.Commands
{
    using Contracts;
    using Factories.Contracts;
    using Models.Items.Contracts;
    using Repositories.Contracts;

    public class AddItemCommand : ICommand
    {
        private readonly IRepository<IItem> itemRepository;
        private readonly IItemFactory itemFactory;

        public AddItemCommand(IRepository<IItem> itemRepository, IItemFactory itemFactory)
        {
            this.itemRepository = itemRepository;
            this.itemFactory = itemFactory;
        }

        public string Execute(string[] inputArgs)
        {
            var itemType = inputArgs[0].ToLower();

            var item = this.itemFactory.Create(itemType);

            this.itemRepository.Add(item);

            return $"Successfully created new {itemType}!";
        }
    }
}
