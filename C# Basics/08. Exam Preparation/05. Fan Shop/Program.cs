using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Fan_Shop
{
    class Program
    {
        static void Main(string[] args)
        {

            int budget = int.Parse(Console.ReadLine());
            int numberOfItems = int.Parse(Console.ReadLine());

            int sum = 0;
            

            for (int i = 0; i < numberOfItems; i++)
            {
                string item = Console.ReadLine();

                switch (item)
                {
                    case "hoodie": sum += 30; break;
                    case "keychain": sum += 4; break;
                    case "T-shirt": sum += 20; break;
                    case "flag": sum += 15; break;
                    case "sticker": sum ++; break;
                }
            }

            if (budget >= sum)
            {
                Console.WriteLine($"You bought {numberOfItems} items and left with {budget - sum} lv.");
            }

            else
            {
                Console.WriteLine($"Not enough money, you need {sum - budget} more lv.");
            }
        }
    }
}
