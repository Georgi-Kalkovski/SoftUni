using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Bus
{
    class Program
    {
        static void Main(string[] args)
        {

            int passengers = int.Parse(Console.ReadLine());
            int numberOfBusStops = int.Parse(Console.ReadLine());

            for (int i = 1; i <= numberOfBusStops; i++)
            {
                int leavingPassengers = int.Parse(Console.ReadLine());
                passengers -= leavingPassengers;

                int comingPassengers = int.Parse(Console.ReadLine());
                passengers += comingPassengers;

                if (i % 2 != 0)
                {
                    passengers = passengers + 2;
                }

                if (i % 2 == 0)
                {
                    passengers = passengers - 2;
                }
            }
			
            Console.WriteLine($"The final number of passengers is : {passengers}");
        }
    }
}
