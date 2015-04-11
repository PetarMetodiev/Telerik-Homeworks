
// Write a program that reads a number N and calculates the sum of the first N members of the sequence of Fibonacci: 
// 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …
// Each member of the Fibonacci sequence (except the first two) is a sum of the previous two members.

using System;
using System.Numerics;

class NthFibonacci
{
    static void Main()
    {
        Console.Title = "Fibonacci sequence";

        Console.Write("Enter Nth position of the Fibonacci sequence, N = ");
        string nString = Console.ReadLine();
        uint n;

        while (!(uint.TryParse(nString, out n)) || n < 3)
        {
            Console.Write("Enter Nth position of the Fibonacci sequence, N(N >= 3) = ");
            nString = Console.ReadLine();
        }

        // The usage of BigInteger is to prevent any exceptions

        BigInteger first = 0;                       // The first member is 0.
        BigInteger second = 1;                      // The second member is 1.
        BigInteger third = first + second;          // It is written like that, instead of 1, because it gives a better representation of the Fibonacci sequence
        BigInteger sum = third;                     // At first the sum is equal to the third element

        for (int i = 1; i < n; i++)
        {
            third = second + first;                 // Claculating the current third member
            sum = sum + third;                      // New sum
            first = second;                         // The first and second members are changed with their new values
            second = third;
        }

        Console.WriteLine("The sum of the first {0} members of the Fibonacci sequence is {1}", n, sum);
    }
}