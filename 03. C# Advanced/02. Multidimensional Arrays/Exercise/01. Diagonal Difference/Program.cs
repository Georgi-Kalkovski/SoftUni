using System;
using System.Linq;

namespace _01._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];
            int primarySum = 0;
            int secondarySum = 0;

            for (int row = 0; row < n; row++)
            {
                int[] rowInput = Console.ReadLine()
                        .Split()
                        .Select(int.Parse)
                        .ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = rowInput[col];
                }
            }

            for (int row = 0; row < n; row++)
            {
                    primarySum += matrix[row, row];
            }
            int secCol = n - 1;
            for (int row = 0; row < n; row++)
            {
                
                for (; secCol >= 0;)
                {
                    secondarySum += matrix[row, secCol];
                    break;
                }
                secCol--;
            }

            Console.WriteLine(Math.Abs(primarySum - secondarySum));
        }
    }
}
