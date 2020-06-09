using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AquariumAdventure.Models
{
    public class Aquarium
    {
        private ICollection<Fish> fishInPool;

        public Aquarium(string name, int capacity, int size)
        {
            this.fishInPool = new List<Fish>();
            this.Name = name;
            this.Capacity = capacity;
            this.Size = size;
        }

        public string Name { get; }

        public int Capacity { get; }

        public int Size { get; }

        public void Add(Fish fish)
        {
            if (!this.fishInPool.Any(f => f.Name == fish.Name) &&
                !(this.fishInPool.Count >= this.Capacity))
            {
                this.fishInPool.Add(fish);
            }
        }

        public bool Remove(string name)
        {
            return this.fishInPool
                    .Remove(this.fishInPool
                        .Where(f => f.Name == name)
                        .FirstOrDefault());
        }

        public Fish FindFish(string name)
        {
            return this.fishInPool
                    .Where(f => f.Name == name)
                    .FirstOrDefault();
        }

        public string Report()
        {
            var result = new StringBuilder();

            result.AppendLine($"Aquarium: {this.Name} ^ Size: {this.Size}");

            foreach (var fish in this.fishInPool)
            {
                result.AppendLine(fish.ToString());
            }

            return result.ToString().Trim();
        }
    }
}
