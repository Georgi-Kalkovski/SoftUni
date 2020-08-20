using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Hotel_Room
{
    class Program
    {
        static void Main(string[] args)
        {

            double studioMayOctober = 50;
            double studioJuneSeptember = 75.20;
            double studioJulyAugust = 76;

            double apartmentMayOctober = 65;
            double apartmentJuneSeptember = 68.70;
            double apartmentJulyAugust = 77;

            string month = Console.ReadLine();
            double days = double.Parse(Console.ReadLine());
            
            double studioWorth = 0;
            double apartmentWorth = 0;

            if (month == "May" || month == "October")
            {
                studioWorth += studioMayOctober * days;
                apartmentWorth += apartmentMayOctober * days;

                if (days > 7 && days <= 14)
                {
                    studioWorth -= studioWorth * 0.05;
                }
                else if (days > 14)
                {
                    studioWorth -= studioWorth * 0.30;
                }
            }

            else if (month == "June" || month == "September")
            {
                studioWorth += studioJuneSeptember * days;
                apartmentWorth += apartmentJuneSeptember * days;

                if (days > 14)
                {
                    studioWorth -= studioWorth  * 0.20;
                }
            }

            else if (month == "July" || month == "August")
            {
                studioWorth += studioJulyAugust * days;
                apartmentWorth += apartmentJulyAugust * days;
            }

            if (days > 14)
            {
                apartmentWorth -= apartmentWorth * 0.10;
            }

            Console.WriteLine($"Apartment: {apartmentWorth:F2} lv.");
            Console.WriteLine($"Studio: {studioWorth:F2} lv.");
        }
    }
}
