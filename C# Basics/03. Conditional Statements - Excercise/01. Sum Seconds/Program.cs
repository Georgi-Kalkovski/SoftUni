using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Sum_Seconds
{
    class Program
    {
        static void Main(string[] args)
        {

            int numOne = int.Parse(Console.ReadLine());
            int numTwo = int.Parse(Console.ReadLine());
            int numThree = int.Parse(Console.ReadLine());
            // vuvejdame na konzolatati chisla

            int sum = numOne + numTwo + numThree;
            // sumirame trite chisla

            if (sum <= 59)
            // ako sumata e po-malka ot 60
            {
                if (sum <= 9)
                // ako sumata e po-malka ot 10
                {
                    Console.WriteLine($"0:0{sum}");
                    // vadim na konzolata chasa sus sumata 0:0(X)
                }

                else
                // ako sumata e v diapazon 10 - 59
                {
                    Console.WriteLine($"0:{sum}");
                    // vadim na konzolata chasa sus sumata 0:(XX)
                }
            }

            else if (sum >= 60 && sum <= 119)
            // ako sumata e mejdu 60 i 119
            {
                if (sum - 60 <= 9)
                // ako sumata - 60 minuti e po malka ot 10
                {
                    Console.WriteLine($"1:0{sum- 60}");
                    // pishem na konzolata chasa sus sumata minus 60 minuti 1:0(X)
                }

                else
                // ako sumata e mejdu 70 i 119
                {
                    Console.WriteLine($"1:{sum - 60}");
                    // pishem na konzolata chasa sus sumata minus 60 minuti 1:(XX)
                }
            }

            else if (sum >= 120 && sum <= 179)
            // ako sumata e mejdu 120 i 179
            {
                if (sum - 120 <= 9)
                // ako sumata - 120 minuti e po malka ot 10
                {
                    Console.WriteLine($"2:0{sum - 120}");
                    // pishem na konzolata chasa sus sumata minus 120 minuti 2:0(X)
                }

                else
                // ako sumata e mejdu 130 i 179
                {
                    Console.WriteLine($"2:{sum - 120}");
                    // pishem na konzolata chasa sus sumata minus 120 minuti 2:(XX)
                }
            }

        }
    }
}
