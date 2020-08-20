using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Vehicle_Catalogue
{
    class Program
    {
        class Truck
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public int Weight { get; set; }
        }
		
        class Car
        {
            public string Brand { get; set; }
            public string Model { get; set; }
            public int HorsePower { get; set; }
        }
		
        class Catalog
        {
            public List<Car> Cars { get; set; }
            public List<Truck> Trucks { get; set; }
        }
		
        static void Main(string[] args)
        {
            List<Car> listOfCars = new List<Car>();
            List<Truck> listOfTrucks = new List<Truck>();

            while (true)
            {
                List<string> input = Console.ReadLine()
                    .Split("/")
                    .ToList();

                if (input[0] == "end")
                {
                    break;
                }

                if (input[0] == "Car")
                {
                    var brand = input[1];
                    var model = input[2];
                    var horsePower = input[3];

                    Car car = new Car();

                    car.Brand = brand;
                    car.Model = model;
                    car.HorsePower = int.Parse(horsePower);

                    listOfCars.Add(car);
                }

                if (input[0] == "Truck")
                {
                    var brand = input[1];
                    var model = input[2];
                    var weight = input[3];

                    Truck truck = new Truck();

                    truck.Brand = brand;
                    truck.Model = model;
                    truck.Weight = int.Parse(weight);

                    listOfTrucks.Add(truck);
                }
            }
			
            var newListCars = listOfCars.OrderBy(x => x.Brand).ToList();
            var newListTrucks = listOfTrucks.OrderBy(x => x.Brand).ToList();

            Console.WriteLine("Cars:");
			
            foreach (Car car in newListCars)
            {
                Console.WriteLine($"{car.Brand}: {car.Model} - {car.HorsePower}hp");
            }

            Console.WriteLine("Trucks:");
			
            foreach (Truck truck in newListTrucks)
            {
                Console.WriteLine($"{truck.Brand}: {truck.Model} - {truck.Weight}kg");
            }
        }
    }
}
