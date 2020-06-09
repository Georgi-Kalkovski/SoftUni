using System;

namespace _03._Gaming_Store
{
    class Program
    {
        static void Main(string[] args)
        {
            double currentBalance = double.Parse(Console.ReadLine());
            double currentPrice = 0;
            double spendedMoney = 0;

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Game Time")
                {
                    if (currentBalance == 0)
                    {
                        Console.WriteLine("Out of money!");
                        return;
                    }
					
                    Console.WriteLine($"Total spent: ${spendedMoney:F2}. Remaining: ${currentBalance:F2}");
                    break;
                }

                switch (input)
                {
                    case "OutFall 4": currentPrice = 39.99; break;
                    case "CS: OG": currentPrice = 15.99; break;
                    case "Zplinter Zell": currentPrice = 19.99; break;
                    case "Honored 2": currentPrice = 59.99; break;
                    case "RoverWatch": currentPrice = 29.99; break;
                    case "RoverWatch Origins Edition": currentPrice = 39.99; break;
                    default: Console.WriteLine("Not Found"); continue;
                }

                if (currentBalance == 0)
                {
                    Console.WriteLine("Out of money!");
                    break;
                }

                if (currentBalance < currentPrice)
                {
                    Console.WriteLine("Too Expensive");
                    continue;
                }

                currentBalance -= currentPrice;
                spendedMoney += currentPrice;
                Console.WriteLine($"Bought {input}");
            }
        }
    }
}
