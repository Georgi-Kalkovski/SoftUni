using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Volleyball
{
    class Program
    {
        static void Main(string[] args)
        {

            string year = Console.ReadLine();
            double holidays = double.Parse(Console.ReadLine());
            double weekendsHome = double.Parse(Console.ReadLine());

            int weekends = 48;

            double weekendsSofia = weekends - weekendsHome;
            weekendsSofia = weekendsSofia * 3.0 / 4;
            holidays = holidays * 2.0 / 3;

            double gamesTotal = weekendsSofia + weekendsHome + holidays;

            if (year == "leap")
            {
                gamesTotal = gamesTotal + (gamesTotal * 0.15);
                Console.WriteLine($"{Math.Floor(gamesTotal)}");
            }
            else if (year == "normal")
            {
                Console.WriteLine($"{Math.Floor(gamesTotal)}");
            }
        }
    }
}
