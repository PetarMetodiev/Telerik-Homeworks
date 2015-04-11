
// Write a method that returns the last digit of given integer as an English word. Examples: 512 -> "two", 1024 -> "four", 12309 -> "nine".

using System;

class LastDigit
{
    static int Input()                                                                                  // Method to check and convert the input data
    {
        Console.Write("Enter number: ");
        string inputString = Console.ReadLine();
        int input;

        while (!int.TryParse(inputString, out input))
        {
            Console.Write("Enter valid integer: ");
            inputString = Console.ReadLine();
        }

        return input;
    }

    static string SayLastDigit(int number)                                                              // Method to say the last digit
    {
        int lastDigit = number % 10;                                                                    // Holds the last digit of the number

        switch (lastDigit)                                                                              // Using switch to determine the output of the method
        {
            case 0: return "zero";
            case 1: return "one";
            case 2: return "two";
            case 3: return "three";
            case 4: return "four";
            case 5: return "five";
            case 6: return "six";
            case 7: return "seven";
            case 8: return "eight";
            case 9: return "nine";
        }

        return "null";                                                                                  // This had to be written to escape compile error
    }

    static void Main()
    {
        Console.Title = "Say the last digit of a number";

        int number = Input();                                                                           // Assigning the entered number to a int variable

        Console.WriteLine("The last digit of the number {0} is {1}.", number, SayLastDigit(number));    // Printing the final result
    }
}