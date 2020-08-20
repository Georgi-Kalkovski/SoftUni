using MXGP.Core.Contracts;
using MXGP.Models.Motorcycles;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Races;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders;
using MXGP.Models.Riders.Contracts;
using MXGP.Repositories;
using MXGP.Repositories.Contracts;
using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private readonly IRepository<IMotorcycle> motorcycles;
        private readonly IRepository<IRace> races;
        private readonly IRepository<IRider> riders;

        public ChampionshipController()
        {
            this.motorcycles = new MotorcycleRepository();
            this.races = new RaceRepository();
            this.riders = new RiderRepository();
        }

        public string CreateRider(string riderName)
        {
            var rider = riders.GetByName(riderName);

            if (rider != null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.RiderExists, riderName));
            }
            riders.Add(new Rider(riderName));
            return String.Format(OutputMessages.RiderCreated, riderName);
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            var moto = motorcycles.GetByName(model);
            if (moto != null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.MotorcycleExists, model));
            }
            switch (type)
            {
                case "Power":
                    {
                        motorcycles.Add(new PowerMotorcycle(model, horsePower));
                        return String.Format(OutputMessages.MotorcycleCreated, "PowerMotorcycle", model);
                    }
                case "Speed":
                    {
                        motorcycles.Add(new SpeedMotorcycle(model, horsePower));
                        return String.Format(OutputMessages.MotorcycleCreated, "SpeedMotorcycle", model);
                    }
                default: throw new ArgumentException(String.Format(ExceptionMessages.MotorcycleExists, model));
            }
        }

        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            var rider = riders.GetByName(riderName);
            var motorcycle = motorcycles.GetByName(motorcycleModel);

            if (rider == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RiderNotFound, riderName));
            }
            if (motorcycle == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.MotorcycleNotFound, motorcycleModel));
            }
            rider.AddMotorcycle(motorcycle);
            return String.Format(OutputMessages.MotorcycleAdded, riderName, motorcycleModel);
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            var rider = riders.GetByName(riderName);
            var race = races.GetByName(raceName);

            if (rider == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RiderNotFound, riderName));
            }
            if (race == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            }
            race.AddRider(rider);
            return String.Format(OutputMessages.RiderAdded, riderName, raceName);
        }

        public string CreateRace(string name, int laps)
        {
            var race = new Race(name, laps);
            if (races.GetByName(name) == null)
            {
                races.Add(race);
                return String.Format(OutputMessages.RaceCreated, name);
            }
            throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExists, name));
        }

        public string StartRace(string raceName)
        {
            if (races.GetByName(raceName) == null)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            }

            var race = races.GetByName(raceName);

            if (race.Riders.Count < 3)
            {
                throw new InvalidOperationException(String.Format(ExceptionMessages.RaceInvalid, raceName, 3));
            }

            var arrangedRiders = race.Riders.OrderByDescending(x => x.Motorcycle.CalculateRacePoints(race.Laps)).ToList();
            
            var sb = new StringBuilder();
            sb.AppendLine(String.Format(OutputMessages.RiderFirstPosition, arrangedRiders[0].Name, raceName));
            sb.AppendLine(String.Format(OutputMessages.RiderSecondPosition, arrangedRiders[1].Name, raceName));
            sb.AppendLine(String.Format(OutputMessages.RiderThirdPosition, arrangedRiders[2].Name, raceName));
            arrangedRiders[0].WinRace();
            races.Remove(race);
            return sb.ToString().TrimEnd();
        }
    }
}
