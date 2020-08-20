using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Cinema
{
    class Program
    {
        static void Main(string[] args)
        {

            double premiere = 12.00;
            double normal = 7.50;
            double discount = 5.00;

            string type = Console.ReadLine();
            int row = int.Parse(Console.ReadLine());
            int column = int.Parse(Console.ReadLine());

            double area = row * column;

            if (type == "Premiere")
            // ako bileta e "Premiere"
            {
                Console.WriteLine($"{area * premiere:F2} leva");
            }

            else if (type == "Normal")
            {
                Console.WriteLine($"{area * normal:F2} leva");
            }

            else if (type == "Discount")
            {
                Console.WriteLine($"{area * discount:F2} leva");
            }

        }
    }
}
