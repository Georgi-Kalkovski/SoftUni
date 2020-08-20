namespace Cars
{
    using System;
    using System.Linq;
    public class Tesla : Car, ICar, IElectricCar
    {
        public Tesla(string model, string color, int battery)
            : base(model, color)
        {
            Battery = battery;
        }
        public int Battery { get; private set; }

        protected override string GetCarInfo()
        {
            return base.GetCarInfo() + $" with {Battery} Batteries";
        }
    }
}