using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator_REAL_EXE
{
    class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var jaggedArr = new double[rows][];
            for (int row = 0; row < jaggedArr.Length; row++)
            {
                var fillUpTheArr = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
                jaggedArr[row] = fillUpTheArr;
            }

            for (int row = 0; row < jaggedArr.Length - 1; row++)
            {

                if (jaggedArr[row].Length == jaggedArr[row + 1].Length)
                {
                    for (int i = 0; i < jaggedArr[row].Length; i++)
                    {
                        jaggedArr[row][i] *= 2;
                        jaggedArr[row + 1][i] *= 2;
                    }
                }

                else
                {
                    for (int i = 0; i < jaggedArr[row].Length; i++)
                    {
                        jaggedArr[row][i] /= 2;
                    }

                    for (int j = 0; j < jaggedArr[row + 1].Length; j++)
                    {
                        jaggedArr[row + 1][j] /= 2;
                    }
                }
            }

            var command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                var commandInList = command.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string theCommand = commandInList[0];
                int row = int.Parse(commandInList[1]);
                int col = int.Parse(commandInList[2]);
                double value = double.Parse(commandInList[3]);
                if (theCommand == "Add" && row >= 0 && row < jaggedArr.Length && col >= 0 && col < jaggedArr[row].Length)
                {
                    jaggedArr[row][col] += value;
                }

                else if (theCommand == "Subtract" && row >= 0 && row < jaggedArr.Length && col >= 0 && col < jaggedArr[row].Length)
                {
                    jaggedArr[row][col] -= value;
                }
            }

            foreach (var ele in jaggedArr)
            {
                Console.WriteLine(string.Join(" ", ele));
            }
        }
    }
}