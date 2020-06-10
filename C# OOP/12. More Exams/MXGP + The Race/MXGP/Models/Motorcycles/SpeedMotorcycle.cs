using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class SpeedMotorcycle : Motorcycle
    {
        private const int MinHorsePower = 50;
        private const int MaxHorsePower = 69;
        private const int InitialcubicCentimeters = 125;
        public SpeedMotorcycle(string model, int horsePower)
            : base(model, horsePower, InitialcubicCentimeters)
        {
            if (horsePower < MinHorsePower || horsePower > MaxHorsePower)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidHorsePower, horsePower));
            }
        }
    }
}
