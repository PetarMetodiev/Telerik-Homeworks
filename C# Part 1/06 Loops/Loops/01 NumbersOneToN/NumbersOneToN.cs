
// Write a program that prints all the numbers from 1 to N.

using System;

class NumbersOneToN
{
    static void Main()
    {
        Console.Title = "Print all the numbers between one and N";

        Console.Write("Enter number, N = ");
        string numString = Console.ReadLine();
        uint num;

        while (!(uint.TryParse(numString, out num)))
        {
            Console.Write("Enter number, N(N>0) = ");
            numString = Console.ReadLine();
        }

        for (int i = 0; i < num; i++)
        {
            Console.WriteLine(i + 1);
        }
    }
}
