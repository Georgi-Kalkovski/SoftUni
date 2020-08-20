using System;
using System.Linq;

namespace _05._Square_With_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] inputOfMatrix = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
            int rows = inputOfMatrix[0];
            int cols = inputOfMatrix[1];

            int[,] matrix = new int[rows, cols];
            int maxSum = int.MinValue;
            int[,] maxMatrix = new int[2, 2];

            for (int row = 0; row < rows; row++)
            {
                int[] rowInput = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = rowInput[col];
                }
            }
            for (int row = 0; row < rows - 1; row++)
            {
                for (int col = 0; col < cols - 1; col++)
                {
                    int currentSum = 0;
                    currentSum += matrix[row, col];
                    currentSum += matrix[row + 1, col];
                    currentSum += matrix[row, col + 1];
                    currentSum += matrix[row + 1, col + 1];
                    if (maxSum < currentSum)
                    {

                        maxMatrix[0, 0] = matrix[row, col];
                        maxMatrix[0, 1] = matrix[row, col + 1];
                        maxMatrix[1, 0] = matrix[row + 1, col];
                        maxMatrix[1, 1] = matrix[row + 1, col + 1];
                        maxSum = currentSum;
                    }
                }
            }

            Console.WriteLine($"{maxMatrix[0,0]} {maxMatrix[0,1]}");
            Console.WriteLine($"{maxMatrix[1,0]} {maxMatrix[1,1]}");
            Console.WriteLine(maxSum);
        }
    }
}
