using System;
using System.Linq;

namespace _01._Sum_Matrix_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[input[0], input[1]];
            int rows = input[0];
            int cols = input[1];
            int[] sumOfCols = new int[cols];

            for (int row = 0; row < rows; row++)
            {
                int[] data = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = data[col];
                }
            }

            for (int row = 0; row < rows; row++)
            {

                for (int col = 0; col < cols; col++)
                {
                    sumOfCols[col] += matrix[row,col];
                }
            }

            foreach (var item in sumOfCols)
            {
                Console.WriteLine(item);
            }
        }
    }
}
