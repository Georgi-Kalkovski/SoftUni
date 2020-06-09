using System;
using System.Linq;

namespace The_Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            string[][] garden = new string[rows][];

            for (int i = 0; i < rows; i++)
            {
                string[] row = Console.ReadLine()
                    .Split()
                    .ToArray();

                garden[i] = row;
            }

            string input;
            int carrotsCounter = 0;
            int potatoesCounter = 0;
            int lettuceCounter = 0;
            int harmedVegetables = 0;

            while ((input = Console.ReadLine()) != "End of Harvest")
            {
                string[] inputArg = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = inputArg[0].ToLower().ToString();
                int row = int.Parse(inputArg[1]);
                int col = int.Parse(inputArg[2]);

                if (command == "harvest")
                {
                    if (garden.Length > row)
                    {
                        if (garden[row].Length > col)
                        {
                            if (garden[row][col] == "C")
                            {
                                carrotsCounter++;
                                garden[row][col] = " ";
                            }

                            else if (garden[row][col] == "P")
                            {
                                potatoesCounter++;
                                garden[row][col] = " ";
                            }

                            else if (garden[row][col] == "L")
                            {
                                lettuceCounter++;
                                garden[row][col] = " ";
                            }
                        }
                        else continue;
                    }
                    else continue;
                }

                else if (command == "mole" && IsInside(garden, row, col))
                {
                    string direction = inputArg[3].ToLower().ToString();
                    if (garden.Length > row)
                    {
                        if (garden[row].Length > col)
                        {
                            if (direction == "up")
                            {
                                for (int i = row; i >= 0; i -= 2)
                                {
                                    if (garden[i][col] != " ")
                                    {
                                        harmedVegetables++;
                                        garden[i][col] = " ";
                                    }
                                }
                                continue;
                            }
                            else if (direction == "down")
                            {
                                for (int i = row; i < garden.Length; i += 2)
                                {
                                    if (garden[i][col] != " ")
                                    {
                                        harmedVegetables++;
                                        garden[i][col] = " ";
                                    }
                                }
                                continue;
                            }
                            else if (direction == "left")
                            {
                                for (int i = col; i >= 0; i -= 2)
                                {
                                    if (garden[row][i] != " ")
                                    {
                                        harmedVegetables++;
                                        garden[row][i] = " ";
                                    }
                                }
                                continue;
                            }
                            else if (direction == "right")
                            {
                                for (int i = col; i < garden[row].Length; i += 2)
                                {
                                    if (garden[row][i] != " ")
                                    {
                                        harmedVegetables++;
                                        garden[row][i] = " ";
                                    }
                                }
                                continue;
                            }
                            continue;
                        }
                    }

                    input = Console.ReadLine();
                }
            }

            foreach (var row in garden)
            {
                Console.WriteLine(string.Join(" ", row));
            }
            Console.WriteLine($"Carrots: {carrotsCounter}");
            Console.WriteLine($"Potatoes: {potatoesCounter}");
            Console.WriteLine($"Lettuce: {lettuceCounter}");
            Console.WriteLine($"Harmed vegetables: {harmedVegetables}");
        }
        private static bool IsInside(string[][] garden, int row, int col)
        {
            return row >= 0 && row < garden.Length && col >= 0 && col < garden[row].Length;
        }
    }
}
