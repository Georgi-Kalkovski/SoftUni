using System;
using System.Linq;

namespace _06._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            int[][] jagged = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                int[] currentRow = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                jagged[i] = currentRow;
            }
            for (int i = 0; i < rows - 1; i++)
            {
                if (jagged[i].Length == jagged[i + 1].Length)
                {
                    for (int j = 0; j < jagged[i].Length; j++)
                    {
                        jagged[i][j] *= 2;
                        jagged[i + 1][j] *= 2;
                    }
                }
            }
            for (int i = 0; i < rows - 1; i++)
            {
                if (jagged[i].Length != jagged[i + 1].Length)
                {
                    for (int j = 0; j < jagged[i].Length; j++)
                    {
                        jagged[i][j] /= 2;
                    }
                    for (int j = 0; j < jagged[i + 1].Length; j++)
                    {
                        jagged[i + 1][j] /= 2;
                    }
                }
            }

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split();
                string command = input[0];
                if (command == "End")
                {
                    break;
                }
                else if (command == "Add")
                {
                    bool isRowTrue = int.TryParse(input[1], out int row);
                    bool isColTrue = int.TryParse(input[2], out int col);
                    bool isValueTrue = int.TryParse(input[3], out int value);

                    if (isRowTrue && isColTrue && isValueTrue)
                    {
                        if (row <= rows && col <= jagged[row].Length - 1 &&
                            row > -1 && col > -1)
                        {
                            jagged[row][col] += value;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                else if (command == "Subtract")
                {
                    bool isRowTrue = int.TryParse(input[1], out int row);
                    bool isColTrue = int.TryParse(input[2], out int col);
                    bool isValueTrue = int.TryParse(input[3], out int value);
                    if (row < 0 || col < 0)
                    {
                        continue;
                    }
                    if (isRowTrue && isColTrue && isValueTrue)
                    {
                        if (row <= rows && col <= jagged[row].Length - 1)
                        {
                            jagged[row][col] -= value;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < jagged[row].Length; col++)
                {
                    Console.Write(string.Join("",jagged[row][col] + " "));
                }
                Console.WriteLine();
            }
        }
    }
}
