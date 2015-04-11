
//Write a program that reads 3 integer numbers from the console and prints their sum.

using System;

class SumNumbers
{
    static void Main()
    {
        Console.Title = "Summation of numbers";

        Console.Write("Enter amount of numbers you wish to sum, n = ");
        string numString = Console.ReadLine();
        int num;            // Contains the total amount of numbers
        while (!(int.TryParse(numString, out num)) || num <= 0)
        {
            Console.Write("Enter amount of number you wish to sum, n(n>0) = ");
            numString = Console.ReadLine();
        }

        int sum = 0;        // Contains the total sum
        int input;          // Contains every entered value
        string inputString;

        for (int i = 0; i < num; i++)
        {
            Console.Write("Enter integer a{0} = ", i+1);
            inputString = Console.ReadLine();

            while (!int.TryParse(inputString, out input))       // Check for the input data
            {
                Console.Write("Enter integer a{0} = ", i+1);
                inputString = Console.ReadLine();
            }
            sum = sum + input;
        }
        Console.WriteLine("The total sum is {0}", sum);
    }
}
