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
            // imame cena za dadeni igrachki 

            int toysTotal = 0;
            // mqsto za skladirane broq na igrachkite
            double toysPrice = 0;
            // mqsto za subirane cenata na vsichki igrachki

            double trip = double.Parse(Console.ReadLine());
            // vuvejdane cenata na pochivkata
            int puzzle = int.Parse(Console.ReadLine());
            int talkingDall = int.Parse(Console.ReadLine());
            int plushToy = int.Parse(Console.ReadLine());
            int minion = int.Parse(Console.ReadLine());
            int truck = int.Parse(Console.ReadLine());
            // pishem na konzolata broq na vsqka igracha
            
            toysTotal = puzzle + talkingDall + plushToy + minion + truck;
            // smqtame obshtiq broi na igrachkite
            toysPrice = (puzzle * puzzlePrice) + (talkingDall * talkingDallPrice) + (plushToy * plushToyPrice) + (minion * minionPrice) + (truck * truckPrice);
            // smqtame cenata na igrachkite kato umnojim vsqka edna igrachka po suotvetnata i cena i suberem vsichko zaedno

            if (toysTotal >= 50)
            // ako igrachkite sa nad 50 broiki
            {
                toysPrice = toysPrice - (toysPrice * 0.25);
                // magazina pravi 25% otstupka
            }

            toysPrice = toysPrice - (toysPrice * 0.10);
            // vadqt se oshte 10% za pokrivane na materialite na igrachkite

            if (toysPrice >= trip)
            // ako prodajbata e po-golqma ili ravna na pochivkata
            {
                Console.WriteLine($"Yes! {toysPrice - trip:F2} lv left.");
                // vadim na konzolata pozidivno suobshtenie s ostatuka na parite 
            }

            else if (toysPrice < trip)
            // ako cenata na prodajbata e po- malka ot pochivkata
            {
                Console.WriteLine($"Not enough money! {trip - toysPrice:F2} lv needed.");
                // vadim na konzolata negativno suobshtenie s nedostigastit pari za pochivkata
            }
        }
    }
}
