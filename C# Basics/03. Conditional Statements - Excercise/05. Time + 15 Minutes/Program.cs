using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Time___15_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {

            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());

            minutes += 15;

            if (minutes < 60)
            {

                if (minutes < 10)
                {
                    Console.WriteLine($"{hours}:0{minutes}");
                }

                else if (minutes >= 10)
                {
                    Console.WriteLine($"{hours}:{minutes}");
                }
            }

            else if (minutes >= 60)
            {
                minutes -= 60;
                hours++;

                if (hours > 23)
                {
                    hours -= 24;
                }

                if (minutes < 10)
                {
                    Console.WriteLine($"{hours}:0{minutes}");
                }

                else if (minutes >= 10)
                {
                    Console.WriteLine($"{hours}:{minutes}");
                }
            }
        }
    }
}
