namespace _01._Rhombus_of_Stars
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            int positiveRows = int.Parse(Console.ReadLine());
            PrintRow(positiveRows);
        }

        static void PrintRow(int positiveRows)
        {
            PrintPositiveRows(positiveRows);
            PrintNegativeRows(positiveRows);
        }
        static void PrintPositiveRows(int positiveRows)
        {
            int currentMid = positiveRows;

            for (int row = 0; row < positiveRows; row++)
            {
                Console.Write(string.Empty.PadLeft(currentMid));

                for (int col = row; col >= 0; col--)
                {
                    Console.Write("* ");
                }

                currentMid--;

                Console.WriteLine();
            }
        }
        static void PrintNegativeRows(int positiveRows)
        {
            int currentMid = 2;

            for (int row = positiveRows-1; row >= 0; row--)
            {
                Console.Write(string.Empty.PadLeft(currentMid));

                for (int col = 0; col < row; col++)
                {
                    Console.Write("* ");
                }

                if (currentMid < positiveRows)
                {
                    currentMid++;
                }

                Console.WriteLine();
            }
        }
    }
}
