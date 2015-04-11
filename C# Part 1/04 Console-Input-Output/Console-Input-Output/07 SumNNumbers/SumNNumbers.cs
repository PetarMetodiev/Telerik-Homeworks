
// Write a program that reads the coefficients a, b and c of a quadratic equation ax2+bx+c=0 and solves it (prints its real roots).

using System;

class SumNNumbers
{
    static void Main()
    {
        Console.Title = "Summation of n numbers";

        Console.Write("Enter ammount of numbers you wish to sum: ");
        string nString = Console.ReadLine();
        double n;

        while (!(double.TryParse(nString, out n)) || n <= 0)
        {
            Console.Write("Enter ammount of numbers you wish to sum: ");
            nString = Console.ReadLine();
        }

        double sum = 0;
        string inputString;
        double input;

        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter value to be added: ");
            inputString = Console.ReadLine();

            while (!(double.TryParse(inputString, out input)))
            {
                Console.Write("Enter ammount of numbers you wish to add");
                inputString = Console.ReadLine();
            }

            sum = sum + input;
        }

        Console.WriteLine("Total sum is {0}", sum);
    }
}