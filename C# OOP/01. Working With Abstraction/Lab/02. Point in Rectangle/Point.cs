namespace PointRectangle
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Point
    {
        public Point(int coordinatesX, int coordinatesY)
        {
            CoordinatesX = coordinatesX;
            CoordinatesY = coordinatesY;
        }

        public int CoordinatesX { get; set; }
        public int CoordinatesY { get; set; }
    }
}
