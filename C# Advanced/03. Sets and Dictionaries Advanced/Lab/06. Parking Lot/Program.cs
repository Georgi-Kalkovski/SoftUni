using System;
using System.Collections.Generic;

namespace _06._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> carsParked = new HashSet<string>();

            do
            {
                string[] input = Console.ReadLine().Split(", ");

                string command = input[0];

                if (command == "END")
                {
                    break;
                }

                string car = input[1];

                if (command == "IN")
                {
                    carsParked.Add(car);
                }

                else if (command == "OUT")
                {
                    carsParked.Remove(car);
                }
            }
            while (true);

            if (carsParked.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
                return;
            }

            foreach (var car in carsParked)
            {
                Console.WriteLine(car);
            }
        }
    }
}
