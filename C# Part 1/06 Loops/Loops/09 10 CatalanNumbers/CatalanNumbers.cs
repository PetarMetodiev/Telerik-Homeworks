
// Write a program to calculate the Nth Catalan number by given N.

using System;
using System.Numerics;

class CatalanNumbers
{
    static BigInteger Factorial(uint num)                        // Creating a method to calculate the factorial, since it is used in 3 places
    {                                                            // Using BigInteger, since using decimal allows for n to be max = 14. After that there is an exception
        BigInteger numFact = 1;
        for (int i = 1; i <= num; i++)
		    {
			    numFact *= i;
		    }
        return numFact;
    }

    static void Main()
    {
        Console.Title = "Catalan number";

        Console.Write("Enter n = ");
        string nString = Console.ReadLine();
        uint n;                                                     // n has to greater and equal to zero(according to the definition)

        while (!(uint.TryParse(nString, out n)))
        {
            Console.Write("Enter n(n >= 0) = ");
            nString = Console.ReadLine();
        }

        BigInteger result = Factorial(2 * n) / (Factorial(n + 1) * Factorial(n));

        Console.WriteLine("The required Catalan number for n = {0} is {1}.", n, result);
    }
}
