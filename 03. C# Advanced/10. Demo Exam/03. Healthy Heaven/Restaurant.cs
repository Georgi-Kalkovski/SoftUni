using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyHeaven
{
    public class Restaurant
    {
        private Salad data;
        private string name;

        public Restaurant(string name)
        {
            Name = name;
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public Salad Data
        {
            get { return data; }
            set { data = value; }
        }

        public Salad Add(Salad salad)
        {
            salad = salad.Add(name);
        }
        public string Buy(string name)
        {

        }
        public bool GetHealthiestSalad()
        {
            return;
        }
        public bool GenerateMenu()
        {
            return Console.WriteLine($"{ name} have { salad count} salads: {string.Join("\n", Salad)}");
        }
    }
}
