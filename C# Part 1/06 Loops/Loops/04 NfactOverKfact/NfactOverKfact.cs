
// Write a program that calculates N!/K! for given N and K (1<K<N).

using System;
using System.Numerics;

class NfactOverKfact
{
    static void Main()
    {
        Console.Title = "N!/K!";

        Console.Write("Enter N = ");
        string nString = Console.ReadLine();
        uint n;

        while (!(uint.TryParse(nString, out n)) || n < 3)               // N has to be greater than 2, because if N = 1, then K has to be zero and this doesn't meet the requirements
        {
            Console.Write("Enter N(N >= 3) = ");
            nString = Console.ReadLine();
        }

        Console.Write("Enter K = ");
        string kString = Console.ReadLine();
        uint k;

        while (!(uint.TryParse(kString, out k)) || k < 2 || k >= n)     // K has to be greater than 1 and less than N
        {
            Console.Write("Enter K(K >= 2; K < {0}) = ", n);
            kString = Console.ReadLine();
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

        Console.WriteLine("N!/K! = {0}", factN/factK);
    }
}
