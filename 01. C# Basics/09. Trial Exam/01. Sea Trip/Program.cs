using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Sea_Trip
{
    class Program
    {
        static void Main(string[] args)
        {

            double moneyForFood = double.Parse(Console.ReadLine());
            double moneyForSouvenirs = double.Parse(Console.ReadLine());
            double moneyForHotel = double.Parse(Console.ReadLine());

            double tripLength = 2 * 210;
            double totalLitersGasoline = tripLength / 100 * 7;
            double moneyForGasoline = totalLitersGasoline * 1.85;
            int days = 3;
            double foodAndSouvenirs = days * moneyForFood + days * moneyForSouvenirs;
            double totalHotelCost = moneyForHotel * 0.9 + moneyForHotel * 0.85 + moneyForHotel * 0.8;
            double totalTripCost = moneyForGasoline + foodAndSouvenirs + totalHotelCost;
            Console.WriteLine($"Money needed: {totalTripCost:F2}");
        }
    }
}
