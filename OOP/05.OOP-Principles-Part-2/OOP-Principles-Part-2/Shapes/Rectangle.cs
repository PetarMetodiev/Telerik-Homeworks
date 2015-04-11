namespace Shapes
{
    public class Rectangle : Shape
    {
        public Rectangle(double inputHeight, double inputWidth)
            :base (inputHeight, inputWidth)
        {
        }

        public override double CalculateSurface()
        {
            double area = this.Height * this.Width;
            return area;
        }
    }
}
