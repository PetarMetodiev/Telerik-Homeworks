
// Write a program that calculates N!*K! / (K-N)! for given N and K (1<N<K).

using System;
using System.Numerics;

class FactorialEquation
{
    static void Main()
    {
        Console.Title = "N!/K! / (K-N)!";

        Console.Write("Enter K = ");
        string kString = Console.ReadLine();
        uint k;

        while (!(uint.TryParse(kString, out k)) || k < 3)               // K has to be greater than 2, because if K = 1, then N has to be zero and this doesn't meet the requirements.
        {
            Console.Write("Enter K(K >= 3) = ");
            kString = Console.ReadLine();
        }

        Console.Write("Enter N = ");
        string nString = Console.ReadLine();
        uint n;

        while (!(uint.TryParse(nString, out n)) || n < 2 || n >= k)     // N has to be greater than 1 and less than K
        {
            Console.Write("Enter N(N >= 2; N < {0}) = ", k);
            nString = Console.ReadLine();
        }

        BigInteger factN = 1;
        BigInteger factK = 1;

        for (int i = 1; i <= n; i++)                                    // Calculating N!
        {
            factN *= i;
        }

        for (int i = 1; i <= k; i++)                                    // Calculating K!
        {
            factK *= i;
        }

        BigInteger factKminusN = 1;

        for (int i = 1; i <= (k - n) ; i++)
        {
            factKminusN *= i;
        }

        BigInteger result = (factN * factK) / factKminusN;

        Console.WriteLine("N!*K! / (K-N)! = {0}", result);
    }
}
