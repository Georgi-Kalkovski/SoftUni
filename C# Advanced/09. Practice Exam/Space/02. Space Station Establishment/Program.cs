using System;
using System.Linq;

namespace _02._Space_Station_Establishment
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            char[][] galaxy = new char[rows][];

            int shipRow = 0;
            int shipCol = 0;
            int starPower = 0;

            for (int row = 0; row < rows; row++)
            {
                char[] currentRow = Console.ReadLine()
                    .ToCharArray();

                galaxy[row] = currentRow;

                for (int col = 0; col < rows; col++)
                {
                    char ch = currentRow[col];

                    if (ch == 'S')
                    {
                        shipRow = row;
                        shipCol = col;
                    }
                }
            }

            while (true)
            {
                string direction = Console.ReadLine();

                string rowInput = string.Empty;
                string colInput = string.Empty;

                if (IsInside(galaxy, rowInput, colInput, starPower))
                {

                    switch (direction)
                    {

                        case "up":
                            {
                                rowInput = "shipRow - 1";
                                colInput = "shipCol";
                                Case(galaxy, rowInput, colInput, starPower);

                                break;
                            }

                        case "down":
                            {
                                rowInput = "shipRow + 1";
                                colInput = "shipCol";
                                Case(galaxy, rowInput, colInput, starPower);
                                break;
                            }

                        case "left":
                            {
                                rowInput = "shipRow";
                                colInput = "shipCol - 1";
                                Case(galaxy, rowInput, colInput, starPower);
                                break;
                            }

                        case "right":
                            {
                                rowInput = "shipRow";
                                colInput = "shipCol + 1";
                                Case(galaxy, rowInput, colInput, starPower);

                                break;
                            }
                    }
                }
                else
                {
                    break;
                }
            }
        }

        static bool IsInside(char[][] galaxy, string rowInput, string colInput, int starPower)
        {
            return int.Parse(rowInput) >= 0
                && int.Parse(rowInput) < galaxy.Length
                && int.Parse(colInput) >= 0
                && int.Parse(colInput) < galaxy[int.Parse(rowInput)].Length;
        }

        static void Case(char[][] galaxy, string rowInput, string colInput, int starPower)
        {
            galaxy[int.Parse(rowInput)][int.Parse(colInput)] = '-';
            if (galaxy[int.Parse(rowInput)][int.Parse(colInput)].ToString() == @"[0-9]")
            {
                starPower += int.Parse(galaxy[int.Parse(rowInput)][int.Parse(colInput)].ToString());
            }
        }
    }
}