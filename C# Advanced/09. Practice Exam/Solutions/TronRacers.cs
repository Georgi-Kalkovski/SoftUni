using System;

namespace SpaceStationRecruitment
{
    public class TronRacers
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int firstPlayerRow = 0;
            int firstPlayerCol = 0;
            int secondPlayerRow = 0;
            int secondPlayerCol = 0;

            char[][] field = new char[size][];

            for (int r = 0; r < size; r++)
            {
                field[r] = new char[size];

                string col = Console.ReadLine();

                for (int c = 0; c < size; c++)
                {
                    char ch = col[c];

                    if (ch == 'f')
                    {
                        firstPlayerRow = r;
                        firstPlayerCol = c;
                    }
                    else if (ch == 's')
                    {
                        secondPlayerRow = r;
                        secondPlayerCol = c;
                    }

                    field[r][c] = ch;
                }
            }

            while (true)
            {
                string[] directions = Console.ReadLine().Split();

                string firstPlayerCommand = directions[0];
                string secondPlayerCommand = directions[1];

                switch (firstPlayerCommand)
                {
                    case "left":
                        if (firstPlayerCol - 1 < 0)
                        {
                            firstPlayerCol = size - 1;
                        }
                        else
                        {
                            firstPlayerCol -= 1;
                        }
                        break;
                    case "right":
                        if (firstPlayerCol + 1 >= size)
                        {
                            firstPlayerCol = 0;
                        }
                        else
                        {
                            firstPlayerCol += 1;
                        }
                        break;
                    case "up":
                        if (firstPlayerRow - 1 < 0)
                        {
                            firstPlayerRow = size - 1;
                        }
                        else
                        {
                            firstPlayerRow -= 1;
                        }
                        break;
                    case "down":
                        if (firstPlayerRow + 1 >= size)
                        {
                            firstPlayerRow = 0;
                        }
                        else
                        {
                            firstPlayerRow += 1;
                        }
                        break;
                }

                if (field[firstPlayerRow][firstPlayerCol] == 's')
                {
                    field[firstPlayerRow][firstPlayerCol] = 'x';
                    break;
                }

                field[firstPlayerRow][firstPlayerCol] = 'f';

                switch (secondPlayerCommand)
                {
                    case "left":
                        if (secondPlayerCol - 1 < 0)
                        {
                            secondPlayerCol = size - 1;
                        }
                        else
                        {
                            secondPlayerCol -= 1;
                        }
                        break;
                    case "right":
                        if (secondPlayerCol + 1 >= size)
                        {
                            secondPlayerCol = 0;
                        }
                        else
                        {
                            secondPlayerCol += 1;
                        }
                        break;
                    case "up":
                        if (secondPlayerRow - 1 < 0)
                        {
                            secondPlayerRow = size - 1;
                        }
                        else
                        {
                            secondPlayerRow -= 1;
                        }
                        break;
                    case "down":
                        if (secondPlayerRow + 1 >= size)
                        {
                            secondPlayerRow = 0;
                        }
                        else
                        {
                            secondPlayerRow += 1;
                        }
                        break;
                }

                if (field[secondPlayerRow][secondPlayerCol] == 'f')
                {
                    field[secondPlayerRow][secondPlayerCol] = 'x';
                    break;
                }

                field[secondPlayerRow][secondPlayerCol] = 's';
            }

            foreach (char[] col in field)
            {
                Console.WriteLine(string.Join("", col));
            }
        }
    }
}