using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Sushi_Time
{
    class Program
    {
        static void Main(string[] args)
        {

            string nameOfSushi = Console.ReadLine();
            string nameOfRestaurant = Console.ReadLine();
            int amount = int.Parse(Console.ReadLine());
            string yesOrNo = Console.ReadLine();

            double food = 0;
            
            switch (nameOfSushi)
            {
                case "sashimi":
				
                    switch (nameOfRestaurant)
                    {
                        case "Sushi Zone":food += 4.99; break;
                        case "Sushi Time":food += 5.49; break;
                        case "Sushi Bar": food += 5.25; break;
                        case "Asian Pub": food += 4.50; break;
                        default:
                            Console.WriteLine($"{nameOfRestaurant} is invalid restaurant!");
                            return;
                    }
                    break;

                case "maki":
				
                    switch (nameOfRestaurant)
                    {
                        case "Sushi Zone": food += 5.29; break;
                        case "Sushi Time": food += 4.69; break;
                        case "Sushi Bar": food += 5.55; break;
                        case "Asian Pub": food += 4.80; break;
                        default:
                            Console.WriteLine($"{nameOfRestaurant} is invalid restaurant!");
                            return;
                    }
                    break;

                case "uramaki":
				
                    switch (nameOfRestaurant)
                    {
                        case "Sushi Zone": food += 5.99; break;
                        case "Sushi Time": food += 4.49; break;
                        case "Sushi Bar": food += 6.25; break;
                        case "Asian Pub": food += 5.50; break;
                        default:
                            Console.WriteLine($"{nameOfRestaurant} is invalid restaurant!");
                            return;
                    }
                    break;

                case "temaki":
				
                    switch (nameOfRestaurant)
                    {
                        case "Sushi Zone": food += 4.29; break;
                        case "Sushi Time": food += 5.19; break;
                        case "Sushi Bar": food += 4.75; break;
                        case "Asian Pub": food += 5.50; break;
                        default:
                            Console.WriteLine($"{nameOfRestaurant} is invalid restaurant!");
                            return;
                    }
                    break;
            }

            double sum = food * amount;

            if (yesOrNo == "Y")
            {
                double delivery = sum * 0.20;
                sum = sum + delivery;
            }

            Console.WriteLine($"Total price: {Math.Ceiling(sum)} lv.");
        }
    }
}
