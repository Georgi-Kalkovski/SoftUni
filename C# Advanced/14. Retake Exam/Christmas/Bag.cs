using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Christmas
{
    public class Bag
    {
        List<Present> data;
        public string Color { get; set; }
        public int Capacity { get; set; }

        public Bag(string color, int capacity)
        {
            this.Color = color;
            this.Capacity = capacity;
            this.data = new List<Present>();
        }

        public int Count
        { 
        get => this.data.Count;
        }

        public bool Remove(string name)
        {
           return data.Remove(data.Where(x=>x.Name == name).FirstOrDefault());
        }

        public void Add(Present present)
        {
            if (this.data.Count < this.Capacity) data.Add(present);
        }

        public Present GetHeaviestPresent()
        {
            var newData = data.OrderByDescending(x=> x.Weight);
            return newData.First();
        }

        public Present GetPresent(string name)
        {
            
           return this.data.Find(x => x.Name == name);
        }

        public string Report()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"{this.Color} bag contains:");
            foreach (var present in data)
            {
                sb.AppendLine(present.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}