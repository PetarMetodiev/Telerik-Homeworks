
// * Write a program that reads a positive integer number N (N < 20) from console and outputs in the console
// the numbers 1 ... N numbers arranged as a spiral.

using System;

class Spiral
{
    static void Main()
    {
        Console.Title = "Spiral";

        Console.Write("Enter N = ");
        string nString = Console.ReadLine();
        uint n;

        while (!(uint.TryParse(nString, out n)) || n == 0)
        {
            Console.Write("Enter N(N > 0) = ");
            nString = Console.ReadLine();
        }


    }
}
