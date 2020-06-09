using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Fishing_Boat
{
    class Program
    {
        static void Main(string[] args)
        {

            int springWorth = 3000;
            int summerWorth = 4200;
            int autumnWorth = 4200;
            int winterWorth = 2600;

            double budget = double.Parse(Console.ReadLine());
            string season = Console.ReadLine();
            int fishermen = int.Parse(Console.ReadLine());

            double counter = 0;

            if (season == "Spring") counter += springWorth;
            else if (season == "Summer") counter += summerWorth;
            else if (season == "Autumn") counter += autumnWorth;
            else if (season == "Winter") counter += winterWorth;

            if (fishermen <= 6)
            {
                counter -= counter * 0.10;
            }

            else if (fishermen >= 7 && fishermen <= 11)
            {
                counter -= counter * 0.15;
            }

            else if (fishermen >= 12)
            {
                counter -= counter * 0.25;
            }

            if (fishermen % 2 == 0 && season != "Autumn")
            {
                counter -= counter * 0.05;
            }

            if (budget >= counter)
            {
                budget -= counter;
                Console.WriteLine($"Yes! You have {budget:F2} leva left.");
            }

            else if (budget <= counter)
            {
                counter -= budget;
                Console.WriteLine($"Not enough money! You need {counter:F2} leva.");
            }
        }
    }
}
