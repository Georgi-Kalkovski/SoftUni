namespace FerrariCar
{
    using System;

    public class StartUp
    {
        static void Main()
        {
            string driver = Console.ReadLine();

            Ferrari ferrari = new Ferrari(driver);

            Console.WriteLine(ferrari);
        }
    }
}
