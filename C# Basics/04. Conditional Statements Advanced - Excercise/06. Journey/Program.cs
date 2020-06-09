using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Journey
{
    class Program
    {
        static void Main(string[] args)
        {

            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();

            double counter = 0;
            string place = string.Empty;
            string campOrHotel = string.Empty;

            if (budget <= 100)
            {
                place = "Bulgaria";
                {
                    if (season == "summer")
                    {
                        campOrHotel = "Camp";
                        counter += budget * 0.30;
                    }
                    else if (season == "winter")
                    {
                        campOrHotel = "Hotel";
                        counter += budget * 0.70;
                    }
                }
            }
            else if (budget > 100 && budget <= 1000)
            {
                place = "Balkans";
                {
                    if (season == "summer")
                    {
                        campOrHotel = "Camp";
                        counter += budget * 0.40;
                    }
                    else if (season == "winter")
                    {
                        campOrHotel = "Hotel";
                        counter += budget * 0.80;
                    }
                }
            }
            else if (budget > 1000)
            {
                place = "Europe";
                campOrHotel = "Hotel";
                counter += budget * 0.90;
            }

            Console.WriteLine($"Somewhere in {place}");
            Console.WriteLine($"{campOrHotel} - {counter:F2}");
        }
    }
}
