
// Write a program that shows the sign (+ or -) of the product of three real numbers without calculating it. 
// Use a sequence of if statements.

using System;

class SignCheck
{
    static void Main()
    {
        Console.Title = "Check the sign of the product";

        Console.Write("Enter first number: ");
        string aString = Console.ReadLine();
        double a;

        while (!(double.TryParse(aString, out a)))
        {
            Console.Write("Enter first number: ");
            aString = Console.ReadLine();
        }

        Console.Write("Enter second number: ");
        string bString = Console.ReadLine();
        double b;

        while (!(double.TryParse(bString, out b)))
        {
            Console.Write("Enter second number: ");
            bString = Console.ReadLine();
        }

        Console.Write("Enter third number: ");
        string cString = Console.ReadLine();
        double c;

        while (!(double.TryParse(cString, out c)))
        {
            Console.Write("Enter third number: ");
            cString = Console.ReadLine();
        }

        // Only the signs of the numbers are needed to be checked in oder to obtain the sign of the final result

        if ((a < 0 && b > 0 && c > 0) || (a > 0 && b < 0 && c > 0) || (a > 0 && b > 0 && c < 0) || (a < 0 && b < 0 && c < 0))
        {
            Console.WriteLine("The product will have a negative sign (-)");
        }

        if ((a < 0 && b < 0 && c > 0) || (a < 0 && b > 0 && c < 0) || (a > 0 && b < 0 && c < 0)|| (a > 0 && b > 0 && c > 0))
        {
            Console.WriteLine("The product will have a positive sign (+)");
        }

        if (a == 0 || b == 0 || c == 0)     // If some of the numbers is 0, then the final product will be 0
        {
            Console.WriteLine("The product will be equal to 0");
        }


    }
}
