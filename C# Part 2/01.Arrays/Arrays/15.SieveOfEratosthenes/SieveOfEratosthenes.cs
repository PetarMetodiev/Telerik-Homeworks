
// Write a program that finds all prime numbers in the range [1...10 000 000]. Use the sieve of Eratosthenes algorithm 

using System;

class SieveOfEratosthenes
{
    static void Main()
    {
        uint range = 10000000;
        bool[] prime = new bool[range + 1];

        for (uint i = 2; i <= range; i++)
        {
            prime[i] = true;
        }

        for (uint j = 2; j <= range; j++)
        {
            if (prime[j])
            {
                for (uint p = 2; (p * j) <= range; p++)
                {
                    prime[p * j] = false;
                }
            }
        }

        int countPrimes = 0;
        for (int i = 0; i <= range; i++)
        {
            if (prime[i])
            {
                countPrimes++;
            }
        }

        Console.WriteLine("The count of primes from 2 to 10 000 000 is {0}.", countPrimes);
        Console.WriteLine("Do you want to print all prime numbers from 1 to 10 million.");
        Console.WriteLine("Press 'Y' for Yes or anything else for exit and then press Enter");
        string printPrimes = Console.ReadLine();
        if (printPrimes == "y" || printPrimes == "Y")                       // Too many numbers to print, so the user is asked if they should be printed
        {
            uint tenNumbers = 0;
            for (uint i = 0; i <= range; i++)
            {
                if (prime[i])
                {
                    Console.Write("{0} ", i);
                    tenNumbers++;
                }
                if (tenNumbers == 10 || i == range)
                {
                    Console.WriteLine();
                    tenNumbers = 0;
                }
            }
        }
    }
}