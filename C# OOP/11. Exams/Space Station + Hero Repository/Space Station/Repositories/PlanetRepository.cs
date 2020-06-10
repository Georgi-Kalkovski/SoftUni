using SpaceStation.Models.Planets;
using SpaceStation.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Repositories
{
    public class PlanetRepository : IRepository<IPlanet>
    {
        private readonly List<IPlanet> planets;

        public PlanetRepository()
        {
            this.planets = new List<IPlanet>();
        }

        public int Count
            => this.Models.Count;

        public IReadOnlyCollection<IPlanet> Models
            => this.planets.AsReadOnly();

        public void Add(IPlanet planet)
        {
            if (planet == null)
            {
                throw new ArgumentException($"Planet cannot be null!");
            }

            var planetExists = this.planets
                .Any(x => x.Name == planet.Name);

            if (planetExists)
            {
                throw new ArgumentException($"Planet {planet.Name} already exists!");
            }

            this.planets.Add(planet);
        }

        public bool Remove(IPlanet planet)
        {
            if (planet == null)
            {
                throw new ArgumentException($"Planet cannot be null!");
            }

            var isRemove = this.planets.Remove(planet);

            return isRemove;
        }

        public IPlanet FindByName(string name)
        {
            return this.planets
                .FirstOrDefault(x => x.Name == name);
        }
    }
}
