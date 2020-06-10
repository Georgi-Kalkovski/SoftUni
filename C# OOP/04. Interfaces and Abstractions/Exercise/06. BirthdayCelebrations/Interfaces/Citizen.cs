namespace BirthdayCelebrations
{
    using System;

    public interface Citizen
    {
        string Name { get; }
        int Age { get; }
        string Id { get; }
        DateTime Birthdate { get; }
    }
}
