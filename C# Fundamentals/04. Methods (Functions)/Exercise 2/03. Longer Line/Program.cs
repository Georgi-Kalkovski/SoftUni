using System;

namespace _03._Longer_Line
{
    class Program
    {

        private static double CalculateDistance(double x1, double y1, double x2 = 0d, double y2 = 0d)
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2d) + Math.Pow((y2 - y1), 2d));
        }

        static void Main(string[] args)
        {
            double x1 = double.Parse(Console.ReadLine());
            double y1 = double.Parse(Console.ReadLine());
            double x2 = double.Parse(Console.ReadLine());
            double y2 = double.Parse(Console.ReadLine());

            double x3 = double.Parse(Console.ReadLine());
            double y3 = double.Parse(Console.ReadLine());
            double x4 = double.Parse(Console.ReadLine());
            double y4 = double.Parse(Console.ReadLine());

            double lineOneLen = CalculateDistance(x1, y1, x2, y2);
            double lineTwoLen = CalculateDistance(x3, y3, x4, y4);

            if (lineOneLen >= lineTwoLen)
            {
                if (CalculateDistance(x1, y1) <= CalculateDistance(x2, y2))
                {
                    Console.WriteLine($"({x1}, {y1})({x2}, {y2})");
                }
				
                else
                {
                    Console.WriteLine($"({x2}, {y2})({x1}, {y1})");
                }
            }
			
            else
            {
                if (CalculateDistance(x3, y3) <= CalculateDistance(x4, y4))
                {
                    Console.WriteLine($"({x3}, {y3})({x4}, {y4})");
                }
				
                else
                {
                    Console.WriteLine($"({x4}, {y4})({x3}, {y3})");
                }
            }
        }
    }
}
