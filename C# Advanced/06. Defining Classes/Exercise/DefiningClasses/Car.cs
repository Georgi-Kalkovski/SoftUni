using DefiningClasses;
using System.Collections.Generic;

public class Car
{
    public string Model { get; set; }
    public Engine Engine { get; set; }
    public string Weight { get; set; }
    public string Color { get; set; }

    public Car(string model, Engine engine)
    {
        Model = model;
        Engine = engine;
        Weight = "n/a";
        Color = "n/a";
    }
    public override string ToString()
    {
        return string.Format($"{Model}:\n" +
            $"  {Engine.Model}:\n" +
            $"    Power: {Engine.Power}\n" +
            $"    Displacement: {Engine.Displacement}\n" +
            $"    Efficiency: {Engine.Efficiency}\n" +
            $"  Weight: {Weight}\n" +
            $"  Color: {Color}");
    }
}