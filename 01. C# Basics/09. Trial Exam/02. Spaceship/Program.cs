using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Spaceship
{
    class Program
    {
        static void Main(string[] args)
        {

            double spaceshipWidth = double.Parse(Console.ReadLine());
            double spaceshipLength = double.Parse(Console.ReadLine());
            double spaceshipHeight = double.Parse(Console.ReadLine());
            double austronautsHeight = double.Parse(Console.ReadLine());

            double spaceshipArea = spaceshipWidth * spaceshipLength * spaceshipHeight;
            double roomArea = (austronautsHeight + 0.40) * 2 * 2;
            double roomForAustronauts = Math.Floor(spaceshipArea / roomArea);

            if (roomForAustronauts >= 3 && roomForAustronauts <= 10)
            {
                Console.WriteLine($"The spacecraft holds {roomForAustronauts} astronauts.");
            }
			
            if (roomForAustronauts < 3)
            {
                Console.WriteLine($"The spacecraft is too small.");
            }
			
            if (roomForAustronauts > 10)
            {
                Console.WriteLine($"The spacecraft is too big.");
            }
        }
    }
}
