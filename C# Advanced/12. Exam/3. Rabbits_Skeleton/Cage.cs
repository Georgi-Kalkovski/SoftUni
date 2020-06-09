using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rabbits
{
    public class Cage
    {
        private List<Rabbit> rabbits;
        private string rabbitSold;

        public string RabbitSold
        {
            get { return rabbitSold; }
            set { rabbitSold = value; }
        }

        public Cage(string name, int capacity)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.rabbits = new List<Rabbit>();
            
        }
        
        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count
        {
            get { return this.rabbits.Count; }
        }

        public void Add(Rabbit rabbit)
        {
            if (this.rabbits.Count < this.Capacity)
            {
                this.rabbits.Add(rabbit);
            }
        }
        public bool RemoveRabbit(string name)
        {
            foreach (var rabbit in this.rabbits)
            {
                if (rabbit.Name == name)
                {
                    this.rabbits.Remove(rabbit);

                    return true;
                }
            }

            return false;
        }
        public bool RemoveSpecies(string species)
        {
            foreach (var rabbit in this.rabbits)
            {
                if (rabbit.Species == species)
                {
                    this.rabbits.Remove(rabbit);

                    return true;
                }
            }

            return false;
        }
            

        public bool SellRabbit(string name)
        {
            var isExist = this.rabbits.Any(x => x.Name == name);
            this.rabbits = this.rabbits.Where(x => x.Name != name).ToList();
            return isExist;
        }

        public Rabbit[] SellRabbitsBySpecies(string species)
        {
            var isExist = this.rabbits.Any(x => x.Name == species);
            this.rabbits = this.rabbits.Where(x => x.Name != species).ToList();
            return rabbits.ToArray();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Rabbits available at {this.Name}:");

            foreach (var rabbit in this.rabbits)
            {
                sb.AppendLine(rabbit.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}

