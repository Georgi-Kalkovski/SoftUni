using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Triangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {

            double a = double.Parse(Console.ReadLine());
            // vuvejdame strana na triugulnik
            double h = double.Parse(Console.ReadLine());
            // vuvejdame vtora strana na triugulnika
            double area = a * h / 2;
            // izchislqvame liceto na triugulnika, chrez formulata
            Console.WriteLine($"{area:F2}");
            // vadim na konzolata liceto do vtoriq znak sled desetichnata zapetaq

        }
    }
}
