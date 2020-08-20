using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Best_Player
{
    class Program
    {
        static void Main(string[] args)
        {

            string bestPlayer = string.Empty;
            string currentPlayer = string.Empty;
            int maxGoals = int.MinValue;

            while (currentPlayer != "END")
            {
                currentPlayer = Console.ReadLine();

                if (currentPlayer == "END")
                {
                    break;
                }

                int currentGoals = int.Parse(Console.ReadLine());

                if (currentGoals == maxGoals)
                {
                    continue;
                }

                if (currentGoals > maxGoals)
                {
                    maxGoals = currentGoals;
                    bestPlayer = currentPlayer;

                    if (currentGoals >= 10)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine($"{bestPlayer} is the best player!");

            if (maxGoals >= 3)
            {
                Console.WriteLine($"He has scored {maxGoals} goals and made a hat-trick !!!");
            }

            else
            {
                Console.WriteLine($"He has scored {maxGoals} goals.");
            }
        }
    }
}
