using SpaceStation.Models.Planets;
using SpaceStation.Repositories.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly List<IPlanet> models;

        public PlanetRepository()
        {
            this.models = new List<IPlanet>();
        }

        public IReadOnlyCollection<IPlanet> Models => models.AsReadOnly();

        public void Add(IPlanet model)
        {
            if (model == null || models.Contains(model))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidPlanetName));
            }
            models.Add(model);
        }

        public IPlanet FindByName(string name)
        {
            return models.Find(x => x.Name == name);
        }

        public bool Remove(IPlanet model)
        {
            if (models.Contains(model))
            {
                models.Remove(model);
                return true;
            }
            return false;
        }
    }
}
