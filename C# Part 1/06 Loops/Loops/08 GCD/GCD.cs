
// Write a program that calculates the greatest common divisor (GCD) of given two numbers. Use the Euclidean algorithm (find it in Internet).

using System;

class GCD
{
    static void Main()
    {
        Console.Title = "Greatest common divisor";

        Console.Write("Enter first number, a = ");
        string aString = Console.ReadLine();
        int a;

        while (!(int.TryParse(aString, out a)))
        {
            Console.Write("Enter valid first number, a = ");
            aString = Console.ReadLine();
        }

        Console.Write("Enter second number, b = ");
        string bString = Console.ReadLine();
        int b;

        while (!(int.TryParse(bString, out b)))
        {
            Console.Write("Enter valid second number, b = ");
            bString = Console.ReadLine();
        }

        int r = a % b;                                                  // Used to hold the result for the remainder

        while (true)                                                    // Infinite loop to cycle through the algorithm
        {
            r = a % b;                                                  // I tried using while(r != 0), but the problem was that whenever r == 0, it continoues and b becomes 0, hence there is an exception
            if (r == 0)
            {
                break;
            }
            a = b;
            b = r;
        }

        Console.WriteLine("The GCD is {0}", b);
    }
}
