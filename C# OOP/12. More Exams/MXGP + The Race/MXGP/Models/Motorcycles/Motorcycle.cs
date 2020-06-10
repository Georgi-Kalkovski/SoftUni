using MXGP.Models.Motorcycles.Contracts;
using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public abstract class Motorcycle : IMotorcycle
    {
        private string model;
        private int horsePower;
        private double cubicCentimeters;

        public Motorcycle(string model, int horsePower, double cubicCentimeters)
        {
            Model = model;
            HorsePower = horsePower;
            CubicCentimeters = cubicCentimeters;
        }

        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidModel, value, 4));
                }
                model = value;
            }
        }

        public int HorsePower
        {
            get => horsePower;
            private set => horsePower = value;
        }

        public double CubicCentimeters
        {
            get => cubicCentimeters;
            private set => cubicCentimeters = value;
        }

        public double CalculateRacePoints(int laps)
        {
            var racePoints = CubicCentimeters / HorsePower * laps;
            return racePoints;
        }
    }
}
