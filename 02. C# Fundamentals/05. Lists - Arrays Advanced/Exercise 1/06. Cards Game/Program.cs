using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Cards_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstPlayersCards = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            List<int> secondPlayersCards = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                if (firstPlayersCards.Sum() == 0)
                {
                    Console.WriteLine($"Second player wins! Sum: {secondPlayersCards.Sum()}");
                    break;
                }

                if (secondPlayersCards.Sum() == 0)
                {
                    Console.WriteLine($"First player wins! Sum: {firstPlayersCards.Sum()}");
                    break;
                }

                if (firstPlayersCards[0] > secondPlayersCards[0])
                {
                    firstPlayersCards.Add(firstPlayersCards[0]);
                    firstPlayersCards.Add(secondPlayersCards[0]);
                    firstPlayersCards.Remove(firstPlayersCards[0]);
                    secondPlayersCards.Remove(secondPlayersCards[0]);
                    continue;
                }

                if (secondPlayersCards[0] > firstPlayersCards[0])
                {
                    secondPlayersCards.Add(secondPlayersCards[0]);
                    secondPlayersCards.Add(firstPlayersCards[0]);
                    secondPlayersCards.Remove(secondPlayersCards[0]);
                    firstPlayersCards.Remove(firstPlayersCards[0]);
                    continue;
                }

                if (firstPlayersCards[0] == secondPlayersCards[0])
                {
                    firstPlayersCards.Remove(firstPlayersCards[0]);
                    secondPlayersCards.Remove(secondPlayersCards[0]);
                    continue;
                }
            }
        }
    }
}
