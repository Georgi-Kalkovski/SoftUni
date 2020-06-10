using System;
using System.Collections.Generic;
using System.Text;
using ViceCity.Core.Contracts;
using ViceCity.Core.Factories.Contracts;
using ViceCity.Models.Neghbourhoods.Contracts;
using ViceCity.Repositories;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Core
{
    public class Controller : IController
    {
        private GunRepository gunRepository;
        private IGunFactory gunFactory;
        private INeighbourhood battleField;

        public Controller(GunRepository gunRepository, IGunFactory gunFactory, INeighbourhood battleField)
        {
            this.gunRepository = gunRepository;
            this.gunFactory = gunFactory;
            this.battleField = battleField;
        }

        public string AddGun(string type, string name)
        {
            var gun = this.gunFactory.CreateGun(type, name);

            this.gunRepository.Add(gun);

            return $"Successfully added civil player: {civilPlayerName}!";
        }

        public string AddGunToPlayer(string name)
        {
            throw new NotImplementedException();
        }

        public string AddPlayer(string name)
        {
            throw new NotImplementedException();
        }

        public string Fight()
        {
            throw new NotImplementedException();
        }
    }
}
