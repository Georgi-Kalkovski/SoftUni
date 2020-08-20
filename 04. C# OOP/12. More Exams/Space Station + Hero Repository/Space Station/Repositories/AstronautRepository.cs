using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Repositories.Contracts;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<IAstronaut>
    {
        private List<IAstronaut> models;

        public AstronautRepository()
        {
            this.models = new List<IAstronaut>();
        }

        public IReadOnlyCollection<IAstronaut> Models => models.AsReadOnly();

        public void Add(IAstronaut model)
        {
            if (model == null || models.Contains(model))
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidAstronautName));
            }
            models.Add(model);
        }

        public IAstronaut FindByName(string name)
        {
            return models.Find(x=>x.Name == name);
        }

        public bool Remove(IAstronaut model)
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
