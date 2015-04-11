
// Write a program that reads from the console a sequence of N integer numbers and returns the minimal and maximal of them.

using System;
using System.Linq;          // Used for the max and min method

class MinAndMaxValues
{
    static void Main()
    {
        Console.Title = "Minimum and maximum of numbers";

        Console.Write("Enter how many numbers would you like to enter, N = ");
        string numString = Console.ReadLine();
        uint num;

        while (!(uint.TryParse(numString, out num)) || num == 0)
        {
            Console.Write("Enter how many numbers would you like to enter, N(N>0) = ");
            numString = Console.ReadLine();
        }

        double[] numbers = new double[num];                             // Creating an array to hold the numbers.
        string inputString;

        for (int i = 0; i < num; i++)
        {
            Console.Write("Enter number at position {0}: ", i + 1);     // The printing of the position is i + 1, because the positions in arrays start from 0.
            inputString = Console.ReadLine();

            while (!(double.TryParse(inputString, out numbers[i])))
            {
                Console.Write("Enter number at position {0}: ", i + 1);
                inputString = Console.ReadLine();
            }
        }

        double maxValue = numbers.Max();                                // Variable to hold the max value of the array. A loop could be used instead, but it is a bit more complex and time consuming to write
        double minValue = numbers.Min();                                // Variable to hold the min value of the array.

        Console.WriteLine("The maximum entered value is {0}.", maxValue);
        Console.WriteLine("The minimum entered value is {0}.", minValue);
    }

}
