using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Coins
{
    class Program
    {
        static void Main(string[] args)
        {

            decimal money = decimal.Parse(Console.ReadLine());
            int coinCount = 0;
			
            while (true)
            {

                if (money >= 2)
                {
                    money -= 2;
                    coinCount++;
                }

                else if (money >= 1 && money < 2)
                {
                    money -= 1;
                    coinCount++;
                }

                else if (money >= 0.50m && money < 1)
                {
                    money -= 0.50m;
                    coinCount++;
                }

                else if (money >= 0.20m && money < 0.50m)
                {
                    money -= 0.20m;
                    coinCount++;
                }

                else if (money >= 0.10m && money < 0.20m)
                {
                    money -= 0.10m;
                    coinCount++;
                }

                else if (money >= 0.05m && money < 0.10m)
                {
                    money -= 0.05m;
                    coinCount++;
                }

                else if (money >= 0.02m && money < 0.05m)
                {
                    money -= 0.02m;
                    coinCount++;
                }

                else if (money == 0.01m)
                {
                    money -= 0.01m;
                    coinCount++;
                }

                else
                {
                    Console.WriteLine(coinCount);
                    break;
                }
            }
        }
    }
}
