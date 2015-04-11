namespace Shapes
{
    using System;

    class Start
    {
        static void Main()
        {
            Shape square = new Square(5);
            Console.WriteLine("Square surface: " + square.CalculateSurface());

            Shape triangle = new Triangle(5, 6);
            Console.WriteLine("Triangle surface: " + triangle.CalculateSurface());

            Shape rectangle = new Rectangle(5.2, 6.8);
            Console.WriteLine("Rectangle surface: " + rectangle.CalculateSurface());
        }
    }
}
