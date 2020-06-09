using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Football_Souvenirs
{
    class Program
    {
        static void Main(string[] args)
        {

            string team = Console.ReadLine();
            string item = Console.ReadLine();
            int amount = int.Parse(Console.ReadLine());
            double sum = 0;

            switch (team)
            {

                case "Argentina":
				
                    switch (item)
                    {
                        case "flags": sum += 3.25 * amount; break;
                        case "caps": sum += 7.20 * amount; break;
                        case "posters": sum +=5.10 * amount; break;
                        case "stickers": sum += 1.25 * amount; break;
                        default: Console.WriteLine("Invalid stock!"); return;
                    }
                    break;

                case "Brazil":
				
                    switch (item)
                    {
                        case "flags": sum += 4.20 * amount; break;
                        case "caps": sum += 8.50 * amount; break;
                        case "posters": sum += 5.35 * amount; break;
                        case "stickers": sum += 1.20 * amount; break;
                        default: Console.WriteLine("Invalid stock!"); return;
                    }
                    break;

                case "Croatia":
				
                    switch (item)
                    {
                        case "flags": sum += 2.75 * amount; break;
                        case "caps": sum += 6.90 * amount; break;
                        case "posters": sum += 4.95 * amount; break;
                        case "stickers": sum += 1.10 * amount; break;
                        default: Console.WriteLine("Invalid stock!"); return;
                    }
                    break;

                case "Denmark":
				
                    switch (item)
                    {
                        case "flags": sum += 3.10 * amount; break;
                        case "caps": sum += 6.50 * amount; break;
                        case "posters": sum += 4.80 * amount; break;
                        case "stickers": sum += 0.90 * amount; break;
                        default: Console.WriteLine("Invalid stock!"); return;
                    }
                    break;

                default: Console.WriteLine("Invalid country!"); return;
            }
            Console.WriteLine($"Pepi bought {amount} {item} of {team} for {sum:F2} lv.");
        }
    }
}
