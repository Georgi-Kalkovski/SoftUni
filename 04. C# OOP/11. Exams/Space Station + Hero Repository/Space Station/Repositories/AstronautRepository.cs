using SpaceStation.Models.Astronauts;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Repositories
{
    public class AstronautRepository : IRepository<Astronaut>
    {
        private readonly List<Astronaut> astronauts;
        public AstronautRepository(List<Astronaut> astronauts)
        {
            this.astronauts = new List<Astronaut>();
        }

        public IReadOnlyCollection<Astronaut> Models
            => this.astronauts.AsReadOnly();

        public void Add(Astronaut astronaut)
        {
            if (astronaut == null)
            {
                throw new ArgumentException($"Astronaut cannot be null!");
            }

            var astronautExists = this.astronauts
                .Any(x => x.Name == astronaut.Name);

            if (astronautExists)
            {
                throw new ArgumentException($"Astronaut {astronaut.Name} already exists!");
            }

            this.astronauts.Add(astronaut);
        }

        public bool Remove(Astronaut astronaut)
        {
            if (astronaut == null)
            {
                throw new ArgumentException($"Astronaut cannot be null!");
            }

            var isRemove = this.astronauts.Remove(astronaut);

            return isRemove;
        }

        public Astronaut FindByName(string name)
        {
            return this.astronauts
                .FirstOrDefault(x => x.Name == name);
        }
    }
}
