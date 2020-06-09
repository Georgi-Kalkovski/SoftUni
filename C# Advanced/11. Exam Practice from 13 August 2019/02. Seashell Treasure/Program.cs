using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Seashell_Treasure
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            char[][] beach = new char[rows][];

            for (int row = 0; row < beach.Length; row++)
            {
                char[] currentRow = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                beach[row] = currentRow;
            }

            int collectedCounter = 0;
            int stolenCounter = 0;
            var collectedList = new List<char>();

            while (true)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "Sunset")
                {
                    break;
                }

                string command = input[0];
                int firstCoord = int.Parse(input[1]);
                int secondCoord = int.Parse(input[2]);
                string direction;

                if (command == "Collect" && IsInside(beach, firstCoord, secondCoord))
                {
                    if (beach[firstCoord][secondCoord] == 'C' || beach[firstCoord][secondCoord] == 'N' || beach[firstCoord][secondCoord] == 'M')
                    {
                        collectedCounter++;
                        collectedList.Add(beach[firstCoord][secondCoord]);
                        beach[firstCoord][secondCoord] = '-';
                    }
                }

                if (command == "Steal" && IsInside(beach, firstCoord, secondCoord))
                {
                    direction = input[3];

                    switch (direction)
                    {
                        case "up":

                            for (int i = 0; i < 4; i++)
                            {
                                if (beach[firstCoord - i][secondCoord] == 'C' 
                                    || beach[firstCoord - i][secondCoord] == 'N' 
                                    || beach[firstCoord - i][secondCoord] == 'M')
                                {
                                    stolenCounter++;
                                    beach[firstCoord - i][secondCoord] = '-';
                                }
                            }
                            break;

                        case "down":
                            for (int i = 0; i < 3; i++)
                            {
                                if (beach[firstCoord + i][secondCoord] == 'C' 
                                    || beach[firstCoord + i][secondCoord] == 'N' 
                                    || beach[firstCoord + i][secondCoord] == 'M')
                                {
                                    stolenCounter++;
                                    beach[firstCoord + i][secondCoord] = '-';
                                }
                            }
                            break;

                        case "left":
                            for (int i = 0; i < 3; i++)
                            {
                                if (beach[firstCoord][secondCoord - i] == 'C'
                                    || beach[firstCoord][secondCoord - i] == 'N'
                                    || beach[firstCoord][secondCoord - i] == 'M')
                                {
                                    stolenCounter++;
                                    beach[firstCoord][secondCoord - i] = '-';
                                }
                            }
                            break;

                        case "right":
                            for (int i = 0; i < 3; i++)
                            {
                                if (beach[firstCoord][secondCoord + i] == 'C'
                                    || beach[firstCoord][secondCoord + i] == 'N'
                                    || beach[firstCoord][secondCoord + i] == 'M' && beach[firstCoord][secondCoord + i] < beach[firstCoord][secondCoord + i])
                                {
                                    stolenCounter++;
                                    beach[firstCoord][secondCoord + i] = '-';
                                }
                            }
                            break;
                    }
                }
            }
        }
        static bool IsInside(char[][] beach, int firstCoord, int secondCoord)
        {
            if (beach.Length >= firstCoord)
            {
                if (beach[firstCoord].Length >= secondCoord)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}
