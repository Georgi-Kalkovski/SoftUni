using SpaceStation.Core.Contracts;
using SpaceStation.Models.Astronauts;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Mission;
using SpaceStation.Models.Planets;
using SpaceStation.Repositories;
using SpaceStation.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Core
{
    public class Controller : IController
    {
        private readonly PlanetRepository planets;
        private AstronautRepository astronauts;
        private readonly Mission mission;

        public Controller()
        {
            this.planets = new PlanetRepository();
            this.astronauts = new AstronautRepository();
            this.mission = new Mission();
        }

        public string AddAstronaut(string type, string astronautName)
        {
            if (type == null)
            {
                throw new ArgumentNullException(String.Format(ExceptionMessages.InvalidAstronautType));
            }
            if (astronautName == null)
            {
                throw new ArgumentNullException(String.Format(ExceptionMessages.InvalidAstronautName));
            }
            switch (type)
            {
                case "Biologist":
                    {
                        astronauts.Add(new Biologist(astronautName));
                        return String.Format(OutputMessages.AstronautAdded, type, astronautName);
                    }
                case "Geodesist":
                    {
                        astronauts.Add(new Geodesist(astronautName));
                        return String.Format(OutputMessages.AstronautAdded, type, astronautName);
                    }
                case "Meteorologist":
                    {
                        astronauts.Add(new Meteorologist(astronautName));
                        return String.Format(OutputMessages.AstronautAdded, type, astronautName);
                    }
                default: throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidAstronautType));
            }
        }

        public string AddPlanet(string planetName, params string[] items)
        {
            if (planetName == null)
            {
                throw new ArgumentNullException(String.Format(ExceptionMessages.InvalidPlanetName));
            }
            var planet = new Planet(planetName);
            foreach (var item in items)
            {
                planet.Items.Add(item);
            }
            planets.Add(planet);
            return String.Format(OutputMessages.PlanetAdded, planetName);
        }

        public string RetireAstronaut(string astronautName)
        {
            var astronaut = astronauts.FindByName(astronautName);
            if (astronaut == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidRetiredAstronaut, astronautName));
            }
            astronauts.Remove(astronaut);
            return String.Format(OutputMessages.AstronautRetired, astronautName);
        }

        public string ExplorePlanet(string planetName)
        {
            if (planetName == null)
            {
                throw new ArgumentNullException(String.Format(ExceptionMessages.InvalidPlanetName));
            }
            var suitableAstronauts = astronauts.Models.Where(x => x.Oxygen > 60).ToList();
            var planet = planets.FindByName(planetName);
            if (suitableAstronauts.Count == 0)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.InvalidAstronautCount));
            }
            mission.Explore(planet, suitableAstronauts);
            if (planet.Items.Count == 0)
            { 
                planets.Remove(planet); 
            }
            return String.Format(OutputMessages.PlanetExplored, planetName, mission.AstroCounter);
        }


        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{mission.PlanetCounter} planets were explored!");
            sb.AppendLine("Astronauts info:");
            foreach (var astronaut in astronauts.Models)
            {
                sb.AppendLine($"Name: {astronaut.Name}");
                sb.AppendLine($"Oxygen: {astronaut.Oxygen}");
                sb.Append("Bag items: ");
                if (astronaut.Bag.Items.Count == 0)
                {
                    sb.Append("none");
                }
                else
                {
                    sb.Append(string.Join(", ", astronaut.Bag.Items));
                }
                sb.AppendLine();
            }
            return sb.ToString().TrimEnd();
        }
    }
}
