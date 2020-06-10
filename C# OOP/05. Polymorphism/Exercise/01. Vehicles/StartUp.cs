namespace Vehicles
{
    using System;
    public class StartUp
    {
        static void Main()
        {
            string[] carLine = Console.ReadLine()
                .Split();
            Vehicle car = new Car(double.Parse(carLine[1]), double.Parse(carLine[2]));
            string[] truckLine = Console.ReadLine()
                .Split();
            Vehicle truck = new Truck(double.Parse(truckLine[1]), double.Parse(truckLine[2]));
            
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine()
                    .Split();

                if (input[0] == "End")
                {
                    break;
                }

                string type = input[1];
                string command = input[0];
                double value = double.Parse(input[2]);

                switch (type)
                {
                    case nameof(Car):
                        ExecuteCommand(car, command, value);
                        break;
                    case nameof(Truck):
                        ExecuteCommand(truck, command, value);
                        break;
                }
            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
        }
        private static void ExecuteCommand(Vehicle vehicle, string command, double value)
        {
            switch (command)
            {
                case "Drive":
                    Console.WriteLine(vehicle.Drive(value));
                    break;
                case "Refuel":
                    vehicle.Refuel(value);
                    break;
            }
        }
    }
}
