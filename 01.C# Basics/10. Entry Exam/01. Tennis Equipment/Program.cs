using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Tennis_Equipment
{
    class Program
    {
        static void Main(string[] args)
        {

            double tennisRaquets = double.Parse(Console.ReadLine());   
            int numOfRaquets = int.Parse(Console.ReadLine());          
            int numOfSneakers = int.Parse(Console.ReadLine());         

            double priceOfRacquets = numOfRaquets * tennisRaquets;              
            double priceOfSingleSneakers = tennisRaquets / 6;                   
            double priceOfSneakers = numOfSneakers * priceOfSingleSneakers;     
            double priceOfOtherEquipment = (priceOfRacquets + priceOfSneakers) * 0.2;       
            double totalPrice = priceOfRacquets + priceOfSneakers + priceOfOtherEquipment;  

            double priceForDjokovic = totalPrice / 8;          
            double priceForSponsors = totalPrice * 7 / 8;      

            Console.WriteLine($"Price to be paid by Djokovic {Math.Floor(priceForDjokovic)}");  
            Console.WriteLine($"Price to be paid by sponsors {Math.Ceiling(priceForSponsors)}");
        }
    }
}
