using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03._2D_Rectangle_Area
{
    class Program
    {
        static void Main(string[] args)
        {

            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());
            // vuvejdame koordinatite na pravougulnika

            double xy1 = Math.Abs(x1 - x2);
            // namirame purvata strana (polzvame Math.Abs, za da napravim chisloto polojitelno)
            double xy2 = Math.Abs(y1 - y2);
            // namirame vtorata strana (polzvame Math.Abs, za da napravim chisloto polojitelno)

            double area = xy1 * xy2;
            // namirame liceto na pravougulnika
            double perimeter = 2 * (xy1 + xy2);
            // namirame perimetura na pravougulnika

            Console.WriteLine($"{area:F2}");
            // printirame liceto do vtoro chislo sled desetichnata zaptaq
            Console.WriteLine($"{perimeter:F2}");
            // printirame perimetura do vtoro chislo sled desetichnata zaptaq
        }
    }
}
