using System;
using System.Collections.Generic;
using System.Linq;
using MXGP.Models.Races.Contracts;
using MXGP.Models.Riders.Contracts;
using MXGP.Utilities.Messages;

namespace MXGP.Models.Races
{
    public class Race : IRace
    {
        private const int minNameLength = 5;
        private const int minLaps = 1;
        private List<IRider> riders;
        public Race(string name, int laps)
        {
            if (name.Length < minNameLength || string.IsNullOrEmpty(name)) 
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidName,name, minNameLength));
            this.Name = name;
            if (laps < minLaps) throw new ArgumentException(String.Format(ExceptionMessages.InvalidNumberOfLaps,minLaps));
            this.Laps = laps;
            this.riders = new List<IRider>();
        }
        public string Name { get; }

        public int Laps { get; }

        public IReadOnlyCollection<IRider> Riders => this.riders.AsReadOnly();

        public void AddRider(IRider rider)
        {
            if (rider == null) throw new ArgumentNullException(ExceptionMessages.RiderInvalid);
            if (!rider.CanParticipate)
                throw new ArgumentException(String.Format(ExceptionMessages.RiderNotParticipate, rider.Name));
            var checkRider = this.Riders.Where(x => x.Name == rider.Name);
            if (checkRider.Any()) 
                throw new ArgumentNullException(String.Format(ExceptionMessages.RiderAlreadyAdded, rider.Name, this.Name));
            this.riders.Add(rider);
        }
    }
}
