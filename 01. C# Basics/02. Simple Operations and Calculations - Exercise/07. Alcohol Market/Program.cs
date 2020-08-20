using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Alcohol_Market
{
    class Program
    {
        static void Main(string[] args)
        {

            double whiskeyBGN = double.Parse(Console.ReadLine());
            double beerL = double.Parse(Console.ReadLine());
            double wineL = double.Parse(Console.ReadLine());
            double rakiaL = double.Parse(Console.ReadLine());
            double whiskeyL = double.Parse(Console.ReadLine());

            double rakiaBGN = whiskeyBGN / 2;
            double wineBGN = rakiaBGN - rakiaBGN*0.4;
            double beerBGN = rakiaBGN - rakiaBGN*0.8;
            double totalBGN = (whiskeyL * whiskeyBGN) + (rakiaL * rakiaBGN) + (wineL * wineBGN) + (beerL * beerBGN);
            
            Console.WriteLine($"{totalBGN:F2}");
        }
    }
}
