
// Write a program that gets two numbers from the console and prints the greater of them. Don’t use if statements.

using System;

class FindGreater
{
    static void Main()
    {
        Console.Title = "Which number is greater?";

        Console.Write("Enter first number: ");
        string aString = Console.ReadLine();
        int a;

        while (!(int.TryParse(aString, out a)))
        {
            Console.Write("Enter valid integer: ");
            aString = Console.ReadLine();
        }

        Console.Write("Enter second number: ");
        string bString = Console.ReadLine();
        int b;

        while (!(int.TryParse(bString, out b)))
        {
            Console.Write("Enter valid integer: ");
            bString = Console.ReadLine();
        }
        Console.WriteLine("Greater: {0}", (a + b + Math.Abs(a - b)) / 2);

        Console.WriteLine("Smaller: {0}", (a + b - Math.Abs(a - b)) / 2);
    }
}