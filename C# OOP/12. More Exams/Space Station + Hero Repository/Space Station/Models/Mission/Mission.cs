using SpaceStation.Models.Astronauts.Contracts;
using SpaceStation.Models.Planets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStation.Models.Mission
{
    public class Mission : IMission
    {
        public int AstroCounter { get; protected set; }
        public int PlanetCounter { get; protected set; }
        public void Explore(IPlanet planet, ICollection<IAstronaut> astronauts)
        {
            foreach (var astronaut in astronauts.Where(x=>x.Oxygen > 60))
            {
                while (astronaut.CanBreath || planet.Items.Count == 0)
                {
                    var item = planet.Items.FirstOrDefault();
                    astronaut.Bag.Items.Add(item);
                    planet.Items.Remove(item);
                    astronaut.Breath();
                }
                if (astronaut.CanBreath == false)
                {
                    AstroCounter++;
                }
                if ((planet.Items.Count == 0))
                {
                    PlanetCounter++;
                }
            }
        }
    }
}
