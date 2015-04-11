
// Write an expression that calculates trapezoid's area by given sides a and b and height h.

using System;

class TrapezoidArea
{
    static void Main()
    {
        Console.Title = "Calculate the area of a trapezoid";

        float a, b, h;
        Console.Write("Enter a: ");
        string aString = Console.ReadLine();

        while (((float.TryParse(aString, out a)) == false) || a <= 0)
        {
            Console.Write("Enter valid value for a: ");
            aString = Console.ReadLine();
        }

        Console.Write("Enter b: ");
        string bString = Console.ReadLine();

        while (((float.TryParse(bString, out b)) == false) || b <= 0)
        {
            Console.Write("Enter valid value for b: ");
            bString = Console.ReadLine();
        }

        Console.Write("Enter h: ");
        string hString = Console.ReadLine();

        while (((float.TryParse(hString, out h)) == false) || h <= 0)
        {
            Console.Write("Enter valid value for h: ");
            hString = Console.ReadLine();
        }

        float area = ((a + b) / 2) * h;
        Console.WriteLine("The area of the trapezoid is {0}", area);
    }
}
