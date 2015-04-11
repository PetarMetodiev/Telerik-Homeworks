
// Write a program that reads an integer number n from the console and prints all the numbers in the interval [1..n], each on a single line.

using System;

class PrintOneToN
{
    static void Main()
    {
        Console.Title = "Print the integer from 1 to n";

        Console.Write("Enter max number n = ");
        string nString = Console.ReadLine();
        int n;

        while (!(int.TryParse(nString, out n)) || n <= 0)
        {
            Console.Write("Enter n(positive integer) = ");
            nString = Console.ReadLine();
        }

        int sum = 0;

        for (int i = 1; i <= n; i++)
        {
            sum = sum + i;
        }

        Console.WriteLine("The total sum of the integers between 1 and {0} is {1}", n, sum);
    }
}