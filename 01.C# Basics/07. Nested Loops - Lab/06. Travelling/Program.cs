using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Travelling
{
    class Program
    {
        static void Main(string[] args)
        {

            string destination = Console.ReadLine();

            if (destination == "End")
            {
                return;
            }

            while (true)
            {
                double moneyForTrip = double.Parse(Console.ReadLine());
                double moneySaved = 0;

                while (moneyForTrip > moneySaved)
                {
                    double moneyPlus = double.Parse(Console.ReadLine());
                    moneySaved += moneyPlus;
                }

                Console.WriteLine($"Going to {destination}!");
                destination = Console.ReadLine();

                if (destination == "End")
                {
                    return;
                }
            }
        }
    }
}
