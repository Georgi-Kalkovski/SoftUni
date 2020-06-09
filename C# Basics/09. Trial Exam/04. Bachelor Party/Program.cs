using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Bachelor_Party
{
    class Program
    {
        static void Main(string[] args)
        {

            double specialGuest = double.Parse(Console.ReadLine());
            string people = string.Empty;
            double sumOfMoney = 0;
            int guestsCounter = 0;

            while (people != "The restaurant is full")
            {
                people = Console.ReadLine();

                if (people == "The restaurant is full")
                {
                    break;
                }

                int peopleToNum = int.Parse(people);
                guestsCounter += peopleToNum;

                if (peopleToNum >= 5)
                {
                    sumOfMoney += peopleToNum * 70;
                }

                else if (peopleToNum < 5)
                {
                    sumOfMoney += peopleToNum * 100;
                }

            }

            if (specialGuest <= sumOfMoney)
            {
                sumOfMoney -= specialGuest;
                Console.WriteLine($"You have {guestsCounter} guests and {sumOfMoney} leva left.");
            }
			
            else if (specialGuest > sumOfMoney)
            {
                Console.WriteLine($"You have {guestsCounter} guests and {sumOfMoney} leva income, but no singer.");
            }
        }
    }
}
