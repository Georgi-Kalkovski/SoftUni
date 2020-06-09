using System;
using System.Collections.Generic;
using System.Linq;

namespace _02
{
    public class SeashellTreasure
    {
        public static void Main(string[] args)
        {
            char[][] beach = new char[int.Parse(Console.ReadLine())][];
            int stolen = 0;
            List<char> collected = new List<char>();

            for (int i = 0; i < beach.Length; i++)
                beach[i] = Console.ReadLine().Replace(" ", "").ToCharArray();

            string[] commandTokens = new string[0];
            while ((commandTokens = Console.ReadLine().Split())[0] != "Sunset")
            {
                int row = int.Parse(commandTokens[1]);
                int col = int.Parse(commandTokens[2]);

                if (commandTokens[0] == "Collect" && IsIndexValid(row, col, beach) && beach[row][col] != '-')
                {
                    collected.Add(beach[row][col]);
                    beach[row][col] = '-';
                }
                else if (commandTokens[0] == "Steal")
                {
                    string direction = commandTokens[3];

                    if (IsIndexValid(row, col, beach))
                    {
                        if (direction == "down")
                        {
                            for (int i = row; i <= row + 3; i++)
                            {
                                if (IsIndexValid(i, col, beach) && beach[i][col] != '-')
                                {
                                    stolen++;
                                    beach[i][col] = '-';
                                }
                            }
                        }
                        else if (direction == "up")
                        {
                            for (int i = row; i >= row - 3; i--)
                            {
                                if (IsIndexValid(i, col, beach) && beach[i][col] != '-')
                                {
                                    stolen++;
                                    beach[i][col] = '-';
                                }
                            }
                        }
                        else if (direction == "left")
                        {
                            for (int i = col; i >= col - 3; i--)
                            {
                                if (IsIndexValid(row, i, beach) && beach[row][i] != '-')
                                {
                                    stolen++;
                                    beach[row][i] = '-';
                                }
                            }
                        }
                        else if (direction == "right")
                        {
                            for (int i = col; i <= col + 3; i++)
                            {
                                if (IsIndexValid(row, i, beach) && beach[row][i] != '-')
                                {
                                    stolen++;
                                    beach[row][i] = '-';
                                }
                            }
                        }
                    }
                }
            }

            foreach (var row in beach)
            {
                Console.WriteLine(string.Join(' ', row));
            }

            if (collected.Count != 0)
            {
                Console.WriteLine($"Collected seashells: {collected.Count} -> {string.Join(", ", collected)}");
            }
            else
            {
                Console.WriteLine($"Collected seashells: {collected.Count}");
            }

            Console.WriteLine($"Stolen seashells: {stolen}");
        }

        public static bool IsIndexValid(int row, int col, char[][] matrix) =>
            (row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length) ? true : false;
    }
}

