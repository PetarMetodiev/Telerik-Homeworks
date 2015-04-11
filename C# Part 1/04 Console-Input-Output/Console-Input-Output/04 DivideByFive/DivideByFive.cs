
// Write a program that reads two positive integer numbers and prints how many numbers p exist between them such that 
// the reminder of the division by 5 is 0 (inclusive). Example: p(17,25) = 2.

using System;

class DivideByFive
{
    static void Main()
    {
        Console.Title = "Can you divide it by 5?";

        Console.Write("Enter first limit: ");
        string firstString = Console.ReadLine();
        uint first;

        while (!uint.TryParse(firstString, out first))
        {
            Console.Write("Enter first limit: ");
            firstString = Console.ReadLine();
        }

        Console.Write("Enter second limit: ");
        string secondString = Console.ReadLine();
        uint second;

        while (!uint.TryParse(secondString, out second))
        {
            Console.Write("Enter second limit: ");
            secondString = Console.ReadLine();
        }

        int counter = 0;

        if (first < second)
        {
            for (uint i = first; i <= second; i++)
            {
                if (i % 5 == 0)
                {
                    counter++;
                }
            }
        }
        else if (second < first)
        {
            for (uint i = second; i <= first; i++)
            {
                if (i % 5 == 0)
                {
                    counter++;
                }
            }
        }
        else
        {
            counter = 0;
        }

        Console.WriteLine("{0} numbers exist between the entered numbers",counter);
    }
}
