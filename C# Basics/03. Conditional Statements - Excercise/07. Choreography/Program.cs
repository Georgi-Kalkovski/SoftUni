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
            // vuvejdame stupkite na tanca
            double dancers = double.Parse(Console.ReadLine());
            // vuvejdame broq tanciori
            double days = double.Parse(Console.ReadLine());
            // vuvejdame broq dni na razpolojenie

            double stepsPerDay = ((steps / days) / steps)*100;
            // namirame stupkite na den kato razdelim stupkite po dnite i posle otnovo po stupkite, i posle vsihko umnojim po 100
            stepsPerDay = Math.Ceiling(stepsPerDay);
            // zakruglqme stupkite na den kum po gorno chislo
            double stepsPercent = (stepsPerDay / dancers);
            // namirame procenta na nauchenite stupki

            if (stepsPerDay <= 13)
            // ako stupkite sa po-malko ot 14
            {
                Console.WriteLine($"Yes, they will succeed in that goal! {stepsPercent:F2}%.");
                // vadim na konzolata uspeh i procenta naucheni stupki
            }

            else if (stepsPerDay > 13)
            // ako procenta e poveche ot 13
            {
                Console.WriteLine($"No, they will not succeed in that goal! Required {stepsPercent:F2}% steps to be learned per day.");
                // vadim na konzlata neuspeh i procenta nujni stupki na den
            }
        }
    }
}
