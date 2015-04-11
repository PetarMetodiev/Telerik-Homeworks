
//Write a program that, for a given two integer numbers N and X, calculates the sumS = 1 + 1!/X + 2!/X2 + … + N!/XN

using System;
using System.Numerics;

class NandXequation
{
    static decimal Factorial(decimal num)               // Method for calculation of the factorial. The type is not BigInteger, because then it calculates with integers only and the final result is not correct.
    {
        decimal numFact = 1;
        for (int i = 1; i <= num; i++)
			{
			    numFact *= i;
			}
        return numFact;
    }

    static decimal powerX(decimal x, decimal power)     // Method for the calculation of x^n
    {
        decimal result = 1;
        for (int i = 0; i < power; i++)
        {
            result *= x;
        }
        return result;
    }

    static void Main()
    {
        Console.Title = "Calculate a strange sum";

        Console.Write("Enter N = ");
        string nString = Console.ReadLine();
        uint n;

        while (!(uint.TryParse(nString, out n)) || n == 0)
        {
            Console.Write("Enter N(N >= 1) = ");
            nString = Console.ReadLine();
        }

        Console.Write("Enter X = ");
        string xString = Console.ReadLine();
        decimal x;

        while (!(decimal.TryParse(xString, out x)))
        {
            Console.Write("Enter X(a number) = ");
            xString = Console.ReadLine();
        }

        decimal sum = 1;

        for (int i = 1; i <= n; i++)
        {
            sum += Factorial(i) / powerX(x, i);
        }

        Console.WriteLine("The result of the equation is {0}", sum);
    }
}
