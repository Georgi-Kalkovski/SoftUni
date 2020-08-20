namespace PointRectangle
{
    using System;
    using System.Linq;

    public class Startup
    {
        static void Main(string[] args)
        {
            int[] coords = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Point topLeftPoint = new Point(coords[0], coords[1]);
            Point bottomRightPoint = new Point(coords[2], coords[3]);

            int numberOfInputs = int.Parse(Console.ReadLine());

            var rectangle = new Rectangle(topLeftPoint, bottomRightPoint);

            for (int i = 0; i < numberOfInputs; i++)
            {
                int[] coordsXY = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                Point point = new Point(coordsXY[0], coordsXY[1]);

                Console.WriteLine(rectangle.Contains(point));
            }
        }
    }
}
