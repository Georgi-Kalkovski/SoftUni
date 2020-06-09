using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Day_of_Week
{
    class Program
    {
        static void Main(string[] args)
        {

            int day = int.Parse(Console.ReadLine());
            // vuvejdame cifra, koqto shte e den ot sedmicata

            if (day > 7)
            // ako cifrata e poveche ot dnite ot sedmicata
            {
                Console.WriteLine("Error");
                // vadim na konzolata "Error"
                return;
                // izlizame ot programata
            }

            switch (day)
            // ako denq e v diapazona ot sedmicata, imame "switch" za denq
            {
                case 1: Console.WriteLine("Monday"); break;
                case 2: Console.WriteLine("Tuesday"); break;
                case 3: Console.WriteLine("Wednesday"); break;
                case 4: Console.WriteLine("Thursday"); break;
                case 5: Console.WriteLine("Friday"); break;
                case 6: Console.WriteLine("Saturday"); break;
                case 7: Console.WriteLine("Sunday"); break;
                // vseki sluchai se sustoi ot cifra
                // pishene na konzolata suotvetstvashtiq den sprqmo cifrata
                // izlizane ot "switch" chrez "break"
            }
        }
    }
}
