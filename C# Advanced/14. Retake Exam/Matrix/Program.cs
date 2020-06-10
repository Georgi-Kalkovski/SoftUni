using System;
using System.Linq;

namespace Matrix
{
    public class Program
    {
        static void Main(string[] args)
        {
            var presentsCount = int.Parse(Console.ReadLine());
            var row = int.Parse(Console.ReadLine());
            var matrix = new char[row][];
            var goodKidsWithoutPresent = 0;
            var goodKidsWithPresent = 0;


            for (int i = 0; i < row; i++)
            {
                char[] currentRow = Console.ReadLine()
                    .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse).ToArray();
                matrix[i] = new char[currentRow.Length];

                for (int j = 0; j < currentRow.Length; j++)
                {
                    matrix[i][j] = currentRow[j];
                    if (currentRow[j] == 'V')
                    {
                        goodKidsWithoutPresent++;
                    }
                }
            }
            var playerPos = GetIntialPos(matrix);
            string input;

            while ((input = Console.ReadLine()) != "Christmas morning" && presentsCount > 0)
            {

                switch (input)
                {
                    case "up":
                        if (playerPos[0] - 1 > -1) playerPos[0] -= 1;
                        break;
                    case "down":
                        if (playerPos[0] + 1 < row) playerPos[0] += 1;
                        break;
                    case "left":
                        if (playerPos[1] - 1 > -1) playerPos[1] -= 1;
                        break;
                    case "right":
                        if (playerPos[1] + 1 < row) playerPos[1] += 1;
                        break;
                }
                if (matrix[playerPos[0]][playerPos[1]] != '-')
                {
                    if (matrix[playerPos[0]][playerPos[1]] == 'C')
                    {
                        if (matrix[playerPos[0] + 1][playerPos[1]] == 'V' && presentsCount > 0)
                        {
                            matrix[playerPos[0] + 1][playerPos[1]] = '-';
                            goodKidsWithPresent++;
                            goodKidsWithoutPresent--;
                            presentsCount--;
                            if (presentsCount == 0) break;
                        }
                        if (matrix[playerPos[0] - 1][playerPos[1]] == 'V' && presentsCount > 0)
                        {
                            matrix[playerPos[0] - 1][playerPos[1]] = '-';
                            goodKidsWithPresent++;
                            goodKidsWithoutPresent--;
                            presentsCount--;
                            if (presentsCount == 0) break;
                        }
                        if (matrix[playerPos[0]][playerPos[1] + 1] == 'V' && presentsCount > 0)
                        {
                            matrix[playerPos[0]][playerPos[1] + 1] = '-';
                            goodKidsWithPresent++;
                            goodKidsWithoutPresent--;
                            presentsCount--;
                            if (presentsCount == 0) break;
                        }
                        if (matrix[playerPos[0]][playerPos[1] - 1] == 'V' && presentsCount > 0)
                        {
                            matrix[playerPos[0]][playerPos[1] - 1] = '-';
                            goodKidsWithPresent++;
                            goodKidsWithoutPresent--;
                            presentsCount--;
                            if (presentsCount == 0) break;
                        }
                        if (matrix[playerPos[0]][playerPos[1] - 1] == 'X')
                        {
                            matrix[playerPos[0]][playerPos[1] - 1] = '-';
                            presentsCount--;
                            if (presentsCount == 0) break;
                        }
                        if (matrix[playerPos[0]][playerPos[1] + 1] == 'X')
                        {
                            matrix[playerPos[0]][playerPos[1] + 1] = '-';
                            presentsCount--;
                            if (presentsCount == 0) break;
                        }
                        if (matrix[playerPos[0] - 1][playerPos[1]] == 'X')
                        {
                            matrix[playerPos[0] - 1][playerPos[1]] = '-';
                            presentsCount--;
                            if (presentsCount == 0) break;
                        }
                        if (matrix[playerPos[0]+ 1][playerPos[1]] == 'X')
                        {
                            matrix[playerPos[0] + 1][playerPos[1]] = '-';
                            presentsCount--;
                            if (presentsCount == 0) break;
                        }
                    }
                    if (matrix[playerPos[0]][playerPos[1]] == 'V' && presentsCount > 0)
                    {
                        goodKidsWithPresent++;
                        goodKidsWithoutPresent--;
                        presentsCount--;
                        if (presentsCount == 0) break;
                    }
                    matrix[playerPos[0]][playerPos[1]] = '-';
                }
            }

            if (presentsCount == 0)
            {
                Console.WriteLine("Santa ran out of presents!");
            }
            PrintMatrix(matrix, playerPos);
            if (goodKidsWithoutPresent == 0)
            {
                Console.WriteLine($"Good job, Santa! {goodKidsWithPresent} happy nice kid/s.");
            }
            else
            {
                Console.WriteLine($"No presents for {goodKidsWithoutPresent} nice kid/s.");
            }
            
        }

        private static void PrintMatrix(char[][] matrix, int[] playerPos)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix[i].GetLength(0); j++)
                {

                    if (i == playerPos[0] && j == playerPos[1]) Console.Write("S");
                    else Console.Write(matrix[i][j]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }
        }

        private static int[] GetIntialPos(char[][] matrix)
        {
            var result = new int[2];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix[i].GetLength(0); j++)
                {
                    if (matrix[i][j] == 'S')
                    {
                        result[0] = i;
                        result[1] = j;
                        matrix[i][j] = '-';
                    }
                }
            }
            return result;
        }
    }
}