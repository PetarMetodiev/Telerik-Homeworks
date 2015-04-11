
// Write a program that finds the greatest of given 5 variables.

using System;
using System.Linq;          // Used for the Max method for the array

class GreatestOfFive
{
    static void Main()
    {
        Console.Title = "Greatest of five";

        Console.Write("Enter amount of numbers:");
        string countString = Console.ReadLine();
        uint count;

        while (!(uint.TryParse(countString, out count)))
        {
            Console.Write("Enter amount of numbers:");
            countString = Console.ReadLine();
        }

        double[] numbers = new double[count];           // Declaring an array which will contain the entered numbers
        string[] stringNumbers = new string[count];

        for (int i = 0; i < count; i++)                 // Loop for entering the numbers
        {
            Console.Write("Enter number at position {0}: ", i+1);
            stringNumbers[i] = Console.ReadLine();
            while (!(double.TryParse(stringNumbers[i], out numbers[i])))        // Check if the entered number is a valid one
            {
                Console.Write("Enter number at position {0}: ", i + 1);
                stringNumbers[i] = Console.ReadLine();
            }
        }

        double maxValue = numbers.Max();            // Variable, holding the maximum value of the array

        Console.WriteLine("The maximum entered value is {0}", maxValue);
    }
}
