using System;

namespace _02._Center_Point
{
    class Program
    {
        static void FindClosestXYToTheCenter(double x1, double x2, double y1, double y2)
        {
            double firstXY = Math.Sqrt(Math.Pow(y1, 2) + Math.Pow(x1, 2));
            double secondXY = Math.Sqrt(Math.Pow(y2, 2) + Math.Pow(x2, 2));

            if (firstXY < secondXY)
            {
                Console.WriteLine($"({x1}, {y1})");
            }
            else
            {
                Console.WriteLine($"({x2}, {y2})");
            }
        }

        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            FindClosestXYToTheCenter(x1, x2, y1, y2);
        }
    }
}
