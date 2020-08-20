namespace PointRectangle
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Rectangle
    {
        public Rectangle(Point topLeftPoint, Point bottomRightPoint)
        {
            TopLeftPoint = topLeftPoint;
            BottomRightPoint = bottomRightPoint;
        }

        public Point TopLeftPoint { get; set; }
        public Point BottomRightPoint { get; set; }

        public bool Contains(Point point)
        {
            if (BottomRightPoint.CoordinatesX >= point.CoordinatesX &&
                BottomRightPoint.CoordinatesY >= point.CoordinatesY &&
                TopLeftPoint.CoordinatesX <= point.CoordinatesX &&
                TopLeftPoint.CoordinatesY <= point.CoordinatesY)
            {
                return true;
            }
            return false;
        }
    }
}
