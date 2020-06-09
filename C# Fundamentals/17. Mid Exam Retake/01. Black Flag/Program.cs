using System;

namespace _01._Black_Flag
{
    class Program
    {
        static void Main(string[] args)
        {
            double daysOfPlunder = double.Parse(Console.ReadLine());
            double dailyPlunder = double.Parse(Console.ReadLine());
            double expectedPlunder = double.Parse(Console.ReadLine());

            double gainedPlunder = 0;

            for (int i = 1; i <= daysOfPlunder; i++)
            {
                if (i % 3 == 0 && i % 5 == 0)
                {
                    gainedPlunder += dailyPlunder + dailyPlunder / 2;
                    gainedPlunder -= gainedPlunder * 0.30;
                    continue;
                }
				
                if (i % 3 == 0)
                {
                    gainedPlunder += dailyPlunder + dailyPlunder / 2;
                }
				
                else if (i % 5 == 0)
                {
                    gainedPlunder += dailyPlunder;
                    gainedPlunder -= gainedPlunder * 0.30;
                }
				
                else
                {
                    gainedPlunder += dailyPlunder;
                }

            }
			
            if (gainedPlunder >= expectedPlunder)
            {
                Console.WriteLine($"Ahoy! {gainedPlunder:F2} plunder gained.");
            }
			
            else
            {
                double percentage = gainedPlunder / expectedPlunder * 100;
                Console.WriteLine($"Collected only {percentage:F2}% of the plunder.");
            }
        }
    }
}