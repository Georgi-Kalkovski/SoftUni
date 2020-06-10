using System;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Models.Riders.Contracts;
using MXGP.Utilities.Messages;

namespace MXGP.Models.Riders
{
    class Rider : IRider
    {
        private const int minNameLength = 5;
        public Rider(string name)
        {
            if (string.IsNullOrWhiteSpace(name) || name.Length < minNameLength)
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidName,name, minNameLength));
            this.Name = name;
        }
        public string Name { get; }

        public IMotorcycle Motorcycle { get; private set; }

        public int NumberOfWins { get; private set; }

        public bool CanParticipate => this.Motorcycle != null;

        public void AddMotorcycle(IMotorcycle motorcycle)
        {
            if (motorcycle == null) throw new ArgumentNullException(ExceptionMessages.MotorcycleInvalid);
            this.Motorcycle = motorcycle;
        }

        public void WinRace()
        {
            this.NumberOfWins++;
        }
    }
}
