using System;

namespace Gift_Box_Coverage
{
    class Program
    {
        static void Main(string[] args)
        {
            double sizeOfASide = double.Parse(Console.ReadLine());
            double numberOfSheetsOfPaper = int.Parse(Console.ReadLine());
            double areaOfSingleSheetCover = double.Parse(Console.ReadLine());
            double sheetAreaCover = 0;

            double totalArea = sizeOfASide * sizeOfASide * 6;

            for (int i = 1; i <= numberOfSheetsOfPaper; i++)
            {
                if (i % 3 == 0)
                {
                    sheetAreaCover += areaOfSingleSheetCover/4;
                }
				
                else
                {
                    sheetAreaCover += areaOfSingleSheetCover;
                }
            }

            double percentage = sheetAreaCover / totalArea * 100;
            Console.WriteLine($"You can cover {percentage:F2}% of the box.");
        }
    }
}
