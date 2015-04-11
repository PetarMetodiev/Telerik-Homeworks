
// Write a method GetMax() with two parameters that returns the bigger of two integers. 
// Write a program that reads 3 integers from the console and prints the biggest of them using the method GetMax().

using System;

class GetMaxValue
{
    static int StringAsInteger(string inputString)                                              // Method to check and convert the input data
    {
        int input;
        while (!int.TryParse(inputString, out input))
        {
            Console.Write("Enter valid integer: ");
            inputString = Console.ReadLine();
        }

        return input;
    }

    static int GetMax(int a, int b)                                                             // Method to take the maximum value of two integers
    {
        if (a > b)                                                                              // There is no else statement, because if the conditional statement is true,the method returns a, and we leave the method
        {
            return a;
        }
        return b;
    }

    static void Main()
    {
        Console.Title = "Get the max value of three";

        Console.Write("Enter first number: ");
        string firstString = Console.ReadLine();
        int first;

        first = StringAsInteger(firstString);

        Console.Write("Enter second number: ");
        string secondString = Console.ReadLine();
        int second;

        second = StringAsInteger(secondString);

        Console.Write("Enter third number: ");
        string thirdString = Console.ReadLine();
        int third;

        third = StringAsInteger(thirdString);

        Console.WriteLine("The maximum value is {0}", GetMax(first, GetMax(second, third)));    // One of the arguements of the method is itself. At the end for each usage of the GetMax method only two values are used

    }
}
