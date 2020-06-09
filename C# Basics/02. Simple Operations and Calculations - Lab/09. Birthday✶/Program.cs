using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Birthday_
{
    class Program
    {
        static void Main(string[] args)
        {

            double aquariumLength = double.Parse(Console.ReadLine());
            double aquariumWidth = double.Parse(Console.ReadLine());
            double aquariumHeight = double.Parse(Console.ReadLine());
            double percent = double.Parse(Console.ReadLine());

            double area = aquariumHeight * aquariumLength * aquariumWidth;
            double areaLiters = area * 0.001;
            double totalPercent = percent * 0.01;
            double totalArea = areaLiters * (1 - totalPercent);
            
            Console.WriteLine($"{totalArea:F3}");
        }
    }
}
