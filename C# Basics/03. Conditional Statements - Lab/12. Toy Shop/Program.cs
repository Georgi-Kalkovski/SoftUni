using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Toy_Shop
{
    class Program
    {
        static void Main(string[] args)
        {

            double puzzlePrice = 2.60;
            double talkingDallPrice = 3;
            double plushToyPrice = 4.10;
            double minionPrice = 8.20;
            double truckPrice = 2;

            int toysTotal = 0;
            double toysPrice = 0;

            double trip = double.Parse(Console.ReadLine());
            int puzzle = int.Parse(Console.ReadLine());
            int talkingDall = int.Parse(Console.ReadLine());
            int plushToy = int.Parse(Console.ReadLine());
            int minion = int.Parse(Console.ReadLine());
            int truck = int.Parse(Console.ReadLine());
            
            toysTotal = puzzle + talkingDall + plushToy + minion + truck;
            toysPrice = (puzzle * puzzlePrice) + (talkingDall * talkingDallPrice) + (plushToy * plushToyPrice) + (minion * minionPrice) + (truck * truckPrice);

            if (toysTotal >= 50)
            {
                toysPrice = toysPrice - (toysPrice * 0.25);
            }

            toysPrice = toysPrice - (toysPrice * 0.10);

            if (toysPrice >= trip)
            {
                Console.WriteLine($"Yes! {toysPrice - trip:F2} lv left.");
            }

            else if (toysPrice < trip)
            {
                Console.WriteLine($"Not enough money! {trip - toysPrice:F2} lv needed.");
            }
        }
    }
}
