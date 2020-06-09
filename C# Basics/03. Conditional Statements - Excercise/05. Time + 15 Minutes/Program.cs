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
            // vuvejdame na konzolata chas
            int minutes = int.Parse(Console.ReadLine());
            // vuvejdame na konzolata minuti

            minutes += 15;
            // dobavqme 15 minuti kum obshtite minuti

            if (minutes < 60)
            // ako minutite sa pod 60
            {

                if (minutes < 10)
                // ako minutite sa pod 10
                {
                    Console.WriteLine($"{hours}:0{minutes}");
                    // pishem na konzolata (chas):0(minuti)
                }

                else if (minutes >= 10)
                // ako e nad 9
                {
                    Console.WriteLine($"{hours}:{minutes}");
                    // vadim na konzolata (chas):(minuti)
                }
            }

            else if (minutes >= 60)
            // ako minutite sa nad 59
            {
                minutes -= 60;
                // vadim ot obshtite minuti 60 minuti
                hours++;
                // dibavqme bonus chas

                if (hours > 23)
                // ako chasovete sa nad 23
                {
                    hours -= 24;
                    // vadim ot obshtite chasove 24 chasa
                }

                if (minutes < 10)
                // ako minutite sa pod 10
                {
                    Console.WriteLine($"{hours}:0{minutes}");
                    // pishem na konzolata (chas):0(minuti)
                }

                else if (minutes >= 10)
                // ako e nad 9
                {
                    Console.WriteLine($"{hours}:{minutes}");
                    // vadim na konzolata (chas):(minuti)
                }
            }
        }
    }
}
