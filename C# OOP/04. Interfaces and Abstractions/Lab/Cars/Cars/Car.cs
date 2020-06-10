namespace Cars
{
    using System;
    using System.Text;

    public class Car
    {
        public Car(string model, string color)
        {
            Model = model;
            Color = color;
        }

        public string Model { get; protected set; }
        public string Color { get; protected set; }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        protected virtual string GetCarInfo()
        {
            return $"{this.Color} {this.GetType().Name} {this.Model}";
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            builder.AppendLine(this.GetCarInfo())
            .AppendLine(this.Start())
            .Append(this.Stop());

            return builder.ToString();
        }
    }
}
