
// Sort 3 real values in descending order using nested if statements.

using System;

class SortValues
{
    static void Main()
    {
        Console.Title = "Sort three values";

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
            if (b > c)              // a > b > c
            {
                Console.WriteLine("The numbers in descending order: {0}, {1}, {2}", a, b, c);
            }

            if (c > b && a > c)     // a > c > b
            {
                Console.WriteLine("The numbers in descending order: {0}, {1}, {2}", a, c, b);
            }

            if (b == c)             // a > b = c
            {
                Console.WriteLine("The numbers in descending order: {0}, {1}, {2}", a, b, c);
            }

            if (a == c)             // a = c > b
            {
                Console.WriteLine("The numbers in descending order: {0}, {1}, {2}", a, c, b);
            }
        }

        if (b > a)
        {
            if (a > c)              // b > a > c
            {
                Console.WriteLine("The numbers in descending order: {0}, {1}, {2}",b, a, c);
            }

            if (c > a && b > c)     // b > c > a
            {
                Console.WriteLine("The numbers in descending order: {0}, {1}, {2}", b, c, a);
            }

            if (c == a)             // b > c = a
            {
                Console.WriteLine("The numbers in descending order: {0}, {1}, {2}", b, a, c);
            }

            if (b == c)             // b = c > a
            {
                Console.WriteLine("The numbers in descending order: {0}, {1}, {2}", b, c, a);
            }
        }

        if (c > a)
        {
            if (a > b)              // c > a > b
            {
                Console.WriteLine("The numbers in descending order: {0}, {1}, {2}",c, a, b);
            }

            if (b > a && c > b)     // c > b > a
            {
                Console.WriteLine("The numbers in descending order: {0}, {1}, {2}",c, b, a);
            }

            if (a == b)             // c > a = b
            {
                Console.WriteLine("The numbers in descending order: {0}, {1}, {2}", c, a, b);
            }
        }

        if (a == b && b > c)        // a = b > c
        {
            Console.WriteLine("The numbers in descending order: {0}, {1}, {2}", a, b, c);
        }

        if (a == b && b == c)       // a = b = c
        {
            Console.WriteLine("The numbers are equal.");
        }
    }
}