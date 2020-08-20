namespace HotelReservation
{
    using System;

    public class Startup
    {
        static void Main(string[] args)
        {
            string[] reservation = Console.ReadLine()
                .Split();

            var priceCalculator = new PriceCalculator(reservation);

            Console.WriteLine($"{priceCalculator.GetTotalPrice():F2}");
        }
    }
}

            
