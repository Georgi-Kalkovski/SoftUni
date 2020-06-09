using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Choreography
{
    class Program
    {
        static void Main(string[] args)
        {

            double steps = double.Parse(Console.ReadLine());
            double dancers = double.Parse(Console.ReadLine());
            double days = double.Parse(Console.ReadLine());

            double stepsPerDay = ((steps / days) / steps)*100;
            stepsPerDay = Math.Ceiling(stepsPerDay);
            double stepsPercent = (stepsPerDay / dancers);
            if (stepsPerDay <= 13)
            {
                Console.WriteLine($"Yes, they will succeed in that goal! {stepsPercent:F2}%.");
            }

            else if (stepsPerDay > 13)
            {
                Console.WriteLine($"No, they will not succeed in that goal! Required {stepsPercent:F2}% steps to be learned per day.");
            }
        }
    }
}
