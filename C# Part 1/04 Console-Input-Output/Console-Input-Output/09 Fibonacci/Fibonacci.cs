
// Write a program to print the first 100 members of the sequence of Fibonacci: 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89, 144, 233, 377, …

using System;

class Fibonacci
{
    static void Main()
    {
        Console.Title = "Fibonacci sequence";

        decimal first = 0;
        decimal second = 1;
        decimal third = first + second;
        decimal sum = 0;

        Console.WriteLine(first);
        Console.WriteLine(second);

        for (int i = 0; i < 100; i++)
        {
            third = second + first;
            Console.WriteLine(third);
            sum = sum + third;
            first = second;
            second = third;
        }

        Console.WriteLine("The sum of the first 100 members of the Fibonacci sequence is {0}", sum);
    }
}
