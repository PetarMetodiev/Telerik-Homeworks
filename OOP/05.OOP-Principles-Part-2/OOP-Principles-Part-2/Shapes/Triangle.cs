namespace Shapes
{
    public class Triangle : Shape
    {
        public Triangle(double inputHeight, double inputBase)
            : base(inputHeight, inputBase)
        {
        }

        public override double CalculateSurface()
        {
            double area = this.Height * this.Width / 2;
            return area;
        }
    }
}
