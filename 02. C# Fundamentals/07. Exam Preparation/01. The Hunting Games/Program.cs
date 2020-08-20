using System;

namespace _01._The_Hunting_Games
{
    class Program
    {
        static void Main(string[] args)
        {
            int daysN = int.Parse(Console.ReadLine());
            int players = int.Parse(Console.ReadLine());
            double groupEnergy = double.Parse(Console.ReadLine());
            double waterPerDayPerPerson = double.Parse(Console.ReadLine());
            double foodPerDayPerPerson = double.Parse(Console.ReadLine());

            double totalWater = daysN * players * waterPerDayPerPerson;
            double totalFood = daysN * players * foodPerDayPerPerson;

            for (int i = 1; i <= daysN; i++)
            {
                double currentDay = double.Parse(Console.ReadLine());
                groupEnergy -= currentDay;
                System.Math.Round(groupEnergy, 2);

                if (groupEnergy <= 0)
                {
                    Console.WriteLine($"You will run out of energy. You will be left with {totalFood:F2} food and {totalWater:F2} water.");
                    return;
                }
				
                if (i % 2 == 0)
                {
                    groupEnergy += groupEnergy * 0.05;
                    System.Math.Round(groupEnergy, 2);
                    totalWater -= totalWater * 0.3;
                    System.Math.Round(totalWater, 2);
                }
				
                if (i % 3 == 0)
                {
                    groupEnergy += groupEnergy * 0.1;
                    System.Math.Round(groupEnergy, 2);
                    totalFood -= totalFood / players;
                    System.Math.Round(totalFood, 2);
                }
            }
			
            Console.WriteLine($"You are ready for the quest. You will be left with - {groupEnergy:F2} energy!");
        }
    }
}
