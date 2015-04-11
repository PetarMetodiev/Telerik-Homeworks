
// Write a program that finds the biggest of three integers using nested if statements.

using System;

class FindGreatest
{
    static void Main()
    {
        Console.Title = "Which one is greatest?";

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

        if (a > b)
        {

            if (a > c)                                                  // a > b, a > c
            {
                Console.WriteLine("The number {0} is greatest.", a);
            }

            if (c > a)                                                  // c> a > b, 
            {
                Console.WriteLine("The number {0} is greatest.", c);
            }

        }

        if (b > a)
        {

            if (b > c)                                                  // b > a, b > c
            {
                Console.WriteLine("The number {0} is greatest.", b);
            }

            if (c > b)                                                  // c > b > a
            {
                Console.WriteLine("The number {0} is greatest.", c);
            }

        }

        if (c == a)
        {

            if (c > b)                                                  // c = a, c > b
            {
                Console.WriteLine("The number {0} is greatest.", c);
            }

            if (b > c)                                                  // c = a, b > c
            {
                Console.WriteLine("The number {0} is greatest.", b);
            }

        }

        if (c == b)
        {

            if (a > b)                                                  // c = b, a > b
            {
                Console.WriteLine("The number {0} is greatest.", a);
            }

            if (b > a)                                                  // c = b, b > a
            {
                Console.WriteLine("The number {0} is greatest.", b);
            }
        }

        if (a == b)
        {

            if (a > c)                                                  // a = b, a > c
            {
                Console.WriteLine("The number {0} is greatest.", a);
            }

            if (c > a)                                                  // a = b, c > a
            {
                Console.WriteLine("The number {0} is greatest.", c);
            }
        }

        if (a == b && b == c)                                           // a = b = c
        {
            Console.WriteLine("The numbers are equal.");
        }
    }
}
