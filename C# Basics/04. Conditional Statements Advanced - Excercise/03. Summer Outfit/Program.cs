using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Summer_Outfit
{
    class Program
    {
        static void Main(string[] args)
        {

            double degree = double.Parse(Console.ReadLine());
            string day = Console.ReadLine();
            string outfit = string.Empty;
            string shoes = string.Empty;

            if (day == "Morning")
            {
                if (degree >= 10 && degree <= 18)
                {
                    outfit = "Sweatshirt";
                    shoes = "Sneakers";
                }

                else if (degree > 18 && degree <= 24)
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }

                else if (degree >= 25)
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                }
            }

            else if (day == "Afternoon")
            {
                if (degree >= 10 && degree <= 18)
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }

                else if (degree > 18 && degree <= 24)
                {
                    outfit = "T-Shirt";
                    shoes = "Sandals";
                }

                else if (degree >= 25)
                {
                    outfit = "Swim Suit";
                    shoes = "Barefoot";
                }
            }

            else if (day == "Evening")
            {
                if (degree >= 10 && degree <= 18)
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }

                else if (degree > 18 && degree <= 24)
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }

                else if (degree >= 25)
                {
                    outfit = "Shirt";
                    shoes = "Moccasins";
                }
            }

            Console.WriteLine($"It's {degree} degrees, get your {outfit} and {shoes}.");
        }
    }
}
