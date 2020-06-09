using System;
using System.Linq;

namespace _05._Snake_Moves
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sides = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rows = sides[0];
            int cols = sides[1];

            string snake = Console.ReadLine();
            int currentChar = 0;
            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < cols; col++)
                    {
                        if (currentChar == snake.Length)
                        {
                            currentChar = 0;
                        }
                        matrix[row, col] = snake[currentChar];
                        currentChar++;
                    }
                }
                if (row % 2 != 0)
                {
                    for (int col = cols - 1; col >= 0; col--)
                    {
                        if (currentChar == snake.Length)
                        {
                            currentChar = 0;
                        }
                        matrix[row, col] = snake[currentChar];
                        currentChar++;
                    }
                }

                for (int i = 0; i < cols; i++)
                {
                    Console.Write(string.Join("",matrix[row,i]));
                }
                Console.WriteLine();
            }
        }
    }
}
