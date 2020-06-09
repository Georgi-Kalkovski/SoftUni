using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.World_Swimming_Record
{
    class Program
    {
        static void Main(string[] args)
        {

            double record = double.Parse(Console.ReadLine());
            double length = double.Parse(Console.ReadLine());
            double time = double.Parse(Console.ReadLine());

            double lengthAndTime = length * time;
            double timeTrue = length / 15;
            int metersRound = (int)timeTrue;
            double metersLost = metersRound * 12.5;
            double timeRound = lengthAndTime + metersLost;
            double recordFailed = timeRound - record;

            if (record <= timeRound)
            {
                Console.WriteLine($"No, he failed! He was {recordFailed:F2} seconds slower.");
            }

            else if (record > timeRound)
            {
                Console.WriteLine($"Yes, he succeeded! The new world record is {timeRound:F2} seconds.");
            }

        }
    }
}
