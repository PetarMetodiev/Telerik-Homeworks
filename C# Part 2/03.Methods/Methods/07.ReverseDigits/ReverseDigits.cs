
// Write a method that reverses the digits of given decimal number. Example: 256 -> 652

using System;

class ReverseDigits
{
    static int Input(string numberString, bool isSize)                      // Method for checking and converting the input data. It is used for all input data - size of the array(>0), elements of the array and searched number(any integer)
    {                                                                       // the isSize variable is used as a flag if the processed number is size of the array(only integers greater than 0) or not
        int number;
        if (isSize == true)                                                 // If the requred number is size of the array
        {
            while (!int.TryParse(numberString, out number) || number < 1)   // The number has to be a valid positive integer
            {
                Console.Write("Enter valid positive integer: ");
                numberString = Console.ReadLine();
            }
        }
        else                                                                // The case where only a valid integer is needed
        {
            while (!int.TryParse(numberString, out number))
            {
                Console.Write("Enter valid integer: ");
                numberString = Console.ReadLine();
            }
        }

        return number;

    }

    static string DigitsReverser(int number)                                // Method for reversing the digits of the number
    {
        string numberAsString = number.ToString();                          // Converting the number to string for easier reversion
        string reversedNumberString = "";                                   // Holds the value for the reversed number
        for (int i = numberAsString.Length - 1; i >= 0; i--)                // Loop for reversing the number
        {
            if (numberAsString[i] == '-')                                   // Check if the number is negative
            {
                break;
            }
            reversedNumberString = reversedNumberString + numberAsString[i];
        }

        return reversedNumberString;                                        // The method returns string, not int since if a big integer is reversed, it may no longer fit in int.
    }

    static void Main()
    {
        Console.Title = "Invert the digits";

        Console.Write("Enter number: ");
        int number = Input(Console.ReadLine(), false);

        Console.WriteLine("The reversed number is {0}",DigitsReverser(number));
    }
}