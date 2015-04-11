
// Write a program that reads the coefficients a, b and c of a quadratic equation ax2+bx+c=0 and solves it (prints its real roots).

using System;

class QuadraticEquation
{
    static void Main()
    {
        Console.Title = "Quadratic equation";

        Console.Write("Enter a = ");
        string aString = Console.ReadLine();
        double a;

        while (!(double.TryParse(aString, out a)) || a == 0)        // Check if a = 0. If a = 0, then the equation is not quadratic
        {
            Console.Write("Enter a(number) = ");
            aString = Console.ReadLine();
        }

        Console.Write("Enter b = ");
        string bString = Console.ReadLine();
        double b;

        while (!(double.TryParse(bString, out b)))
        {
            Console.Write("Enter b(number) = ");
            bString = Console.ReadLine();
        }

        Console.Write("Enter c = ");
        string cString = Console.ReadLine();
        double c;

        while (!(double.TryParse(cString, out c)))
        {
            Console.Write("Enter c(number) = ");
            cString = Console.ReadLine();
        }

        double d = b * b - 4 * a * c;       // Discriminant
        double result1, result2;
        result1 = (-b-Math.Sqrt(d))/(2*a);
        result2 = (-b+Math.Sqrt(d))/(2*a);

        if (d < 0)
        {
            Console.WriteLine("There are no real roots");
        }
        else
        {
            Console.WriteLine("The real roots of the equation are {0} and {1}", Math.Round(result1, 2), Math.Round(result2, 2));
        }
    }
}
