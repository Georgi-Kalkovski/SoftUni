using System;
using System.Collections.Generic;
using System.Text;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            {
                var tires = new List<Tire>();
                var engines = new List<Engine>();
                var cars = new List<Car>();
                var carTires = new List<double>();

                string tiresOrNot = Console.ReadLine();

                while (tiresOrNot != "No more tires")
                {
                    string[] tiresInfo = tiresOrNot.Split();

                    double tireOne = double.Parse(tiresInfo[1]);
                    double tireTwo = double.Parse(tiresInfo[3]);
                    double tireThree = double.Parse(tiresInfo[5]);
                    double tireFour = double.Parse(tiresInfo[7]);

                    carTires.Add(tireOne + tireTwo + tireThree + tireFour);

                    for (int i = 1; i <= tiresInfo.Length; i += 2)
                    {
                        int currentCarYear = int.Parse(tiresInfo[i - 1]);
                        double currentTirePressure = double.Parse(tiresInfo[i]);

                        tires.Add(new Tire(currentCarYear, currentTirePressure));
                    }

                    tiresOrNot = Console.ReadLine();
                }

                string engineDoneOrNot = Console.ReadLine();

                while (engineDoneOrNot != "Engines done")
                {
                    string[] engineInfo = engineDoneOrNot.Split();

                    for (int i = 1; i <= engineInfo.Length; i += 2)
                    {
                        int horsePower = int.Parse(engineInfo[i - 1]);
                        double cubicCapacity = double.Parse(engineInfo[i]);

                        engines.Add(new Engine(horsePower, cubicCapacity));
                    }

                    engineDoneOrNot = Console.ReadLine();
                }

                string carStats = Console.ReadLine();

                while (carStats != "Show special")
                {
                    string[] carInfo = carStats.Split();

                    string make = carInfo[0];
                    string model = carInfo[1];
                    int year = int.Parse(carInfo[2]);
                    double fuelQuantity = double.Parse(carInfo[3]);
                    double fuelConsumption = double.Parse(carInfo[4]);
                    int engineIndex = int.Parse(carInfo[5]);
                    int tiresIndex = int.Parse(carInfo[6]);

                    cars.Add(new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tiresIndex]));

                    carStats = Console.ReadLine();
                }

                int j = 0;
                foreach (var car in cars)
                {
                    if (car.Year >= 2017 && car.Engine.HorsePower > 330.0 && carTires[j] >= 9.0 && carTires[j] <= 10.0)
                    {
                        car.FuelQuantity -= 20.0 / 100 * car.FuelConsumption;

                        Console.WriteLine($"Make: {car.Make}");
                        Console.WriteLine($"Model: {car.Model}");
                        Console.WriteLine($"Year: {car.Year}");
                        Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                        Console.WriteLine($"FuelQuantity: {car.FuelQuantity}");
                    }
                    j++;
                }
            }
        }
    }
}
