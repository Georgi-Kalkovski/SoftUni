using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _8._Bombs
{
    class Program
    {
        static int[][] matrix;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            matrix = new int[n][];

            FillMatrix();

            string[] bombs = Console.ReadLine().Split();
            Queue<string> coordinate = new Queue<string>(bombs);

            Explosion(coordinate);

            int aliveCount = 0;
            long sum = 0;
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] > 0)
                    {
                        aliveCount++;
                        sum += matrix[row][col];
                    }
                }
            }

            Console.WriteLine($"Alive cells: {aliveCount}");
            Console.WriteLine($"Sum: {sum}");

            PrintMatrix();
        }
        private static void Explosion(Queue<string> coordinate)
        {
            while (coordinate.Count > 0)
            {
                int[] input = coordinate.Dequeue().Split(',').Select(int.Parse).ToArray();
                int r = input[0];
                int c = input[1];
                if (matrix[r][c] > 0)
                {
                    int bombPower = matrix[r][c];

                    if (IsToExplode(r - 1, c - 1)) matrix[r - 1][c - 1] -= bombPower;
                    if (IsToExplode(r - 1, c + 1)) matrix[r - 1][c + 1] -= bombPower;
                    if (IsToExplode(r, c - 1)) matrix[r][c - 1] -= bombPower;
                    if (IsToExplode(r, c + 1)) matrix[r][c + 1] -= bombPower;
                    if (IsToExplode(r + 1, c - 1)) matrix[r + 1][c - 1] -= bombPower;
                    if (IsToExplode(r + 1, c + 1)) matrix[r + 1][c + 1] -= bombPower;
                    if (IsToExplode(r - 1, c)) matrix[r - 1][c] -= bombPower;
                    if (IsToExplode(r + 1, c)) matrix[r + 1][c] -= bombPower;

                    matrix[r][c] = 0;
                }
            }
        }
        private static bool IsToExplode(int r, int c)
        {
            return r >= 0 && r < matrix.Length && c >= 0 && c < matrix[r].Length && matrix[r][c] > 0;
        }
        private static void PrintMatrix()
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine(string.Join(" ", matrix[row]));
            }
        }
        private static void FillMatrix()
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new int[matrix.Length];
                matrix[row] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }
        }
    }
}