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
            // vuvejdame duljina na akvariuma
            double aquariumWidth = double.Parse(Console.ReadLine());
            // vuvejdame shirochina na akvariuma
            double aquariumHeight = double.Parse(Console.ReadLine());
            // vuvejdame visochina na akvariuma
            double percent = double.Parse(Console.ReadLine());
            // vuvejdame izlishniq procent ot obema na akvariuma

            double area = aquariumHeight * aquariumLength * aquariumWidth;
            // izchislqvame obema
            double areaLiters = area * 0.001;
            // prevrushtame obema v litri
            double totalPercent = percent * 0.01;
            // prevrushtame procenta v litri
            double totalArea = areaLiters * (1 - totalPercent);
            // izchislqvame ostatuka obem 
            Console.WriteLine($"{totalArea:F3}");
            // vadim na konzolata rezultata do vtoriq znak sled desetichnata zapetaq
        }
    }
}
