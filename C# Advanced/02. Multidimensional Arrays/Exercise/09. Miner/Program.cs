using System;
using System.Linq;

namespace _09.Miner
{
    public class Miner
    {
        public static void Main()
        {
            int size = int.Parse(Console.ReadLine());

            string[] directions = Console.ReadLine().Split();
            char[,] matrix = new char[size, size];

            int startRow = 0;
            int startCol = 0;
            int maxCoals = 0;

            for (int row = 0; row < size; row++)
            {
                char[] input = Console.ReadLine()
                    .Where(c => c != ' ').ToArray();

                for (int col = 0; col < size; col++)
                {
                    if (input[col] == 's')
                    {
                        startRow = row;
                        startCol = col;
                    }

                    if (input[col] == 'c')
                    {
                        maxCoals++;
                    }
                    matrix[row, col] = input[col];
                }
            }

            bool isEnd = false;
            int countCoals = 0;
            int targetRow = 0;
            int targetCol = 0;

            foreach (var direction in directions)
            {
                if (direction == "up")
                {
                    if (IsRange(startRow - 1, startCol, matrix))
                    {
                        startRow--;
                    }

                }
                else if (direction == "down")
                {
                    if (IsRange(startRow + 1, startCol, matrix))
                    {
                        startRow++;
                    }
                }
                else if (direction == "left")
                {
                    if (IsRange(startRow, startCol - 1, matrix))
                    {
                        startCol--;
                    }

                }
                else if (direction == "right")
                {
                    if (IsRange(startRow, startCol + 1, matrix))
                    {
                        startCol++;
                    }

                }

                if (matrix[startRow, startCol] == 'e')
                {
                    targetRow = startRow;
                    targetCol = startCol;
                    isEnd = true;
                    break;
                }

                if (matrix[startRow, startCol] == 'c')
                {
                    matrix[startRow, startCol] = '*';
                    countCoals++;
                }
                else
                {
                    matrix[startRow, startCol] = 's';
                }

                targetRow = startRow;
                targetCol = startCol;
            }

            if (isEnd)
            {
                Console.WriteLine($"Game over! ({targetRow}, {targetCol})");
            }
            else if (countCoals < maxCoals)
            {
                Console.WriteLine($"{maxCoals - countCoals} coals left. ({targetRow}, {targetCol})");
            }
            else
            {
                Console.WriteLine($"You collected all coals! ({targetRow}, {targetCol})");
            }
        }

        private static bool IsRange(int startRow, int startCol, char[,] matrix)
        {
            return startRow >= 0 && startRow < matrix.GetLength(0)
                 && startCol >= 0 && startCol < matrix.GetLength(1);
        }
    }
}