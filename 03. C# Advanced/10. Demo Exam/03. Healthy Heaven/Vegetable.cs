using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyHeaven
{
    public class Vegetable
    {
        private string name;
        private int calories;

        public Vegetable(string name, int calories)
        {
            Calories = calories;
            Name = name;
        }

        public int Calories
        {
            get { return calories; }
            set { calories = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public override string ToString()
        {
            return $" - {name} have {calories} calories";
        }
    }
}
