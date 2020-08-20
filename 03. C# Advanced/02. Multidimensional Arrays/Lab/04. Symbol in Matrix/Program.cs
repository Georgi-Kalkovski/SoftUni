using System;
using System.Linq;

namespace _04._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            char[,] matrix = new char[n, n];

            for (int row = 0; row < n; row++)
            {
                string input = Console.ReadLine();
                char[] charArr = input.ToCharArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = charArr[col];
                }
            }

            char ch = char.Parse(Console.ReadLine());

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (matrix[row, col] == ch)
                    {
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }
                Console.WriteLine($"{ch} does not occur in the matrix");
        }
    }
}
