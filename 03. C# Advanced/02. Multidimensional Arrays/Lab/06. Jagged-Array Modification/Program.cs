using System;
using System.Linq;

namespace _06._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n,n];
            for (int row = 0; row < n; row++)
            {
                int[] inputRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < n; col++)
                {
                    matrix[row, col] = inputRow[col];
                }
            }
            while (true)
            {
                string[] input = Console.ReadLine().Split();

                string command = input[0];

                if (command == "END")
                {
                    break;
                }

                int row = int.Parse(input[1]);
                int col = int.Parse(input[2]);
                int value = int.Parse(input[3]);

                if (command == "Add")
                {
                    if (n > row && n > col && row > -1 && col > -1)
                    {
                        matrix[row, col] += value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
                else if (command == "Subtract")
                {
                    if (n > row && n > col && row > -1 && col > -1)
                    {
                        matrix[row, col] -= value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write(string.Join(" ", matrix[row,col] + " "));
                }
                Console.WriteLine();
            }
        }
    }
}
