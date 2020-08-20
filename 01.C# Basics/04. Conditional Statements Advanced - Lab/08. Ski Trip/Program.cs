using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Ski_Trip
{
    class Program
    {
        static void Main(string[] args)
        {

            double roomForOne = 18.00;
            double apartment = 25.00;
            double presidentApartment = 35.00;
            double price = 0;

            int days = int.Parse(Console.ReadLine());
            string room = Console.ReadLine();
            string rating = Console.ReadLine();

            days -= 1;

            if (room == "room for one person")
            {
                price = days * roomForOne;
            }

            else if (room == "apartment")
            {
                price = days * apartment;
                if (days < 10)
                {
                    price -= price * 0.30;
                }
                else if (days >= 10 && days <= 15)
                {
                    price -= price * 0.35;
                }
                else if (days > 15)
                {
                    price -= price * 0.50;
                }
            }

            else if (room == "president apartment")
            {
                price = days * presidentApartment;
                if (days < 10)
                {
                    price -= price * 0.10;
                }
                else if (days >= 10 && days <= 15)
                {
                    price -= price * 0.15;
                }
                else if (days > 15)
                {
                    price -= price * 0.20;
                }
            }

            if (rating == "positive")
            {
                price += price * 0.25;
            }

            if (rating == "negative")
            {
                price -= price * 0.10;
            }
            Console.WriteLine($"{price:F2}");
        }
    }
}
