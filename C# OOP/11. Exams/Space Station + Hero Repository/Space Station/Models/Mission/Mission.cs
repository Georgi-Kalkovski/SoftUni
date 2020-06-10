using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        
        private List<IAstronaut> astronautsOnPlanet = new List<IAstronaut>();
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            if (planet == null)
            {
                throw new ArgumentNullException("Planet cannot be null");
            }

            foreach (var astronaut in astronauts)
            {
                if (!astronaut.CanBreath || astronautsOnPlanet.Contains(astronaut))
                {
                    continue;
                }

                else
                {
                    astronautsOnPlanet.Add(astronaut);
                }
            }
            foreach (var astronaut in astronautsOnPlanet)
            {
                while (astronaut.Oxygen > 0.0)
                {
                    astronaut.Bag.Items.Add(planet.Items.Last());
                    planet.Items.Remove(planet.Items.Last());
                    astronaut.Breath();
                }
            }
        }
    }
}
