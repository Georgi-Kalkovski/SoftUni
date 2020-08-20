using System;
using System.Collections.Generic;
using System.Text;

namespace Rabbits
{
    public class Rabbit
    {
        private string name;
        private string species;
        private bool available = true;

        public Rabbit(string species, string name)
        {
            Species = species;
            Name = name;
        }

        public bool Available
        {
            get { return available; }
            set { available = value; }
        }


        public string Species
        {
            get { return species; }
            set { species = value; }
        }


        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public override string ToString()
        {
            return $"Rabbit ({species}): {name}";
        }
    }
}
