using AquaShop.Models.Aquariums.Contracts;
using AquaShop.Models.Decorations.Contracts;
using AquaShop.Models.Fish.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquaShop.Models.Aquariums
{
    public abstract class Aquarium : IAquarium
    {
        private string name;
        private int capacity;
        protected Aquarium(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
        }
        public string Name
        {
            get => name;
            protected set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Aquarium name cannot be null or empty.");
                }
                name = value;
            }
        }

        public int Capacity
        {
            get => capacity;
            private set
            {
                this.capacity = value;
            }
        }

        public ICollection<IDecoration> Decorations { get; }

        public ICollection<IFish> Fish { get; }

        public int Comfort
        {
            get
            {
                var sum = 0;

                foreach (var decoration in Decorations)
                {
                    sum += decoration.Comfort;
                }

                return sum;
            }
        }

        public void AddFish(IFish fish)
        {
            if (Fish.Count < Capacity)
            {
                Fish.Add(fish);
            }
            else
            {
                throw new InvalidOperationException("Not enough capacity.");
            }
        }

        public bool RemoveFish(IFish fish)
        {
            if (Fish.Contains(fish))
            {
                Fish.Remove(fish);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddDecoration(IDecoration decoration)
        {
            Decorations.Add(decoration);
        }

        public void Feed()
        {
            foreach (var fish in Fish)
            {
                fish.Eat();
            }
        }

        public string GetInfo()
        {
            if (Fish.Count == 0)
            {
                return "none";
            }

            var sb = new StringBuilder();
            sb.AppendLine($"{Name} ({GetType()}):");
            sb.AppendLine($"Fish: {string.Join(", ", Fish)}");
            sb.AppendLine($"Decoration: {Decorations.Count}");
            sb.AppendLine($"Comfort: {Comfort}");
            return sb.ToString().TrimEnd();
        }
    }
}
