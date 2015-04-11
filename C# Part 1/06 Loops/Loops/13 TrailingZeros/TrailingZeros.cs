
// * Write a program that calculates for given N how many trailing zeros present at the end of the number N!. 

using System;
using System.Numerics;

class TrailingZeros
{
    static BigInteger Factorial(uint num)                        // Creating a method to calculate the factorial.
    {
        BigInteger numFact = 1;
        for (int i = 1; i <= num; i++)
        {
            numFact *= i;
        }
        return numFact;
    }

    static void Main()
    {
        Console.Title = "How many trailing zeros in the factorial?";

        Console.Write("Enter N = ");
        string nString = Console.ReadLine();
        uint n;

        while (!(uint.TryParse(nString, out n)))
        {
            Console.Write("Enter N(N >= 0) = ");
            nString = Console.ReadLine();
        }

        Console.WriteLine("{0}! = {1}", n, Factorial(n));

        uint zeroes = 0;

        while (n >= 1)                                          // Best explanation for this is given here: http://www.purplemath.com/modules/factzero.htm
        {
            n = n / 5;
            zeroes += n;
        }

        Console.WriteLine("Trailing zeroes: {0}", zeroes);
    }
}
