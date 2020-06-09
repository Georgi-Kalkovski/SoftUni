using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Tailoring_Workshop
{
    class Program
    {
        static void Main(string[] args)
        {

            int tables = int.Parse(Console.ReadLine());
            double tablesLength = double.Parse(Console.ReadLine());
            double tablesWidth = double.Parse(Console.ReadLine());

            
            double clothsTotal = tables*((tablesLength + 2 * 0.30) * (tablesWidth + 2 * 0.30));
            double loinsTotal = tables* ((tablesLength / 2)*(tablesLength / 2));
            
            double totalPriceUSD = (clothsTotal * 7) + (loinsTotal * 9);
            double totalPriceBGN = totalPriceUSD * 1.85;

            Console.WriteLine($"{totalPriceUSD:F2} USD");
            Console.WriteLine($"{totalPriceBGN:F2} BGN");
        }
    }
}
