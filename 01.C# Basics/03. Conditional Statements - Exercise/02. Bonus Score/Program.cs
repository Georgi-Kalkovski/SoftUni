using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Bonus_Score
{
    class Program
    {
        static void Main(string[] args)
        {

            double points = double.Parse(Console.ReadLine());
            double bonusPoints = 0;

            if (points <= 100)
            {
                bonusPoints += 5;

                if (points %2 == 0)
                {
                    bonusPoints += 1;
                }

                else if (points %5 == 0)
                {
                    bonusPoints += 2;
                }
                points = points + bonusPoints;
            }

            else if (points > 100 && points <= 1000)
            {
                bonusPoints = points * 0.20;

                if (points % 2 == 0)
                {
                    bonusPoints += 1;
                }

                else if (points % 5 == 0)
                {
                    bonusPoints += 2;
                }
                points = points + bonusPoints;
            }

            else if (points > 1000)
            {
                bonusPoints = points * 0.10;

                if (points % 2 == 0)
                {
                    bonusPoints += 1;
                }

                else if (points % 5 == 0)
                {
                    bonusPoints += 2;
                }
                points = points + bonusPoints;
            }

            Console.WriteLine(bonusPoints);
            Console.WriteLine(points);
        }
    }
}
