using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Vehicle_Catalogue
{
    class VehiclesCatalogue
    {
        public string Type { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public double Horsepower { get; set; }
		
        public VehiclesCatalogue(string typeOfVehicle, string modelOfVehicle, string colorOfVehicle, double horsepowerOfVehicle)
        {
            this.Type = typeOfVehicle;
            this.Model = modelOfVehicle;
            this.Color = colorOfVehicle;
            this.Horsepower = horsepowerOfVehicle;
        }
		
        public override string ToString()
        {
            return $"Type: {Type.First().ToString().ToUpper() + Type.Substring(1)}\nModel: {Model}\nColor: {Color}\nHorsepower: {Horsepower}";
        }
    }
	
    class Program
    {
        static void Main(string[] args)
        {
            List<VehiclesCatalogue> listOfVehicles = new List<VehiclesCatalogue>();
            double carsHorsepower = 0;
            double trucksHorsepower = 0;
            int carsCounter = 0;
            int trucksCounter = 0;
			
            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split()
                    .ToArray();

                if (input[0] == "End")
                {
                    break;
                }

                string typeOfVehicle = input[0];
                string modelOfVehicle = input[1];
                string colorOfVehicle = input[2];
                double horsepowerOfVehicle = double.Parse(input[3]);
				
                if (typeOfVehicle == "car")
                {
                    carsHorsepower += horsepowerOfVehicle;
                    carsCounter++;
                }
				
                if (typeOfVehicle == "truck")
                {
                    trucksHorsepower += horsepowerOfVehicle;
                    trucksCounter++;
                }

                VehiclesCatalogue vehiclesCatalogue = new VehiclesCatalogue(typeOfVehicle, modelOfVehicle, colorOfVehicle, horsepowerOfVehicle);

                listOfVehicles.Add(vehiclesCatalogue);
            }
			
            while (true)
            {
                string nextInput = Console.ReadLine();

                if (nextInput == "Close the Catalogue")
                {
                    break;
                }

                Console.WriteLine(listOfVehicles.Find(x => x.Model == nextInput));
            }

            double averageCarHorsepower = carsHorsepower / carsCounter;
            double averageTruckHorsepower = trucksHorsepower / trucksCounter;

            if (carsCounter > 0)
            {
                Console.WriteLine($"Cars have average horsepower of: {averageCarHorsepower:F2}.");
            }
			
            else
            {
                Console.WriteLine($"Cars have average horsepower of: {0:F2}.");
            }
			
            if (trucksCounter > 0)
            {
                Console.WriteLine($"Trucks have average horsepower of: {averageTruckHorsepower:F2}.");
            }
			
            else
            {
                Console.WriteLine($"Trucks have average horsepower of: {0:F2}.");
            }
        }
    }
}
