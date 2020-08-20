namespace CarSalesman
{
    using System.Text;

    public class Engine
    {
        public string model;
        public int power;
        public int? displacement;
        public string efficiency;

        public string Model
        {
            get { return model; }
            set { model = value; }
        }

        public Engine(string model, int power)
        {
            this.model = model;
            this.power = power;
        }

        public Engine(string model, int power, int? displacement)
            :this(model,power)
        {
            this.displacement = displacement;
        }

        public Engine(string model, int power, string efficiency)
            :this(model,power)
        {
            this.efficiency = efficiency;
        }

        public Engine(string model, int power, int? displacement, string efficiency)
            : this(model, power)
        {
            this.displacement = displacement;
            this.efficiency = efficiency;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($" {Model}:");
            builder.AppendLine($"  Power: {power}");
            builder.AppendLine($"  Displacement: {(displacement == null ? "n/a" : displacement.ToString())}");
            builder.AppendLine($"  Efficiency: {(efficiency == null ? "n/a" : efficiency.ToString())}");

            return builder.ToString();
        }
    }
}
