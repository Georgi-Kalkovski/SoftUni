using MXGP.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace MXGP.Models.Motorcycles
{
    public class PowerMotorcycle : Motorcycle
    {
        private const int MinHorsePower = 70;
        private const int MaxHorsePower = 100;
        private const int InitialcubicCentimeters = 450;
        public PowerMotorcycle(string model, int horsePower) 
            : base(model, horsePower, InitialcubicCentimeters)
        {
            if (horsePower < MinHorsePower || horsePower > MaxHorsePower)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidHorsePower, horsePower));
            }
        }
    }
}
