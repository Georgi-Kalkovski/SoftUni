using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Three_brothers
{
    class Program
    {
        static void Main(string[] args)
        {

            double brotherA = double.Parse(Console.ReadLine());
            double brotherB = double.Parse(Console.ReadLine());
            double brotherC = double.Parse(Console.ReadLine());
            double fatherD = double.Parse(Console.ReadLine());

            double brothersTime =1/(1/brotherA + 1/brotherB + 1/brotherC) * 1.15;
            double timeLeft = fatherD - brothersTime;
            Console.WriteLine($"Cleaning time: {brothersTime:F2}");

            if (fatherD > brothersTime)
            {
                Console.WriteLine($"Yes, there is a surprise - time left -> {Math.Floor(timeLeft)} hours.");
            }

            else if (fatherD < brothersTime)
            {
                timeLeft = Math.Abs(timeLeft);
                Console.WriteLine($"No, there isn't a surprise - shortage of time -> {Math.Ceiling(timeLeft)} hours.");
            }
        }
    }
}
