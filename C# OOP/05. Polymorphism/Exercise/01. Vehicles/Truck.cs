namespace Vehicles
{
    using System;
    public class Truck: Vehicle
    {
        private const double additionalConsumption = 1.6;
        private const double refuelingCoefficient = 0.95;

        public Truck(double fuelQuantity, double fuelConsumption) 
            : base(fuelQuantity, fuelConsumption)
        {
        }

        protected override double AdditionalConsumption 
            => additionalConsumption;

        public override void Refuel(double fuel)
        {
            base.Refuel(fuel * refuelingCoefficient);
        }
    }
}
