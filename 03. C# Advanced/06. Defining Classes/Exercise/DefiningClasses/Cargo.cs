using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    public class Cargo
    {
        private int cargoWeight;
        private string cargoType;
        public int CargoWeight
        {
            get { return cargoWeight; }
            set { cargoWeight = value; }
        }
        public string CargoType
        {
            get { return cargoType; }
            set { cargoType = value; }
        }
    }
}
