using System;
using System.Linq;

namespace _03._Primary_Diagonal
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n,n];
            int sumOfMatrixPrimaryDiagonal = 0;

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

            for (int diagonal = 0; diagonal < n; diagonal++)
            {
                sumOfMatrixPrimaryDiagonal += matrix[diagonal, diagonal];
            }

            Console.WriteLine(sumOfMatrixPrimaryDiagonal);
        }
    }
}
