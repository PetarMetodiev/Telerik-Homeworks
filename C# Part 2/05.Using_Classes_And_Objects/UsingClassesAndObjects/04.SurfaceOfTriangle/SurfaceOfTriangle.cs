
// Write methods that calculate the surface of a triangle by given:
// Side and an altitude to it; Three sides; Two sides and an angle between them. Use System.Math.

using System;

class SurfaceOfTriangle
{
    /// <summary>
    /// Calculates the area of a triangle by given side and height to it
    /// </summary>
    static void SideAndAltitude()
    {
        Console.WriteLine("Claculate area of a triangle by given side and height to it.");

        Console.Write("Enter side a = ");
        double sideA = CheckSide(Console.ReadLine());

        Console.Write("Enter height of h = ");
        double height = CheckSide(Console.ReadLine());

        double surface = Math.Round((sideA * height / 2), 2);

        Console.WriteLine();
        Console.WriteLine("The area of the triangle with side a = {0} and height to it h = {1} is {2}", sideA, height, surface);
        Console.WriteLine(new string('-', 20));
    }

    /// <summary>
    /// Calculates the area of a triangle by given three sides. Using Heron's formula - http://www.mathsisfun.com/geometry/herons-formula.html
    /// </summary>
    static void ThreeSides()
    {
        Console.WriteLine("Claculate area of a triangle by given three sides.");

        Console.Write("Enter side a = ");
        double sideA = CheckSide(Console.ReadLine());

        Console.Write("Enter side b = ");
        double sideB = CheckSide(Console.ReadLine());

        Console.Write("Enter side c = ");
        double sideC = CheckSide(Console.ReadLine());

        double halfPerimeter = (sideA + sideB + sideC) / 2;
        double area = Math.Sqrt(halfPerimeter * (halfPerimeter - sideA) * (halfPerimeter - sideB) * (halfPerimeter - sideC));
        area = Math.Round(area, 2);

        Console.WriteLine("The area of a triangle with sides a = {0}, b = {1}, c = {2} is {3}", sideA, sideB, sideC, area);
        Console.WriteLine(new string('-', 20));
    }

    /// <summary>
    /// Calculates the area of a triangle by given two sides and an angle between them - http://www.mathsisfun.com/algebra/trig-solving-sas-triangles.html
    /// </summary>
    static void TwoSidesAndAngle()
    {
        Console.WriteLine("Claculate area of a triangle by given two sides and angle between them.");

        Console.Write("Enter side a = ");
        double sideA = CheckSide(Console.ReadLine());

        Console.Write("Enter side b = ");
        double sideB = CheckSide(Console.ReadLine());

        Console.Write("Enter angle between side a and b, fi = ");
        double angle = CheckSide(Console.ReadLine());

        // Converting form degrees to radians. Math.Sin works with radians.
        angle = Math.PI / 180 * angle; 

        double area = (sideA * sideB * Math.Sin(angle)) / 2;
        area = Math.Round(area, 2);

        Console.WriteLine("The area of a triangle with sides a = {0} and b = {1}, and angle between them fi = {2} is {3}", sideA, sideB, angle, area);
    }

    /// <summary>
    /// Checks if given string is valid positive number is valid
    /// </summary>
    /// <param name="sideString">String to be evaluated</param>
    /// <returns>Valid positive number</returns>
    static double CheckSide(string sideString)
    {
        double side;

        while (!double.TryParse(sideString, out side) || side < 1)
        {
            Console.Write("Enter valid positive number: ");
            sideString = Console.ReadLine();
        }

        return side;
    }

    static void Main()
    {
        Console.Title = "Calculate the surface of a triangle";

        SideAndAltitude();
        ThreeSides();
        TwoSidesAndAngle();
    }
}