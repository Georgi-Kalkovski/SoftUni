namespace Cars
{
    using System;
    public interface ICar
    {

        string Model { get; }
        string Color { get; }
        string Start();
        string Stop();

    }
}