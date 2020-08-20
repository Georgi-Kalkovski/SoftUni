using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Fishing
{
    class Program
    {
        static void Main(string[] args)
        {

            int fishPerDay = int.Parse(Console.ReadLine());
            string fish = string.Empty;
            double profitCounter = 0;
            int fishCounter = 0;
            while (fish != "Stop")
            {
                fish = Console.ReadLine();

                if (fish == "Stop")
                {
                    break;
                }

                fishCounter++;

                double KG = double.Parse(Console.ReadLine());
                int fishLettersPrice = 0;

                for (int i = 0; i < fish.Length; i++)
                {
                    int currentFishPrice = fish[i];
                    fishLettersPrice += currentFishPrice;
                }

                if (fishCounter % 3 == 0)
                {
                    profitCounter += fishLettersPrice / KG;
                }
				
                if (fishCounter % 3 != 0)
                {
                    profitCounter -= fishLettersPrice / KG;
                }
				
                if (fishPerDay == fishCounter)
                {
                    Console.WriteLine("Lyubo fulfilled the quota!");
                    break;
                }
            }
			
            if (profitCounter > 0)
            {
                Console.WriteLine($"Lyubo's profit from {fishCounter} fishes is {profitCounter:F2} leva.");
            }
			
            if (profitCounter < 0)
            {
                Console.WriteLine($"Lyubo lost {Math.Abs(profitCounter):F2} leva today.");
            }
        }
    }
}
