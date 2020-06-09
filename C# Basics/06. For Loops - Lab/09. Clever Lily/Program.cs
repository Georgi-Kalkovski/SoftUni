using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Clever_Lily
{
    class Program
    {
        static void Main(string[] args)
        {

            int yearOld = int.Parse(Console.ReadLine());
            double priceOfWashingMachine = double.Parse(Console.ReadLine());
            double toyPrice = double.Parse(Console.ReadLine());
            double sumOfMoney = 0;
            int stealCount = 0;

            for (int i = 1; i <= yearOld; i++)
            {
                if (i % 2 != 0)
                {
                    sumOfMoney += toyPrice;
                }

                else if (i % 2 == 0)
                {
                    sumOfMoney += 10 * (i / 2);
                    stealCount ++;
                }
            }
			
            sumOfMoney -= stealCount;

            if (priceOfWashingMachine <= sumOfMoney)
            {
                double moneyLeft = sumOfMoney - priceOfWashingMachine;
                Console.WriteLine($"Yes! {moneyLeft:F2}");
            }

            else if (priceOfWashingMachine > sumOfMoney)
            {
                double moneyLeft = priceOfWashingMachine - sumOfMoney;
                Console.WriteLine($"No! {moneyLeft:F2}");
            }
        }
    }
}
