using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Circle_Area_and_Perimeter
{
    class Program
    {
        static void Main(string[] args)
        {

            double r = double.Parse(Console.ReadLine());
            // vuvejdame na konzolata chislo, koeto shte e radius na krug
            double area = Math.PI * r * r;
            // namirame liceto na kruga, chrez formulata
            double perimeter = 2 * Math.PI * r;
            // namirame perimetura na kruga, chrez formulata
            Console.WriteLine($"{area:F2}");
            // vadim na konzolata liceto
            Console.WriteLine($"{perimeter:F2}");
            // vadim na konzolata perimetura
        }
    }
}
