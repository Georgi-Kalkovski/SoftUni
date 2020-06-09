using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.New_House
{
    class Program
    {
        static void Main(string[] args)
        {

            double roses = 5;
            double dahlias = 3.80;
            double tulips = 2.80;
            double narcissus = 3;
            double gladiolus = 2.50;

            string type = Console.ReadLine();
            int amount = int.Parse(Console.ReadLine());
            double budget = double.Parse(Console.ReadLine());

            double counter = 0;

            if (type == "Roses")
            {
                counter = amount * roses;
                {
                    if (amount > 80)
                    {
                        counter -= counter * 0.10;
                    }
                }
            }
            else if (type == "Dahlias")
            {
                counter = amount * dahlias;
                {
                    if (amount > 90)
                    {
                        counter -= counter * 0.15;
                    }
                }
            }
            else if (type == "Tulips")
            {
                counter = amount * tulips;
                {
                    if (amount > 80)
                    {
                        counter -= counter * 0.15;
                    }
                }
            }
            else if (type == "Narcissus")
            {
                counter = amount * narcissus;
                {
                    if (amount < 120)
                    {
                        counter += counter * 0.15;
                    }
                }
            }
            else if (type == "Gladiolus")
            {
                counter = amount * gladiolus;
                {
                    if (amount < 80)
                    {
                        counter += counter * 0.20;
                    }
                }
            }
            if (counter <= budget)
            {
                budget -= counter;
                Console.WriteLine($"Hey, you have a great garden with {amount} {type} and {budget:F2} leva left.");
            }
            else if (counter >= budget)
            {
                counter -= budget;
                Console.WriteLine($"Not enough money, you need {counter:F2} leva more.");
            }
        }
    }
}
