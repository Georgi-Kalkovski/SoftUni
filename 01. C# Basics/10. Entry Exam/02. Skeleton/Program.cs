using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Skeleton
{
    class Program
    {
        static void Main(string[] args)
        {

            int controlMinutes = int.Parse(Console.ReadLine());              
            int controlSeconds = int.Parse(Console.ReadLine());              
            double lengthOfChuteInMeters = double.Parse(Console.ReadLine()); 
            int secsFor100Meters = int.Parse(Console.ReadLine());            

            int totalControlSeconds = controlMinutes * 60 + controlSeconds;  
            double minusTime = lengthOfChuteInMeters / 120;                  
            double totalMinusTime = minusTime * 2.5;                         
            double timeOfMarin = (lengthOfChuteInMeters / 100) * secsFor100Meters - totalMinusTime;

            if (timeOfMarin <= totalControlSeconds)
            {
                Console.WriteLine($"Marin Bangiev won an Olympic quota!");
                Console.WriteLine($"His time is {timeOfMarin:F3}.");      
            }

            else if (timeOfMarin > totalControlSeconds)
            {
                double secondsLeft = totalControlSeconds - timeOfMarin;     
                Console.WriteLine($"No, Marin failed! He was {Math.Abs(secondsLeft):F3} second slower.");
            }
        }
    }
}
