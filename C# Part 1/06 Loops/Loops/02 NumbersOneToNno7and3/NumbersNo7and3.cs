
// Write a program that prints all the numbers from 1 to N, that are not divisible by 3 and 7 at the same time.

using System;

class NumbersNo7and3
{
    static void Main()
    {
        Console.Title = "Print all numbers between 1 and N wich are not divisable by 3 and 7";

        Console.Write("Enter number, N = ");
        string numString = Console.ReadLine();
        uint num;

        while (!(uint.TryParse(numString, out num)))
        {
            Console.Write("Enter number, N(N>0) = ");
            numString = Console.ReadLine();
        }

        for (int i = 1; i <= num; i++)          // The loop starts from i = 1, because if i = 0, then 0 % 21 = 0
        {
            if (i % 21 != 0)
            {
                Console.WriteLine(i);
            }
        }
    }
}
