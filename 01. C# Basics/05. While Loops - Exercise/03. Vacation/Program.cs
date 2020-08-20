using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Vacation
{
    class Program
    {
        static void Main(string[] args)
        {

            double moneyForTrip = double.Parse(Console.ReadLine());
            double money = double.Parse(Console.ReadLine());
            int spendCounter = 0;
            int daysCounter = 1;

            while (true)
            {
                
                string spendOrSave = Console.ReadLine();
                double moneyForDay = double.Parse(Console.ReadLine());
                
                if (spendOrSave == "save")
                {
                    money += moneyForDay;
                    spendCounter = 0;

                    if (moneyForTrip <= money)
                    {
                        Console.WriteLine($"You saved the money for {daysCounter} days.");
                        return;
                    }
                }

                else if (spendOrSave == "spend")
                {
                    spendCounter++;
                    money -= moneyForDay;
					
                    if (money < 0)
                    {
                        money = 0;
                    }
                }
				
                if (spendCounter >= 5)
                {
                    Console.WriteLine($"You can't save the money.");
                    Console.WriteLine($"{daysCounter}");
                    return;
                }
				
                daysCounter++;
            }
        }
    }
}
