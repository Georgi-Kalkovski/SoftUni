using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceStationRecruitment
{
    public class SpaceStation
    {
        private List<Astronaut> astronauts;

        public SpaceStation(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;

            this.astronauts = new List<Astronaut>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int Count
        {
            get { return this.astronauts.Count; }
        }

        public void Add(Astronaut astronaut)
        {
            if (this.astronauts.Count < this.Capacity)
            {
                this.astronauts.Add(astronaut);
            }
        }

        public bool Remove(string name)
        {
            foreach (var astronaut in this.astronauts)
            {
                if (astronaut.Name == name)
                {
                    this.astronauts.Remove(astronaut);

                    return true;
                }
            }

            return false;
        }

        public Astronaut GetOldestAstronaut()
        {
            //Astronaut result = new Astronaut(string.Empty, int.MinValue, string.Empty);

            //foreach (var astronaut in this.astronauts)
            //{
            //    if (astronaut.Age > result.Age)
            //    {
            //        result = astronaut;
            //    }
            //}

            //return result;

            return this.astronauts.OrderByDescending(a => a.Age).FirstOrDefault();
        }

        public Astronaut GetAstronaut(string name)
        {
            Astronaut result = null;
            foreach (var astronaut in this.astronauts)
            {
                if (astronaut.Name == name)
                {
                    result = astronaut;
                    break;
                }
            }

            return result;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Astronauts working at Space Station {this.Name}:");

            foreach (var astronaut in this.astronauts)
            {
                sb.AppendLine(astronaut.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}