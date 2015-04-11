
// Write an expression that checks if given positive integer number n (n ≤ 100) is prime. E.g. 37 is prime.

using System;

class PrimeCheck
{
    static void Main()
    {
        Console.Title = "Is the number prime?";

        Console.Write("Enter positive integer: ");
        string numString = Console.ReadLine();
        uint num;

        while (((uint.TryParse(numString, out num)) == false) || num <= 0 || num > 100)
        {
            Console.Write("Enter positive integer (between 1 and 100): ");
            numString = Console.ReadLine();
        }

        uint divider = 2;
        uint limit = (uint)Math.Sqrt(num);
        bool prime = true;

        while (prime && divider <= limit)
        {
            if (num % divider == 0)
            {
                prime = false;
            }
            divider++;
        }

        if (prime)
        {
            Console.WriteLine("The number is prime");
        }
        else
        {
            Console.WriteLine("The number is not prime");
        }
    }
}
