using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Trapeziod_Area
{
    class Program
    {
        static void Main(string[] args)
        {

            double b1 = double.Parse(Console.ReadLine());
            // vuvejdame goleminata na ednata strana 
            double b2 = double.Parse(Console.ReadLine());
            // vuvejdame goleminata na vtorata strana
            double h = double.Parse(Console.ReadLine());
            // vuvejdame goleminata na dvete ravni strani na trapeca

            double area = ((b1 + b2) * h) / 2;
            // namirame liceto na trapeca

            Console.WriteLine($"{area:F2}");
            // vadim na konzolata liceto na trapeca 
        }
    }
}
