using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Speed_Info
{
    class Program
    {
        static void Main(string[] args)
        {

            double number = double.Parse(Console.ReadLine());
            // vuvjdame chislo na konzolata

            if (number <= 10)
            // ako chisloto e pod 11
            {
                Console.WriteLine("slow");
                // vadim na konzolata "slow"
            }

            else if (number > 10 && number <= 50)
            // ako chisloto e mejdu 11 i 50 vkliuchitelno
            {
                Console.WriteLine("average");
                // vadim na konzolata "average"
            }

            else if (number > 50 && number <= 150)
            // ako chisloto e mejdu 51 i 150 vkliuchitelno
            {
                Console.WriteLine("fast");
                // vadim na konzolata "fast"
            }

            else if (number > 150 && number <= 1000)
            // ako chisloto e mejdu 151 i 1500 vkliuchitelno
            {
                Console.WriteLine("ultra fast");
                // vadim na konzolata "ultra fast"
            }

            else if (number > 1000)
            // ako chisloto e nad 1000
            {
                Console.WriteLine("extremely fast");
                // vadim na konzolata "extremely fast"
            }
        }
    }
}
