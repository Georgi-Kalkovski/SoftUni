using System;
using System.Linq;

namespace _04._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sides = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();


            string[,] matrix = new string[sides[0], sides[1]];

            for (int row = 0; row< sides[0]; row++)
            {
                string[] inputRow = Console.ReadLine()
                    .Split()
                    .ToArray();

                for (int col = 0; col < sides[1]; col++)
                {
                    matrix[row, col] = inputRow[col];
                }
            }

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split();
                string command = input[0];

                if (command == "END")
                {
                    break;
                }
                else if (command == "swap")
                {
                    if (input.Contains(input[1]) &&
                        input.Contains(input[2]) &&
                        input.Contains(input[3]) &&
                        input.Contains(input[4]))
                    {
                        bool isRow1True = int.TryParse(input[1], out int row1);
                        bool isCol1True = int.TryParse(input[2], out int col1);
                        bool isRow2True = int.TryParse(input[3], out int row2);
                        bool isCol2True = int.TryParse(input[4], out int col2);

                        if (!isCol1True || !isCol2True || !isRow1True || !isRow2True)
                        {
                            Console.WriteLine("Invalid input!");
                            continue;
                        }
                        if (sides[0] >= row1 || row1 < 0 &&
                            sides[0] >= row2 || row2 < 0 &&
                            sides[1] >= col1 || col1 < 0 &&
                            sides[1] >= col1 || col1 < 0)
                        {
                            string currentString = matrix[row1, col1];
                            matrix[row1, col1] = matrix[row2, col2];
                            matrix[row2, col2] = currentString;



                            for (int i = 0; i < sides[0]; i++)
                            {
                                for (int j = 0; j < sides[1]; j++)
                                {
                                    Console.Write(string.Join("", matrix[i, j] + " "));
                                }
                                Console.WriteLine();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid input!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

            }
        }
    }
}
