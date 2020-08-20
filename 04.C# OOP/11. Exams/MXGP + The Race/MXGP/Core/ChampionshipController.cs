using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using MXGP.Core.Contracts;
using MXGP.Models.Riders;
using MXGP.Models.Riders.Contracts;
using MXGP.Models.Races;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Motorcycles;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Utilities.Messages;
using MXGP.Repositories;
using MXGP.Repositories.Contracts;

namespace MXGP.Core
{
    public class ChampionshipController : IChampionshipController
    {
        private IRepository<IRider> riders;
        private IRepository<IMotorcycle> motors;
        private IRepository<IRace> races;

        public ChampionshipController()
        {
            this.riders = new RiderRepository();
            this.motors = new MotorcycleRepository();
            this.races = new RaceRepository();
        }
        public string AddMotorcycleToRider(string riderName, string motorcycleModel)
        {
            var rider = this.riders.GetByName(riderName);
            if (rider == null) throw new InvalidOperationException(String.Format(ExceptionMessages.RiderNotFound, riderName));
            var motor = this.motors.GetByName(motorcycleModel);
            if (motor == null) throw new InvalidOperationException(String.Format(ExceptionMessages.MotorcycleNotFound, motorcycleModel));
            rider.AddMotorcycle(motor);
            return String.Format(OutputMessages.MotorcycleAdded, riderName, motorcycleModel);
        }

        public string AddRiderToRace(string raceName, string riderName)
        {
            var race = races.GetByName(raceName);
            if (race == null) throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            var rider = riders.GetByName(riderName);
            if (rider == null) throw new InvalidOperationException(String.Format(ExceptionMessages.RiderNotFound, riderName));
            race.AddRider(rider);
            return String.Format(OutputMessages.RiderAdded, riderName, raceName);
        }

        public string CreateMotorcycle(string type, string model, int horsePower)
        {
            var checkMoto = motors.GetByName(model);
            if (checkMoto != null) throw new ArgumentException(String.Format(ExceptionMessages.MotorcycleExists, model));
            
            switch (type)
            {
                case "Speed": motors.Add(new SpeedMotorcycle(model,horsePower)); break;
                case "Power": motors.Add(new PowerMotorcycle(model, horsePower)); break;
            }
            return String.Format(OutputMessages.MotorcycleCreated, type, model);
        }

        public string CreateRace(string name, int laps)
        {
            var checkRace = races.GetByName(name);
            if (checkRace != null) throw new InvalidOperationException(String.Format(ExceptionMessages.RaceExists, name));
            races.Add(new Race(name, laps));
            return String.Format(OutputMessages.RaceCreated, name);
        }

        public string CreateRider(string riderName)
        {
            var checkRider = this.riders.GetByName(riderName);
            if (checkRider != null) throw new ArgumentException(string.Format(ExceptionMessages.RiderExists, riderName));
            riders.Add(new Rider(riderName));
            return string.Format(OutputMessages.RiderCreated,riderName);
        }

        public string StartRace(string raceName)
        {
            var minRacesrs = 3;
            var race = races.GetByName(raceName);
            if (race == null) throw new InvalidOperationException(String.Format(ExceptionMessages.RaceNotFound, raceName));
            if (race.Riders.Count < minRacesrs) throw new InvalidOperationException(String.Format(ExceptionMessages.RaceInvalid, raceName, minRacesrs));
            var raceResult = race.Riders.OrderByDescending(x => x.Motorcycle.CalculateRacePoints(race.Laps)).ToArray();
            var sb = new StringBuilder();
            sb.AppendLine(String.Format(OutputMessages.RiderFirstPosition,raceResult[0].Name,raceName));
            sb.AppendLine(String.Format(OutputMessages.RiderSecondPosition, raceResult[1].Name, raceName));
            sb.AppendLine(String.Format(OutputMessages.RiderThirdPosition, raceResult[2].Name, raceName));
            raceResult[0].WinRace();
            races.Remove(race);
            return sb.ToString().TrimEnd();            
        }
    }
}
