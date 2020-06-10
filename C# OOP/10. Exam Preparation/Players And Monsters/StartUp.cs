using System;

namespace PlayersAndMonsters
{
    using Core;
    using Core.Contracts;
    using Core.Factories;
    using Core.Factories.Contracts;
    using Repositories;
    using Repositories.Contracts;
    using IO;
    using IO.Contracts;
    using Models.BattleFields;
    using Models.BattleFields.Contracts;

    public class StartUp
    {
        public static void Main()
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new FileWriter();

            IPlayerRepository playerRepository = new PlayerRepository();
            IPlayerFactory playerFactory = new PlayerFactory();
            ICardFactory cardFactory = new CardFactory();
            ICardRepository cardRepository = new CardRepository();
            IBattleField battleField = new BattleField();

            IManagerController managerController = new ManagerController(
                playerRepository,
                playerFactory,
                cardFactory,
                cardRepository,
                battleField);

            IEngine engine = new Engine(
                reader,
                writer,
                managerController);

            engine.Run();
        }
    }
}