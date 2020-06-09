using System;

namespace BookWorm
{
    public class BookWorm
    {
        static void Main(string[] args)
        {
            string word = Console.ReadLine();

            int size = int.Parse(Console.ReadLine());

            int PlayerRow = 0;
            int playerCol = 0;

            char[][] field = new char[size][];

            for (int r = 0; r < size; r++)
            {
                field[r] = new char[size];

                string col = Console.ReadLine();

                for (int c = 0; c < size; c++)
                {
                    char ch = col[c];

                    if (ch == 'P')
                    {
                        PlayerRow = r;
                        playerCol = c;
                    }

                    field[r][c] = ch;
                }
            }

            while (true)
            {

                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                if (IsOutside(size, PlayerRow, playerCol))
                {
                    continue;
                }
                field[PlayerRow][playerCol] = '-';

                // right -> row stays the same, col + 1
                // left -> row stays the same, col - 1
                // up -> row - 1, col -> same
                // down -> row + 1, col -> same

                switch (command)
                {
                    case "right":
                        playerCol += 1;
                        break;
                    case "left":
                        playerCol -= 1;
                        break;
                    case "up":
                        PlayerRow -= 1;
                        break;
                    case "down":
                        PlayerRow += 1;
                        break;
                }

                if (IsOutside(size, PlayerRow, playerCol))
                {
                    word = word.Remove(word.Length - 1);
                    continue;
                }
                if (char.IsLetter(field[PlayerRow][playerCol]))
                {
                    word += field[PlayerRow][playerCol];
                }
            }
            Console.WriteLine(word);

            if (!IsOutside(size, PlayerRow, playerCol))
            {

                field[PlayerRow][playerCol] = 'P';
            }

            foreach (char[] col in field)
            {
                Console.WriteLine(string.Join("", col));
            }
        }

        private static bool IsOutside(int size, int stephenRow, int stephenCol)
        {
            return stephenRow >= size ||
                   stephenRow < 0 ||
                   stephenCol >= size ||
                   stephenCol < 0;
        }
    }
}