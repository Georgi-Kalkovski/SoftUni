using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Radians_to_Degrees
{
    class Program
    {
        static void Main(string[] args)
        {

            double rad = double.Parse(Console.ReadLine());
            // vuvejdame na konzolata radius
            double deg = rad * 180 / Math.PI;
            // izchislqvame ugula, chrez formulata radiusa umnojen na 180 deleno na PI
            Console.WriteLine(Math.Round(deg));
            // printirame zakrugleniq ugul
        }
    }
}
