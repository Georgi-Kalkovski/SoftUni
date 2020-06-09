using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Celsius_to_Fahrenheit
{
    class Program
    {
        static void Main(string[] args)
        {

            double celsius = double.Parse(Console.ReadLine());
            // vuvejdame na konzolata celzii
            double fahrenheit = (celsius * 9) / 5 + 32;
            // chrez formulata namirame farenhaid
            Console.WriteLine($"{fahrenheit:F2}");
            // vadim na konzolata farenhaid
        }
    }
}
