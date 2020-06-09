using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Charity_Campaign
{
    class Program
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int cooks = int.Parse(Console.ReadLine());
            int cakesNumber = int.Parse(Console.ReadLine());
            int wafflesNumber = int.Parse(Console.ReadLine());
            int pancakesNumber = int.Parse(Console.ReadLine());

            double cakePrice = 45;
            double wafflePrice = 5.80;
            double pancakePrice = 3.20;

            double moneyTotal = cooks * days * (cakePrice * cakesNumber + wafflePrice * wafflesNumber + pancakePrice * pancakesNumber);
            double moneyFinal = moneyTotal - moneyTotal / 8;

            Console.WriteLine($"{moneyFinal:F2}");
        }
    }
}
