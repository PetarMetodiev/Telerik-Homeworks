
// Write a program that generates and prints to the console 10 random values in the range [100, 200].

using System;

class TenRandomNumbers
{
    static void Main()
    {
        Console.Title = "Generate 10 random numbers";

        Random randomGenerator = new Random();
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(randomGenerator.Next(100,201));
        }
    }
}