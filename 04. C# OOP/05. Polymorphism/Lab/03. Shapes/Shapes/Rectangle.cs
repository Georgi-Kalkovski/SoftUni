namespace Shapes
{
    public class Rectangle : Shape
    {
        public Rectangle(double height, double width)
        {
            Height = height;
            Width = width;
        }

        public double Height { get; private set; }
        public double Width { get; private set; }

        public override double CalculatePerimeter()
        {
            return 2 * Height + 2* Width;
        }
        public override double CalculateArea()
        {
            return Height * Width;
        }
        public override string Draw()
        {
            return base.Draw() + GetType().Name;
        }
    }
}
