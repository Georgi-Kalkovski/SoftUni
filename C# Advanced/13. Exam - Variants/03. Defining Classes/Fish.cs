using System;
using System.Collections.Generic;
using System.Text;

namespace AquariumAdventure.Models
{
    public class Fish
    {
        public Fish(string name, string color, int fins)
        {
            this.Name = name;
            this.Color = color;
            this.Fins = fins;
        }

        public string Name { get; }

        public string Color { get; }

        public int Fins { get; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.AppendLine($"Fish: {this.Name}");
            result.AppendLine($"Color: {this.Color}");
            result.AppendLine($"Number of fins: {this.Fins}");

            return result.ToString().Trim();
        }
    }
}
