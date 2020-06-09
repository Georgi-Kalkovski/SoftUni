using System;

namespace _01._Distance_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            int stepsMade = int.Parse(Console.ReadLine());
            double lengthOf1Step = double.Parse(Console.ReadLine());
            int distanceToTravel = int.Parse(Console.ReadLine());
            double totalStepsInCM = 0;

            for (int i = 1; i <= stepsMade; i++)
            {
                if (i % 5 == 0 && i != 0)
                {
                    totalStepsInCM += lengthOf1Step - lengthOf1Step * 0.30;
                        continue;
                }
				
                else
                {
                    totalStepsInCM += lengthOf1Step;
                }
            }
			
            double percentage = totalStepsInCM / distanceToTravel;
            Console.WriteLine($"You travelled {percentage:F2}% of the distance!");
        }
    }
}
