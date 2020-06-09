using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Inches_to_Centimeters
{
    class Program
    {
        static void Main(string[] args)
        {

            double inch = double.Parse(Console.ReadLine());
            double cm = inch * 2.54;
            Console.WriteLine($"{cm:F2}");
        }
    }
}
