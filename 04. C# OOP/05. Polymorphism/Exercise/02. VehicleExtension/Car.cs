﻿namespace VehicleExtension
{
    using System;
    public class Car : Vehicle
    {
        private const double additionalConsumptionPerKm = 0.9;
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption,tankCapacity)
        {
        }

        protected override double AdditionalConsumption 
            => additionalConsumptionPerKm;
    }
}
