using System;
using MXGP.Models.Motorcycles.Contracts;
using MXGP.Utilities.Messages;

namespace MXGP.Models.Motorcycles
{
    public abstract class Motorcycle : IMotorcycle
    {
        private const int minModelNameLength = 4;
        protected Motorcycle(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            if (model.Length < minModelNameLength || string.IsNullOrWhiteSpace(model)) 
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidModel,model,minModelNameLength));
            this.Model = model;
            if (horsePower < minHorsePower || horsePower > maxHorsePower)
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidHorsePower, horsePower));
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;

        }
        public string Model { get; }

        public int HorsePower { get; }

        public double CubicCentimeters { get; }

        public double CalculateRacePoints(int laps)
        {
            double result =  this.CubicCentimeters / this.HorsePower * laps;
            return result;
        }
    }
}
