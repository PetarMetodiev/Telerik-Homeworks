
// Write a program to convert decimal numbers to their binary representation.

using System;

class DecimalToBinary
{

    /// <summary>
    /// Check if the input data is valid
    /// </summary>
    /// <param name="numberString">String entered from the user</param>
    /// <returns>Valid integer</returns>
    static int CheckInput(string numberString)
    {
        int number;
        while (!int.TryParse(numberString, out number))
        {
            Console.Write("Enter valid integer: ");
            numberString = Console.ReadLine();
        }

        return number;
    }

    /// <summary>
    /// Converts decimal number to binary
    /// </summary>
    /// <param name="decimalNumber">Number to be converted</param>
    /// <returns>Returns the binary represenation as string to avoid Overflow Exception</returns>
    static string ConvertToBinary(int decimalNumber)
    {
        bool positive = true;
        if (decimalNumber < 0)
        {
            decimalNumber = Math.Abs(decimalNumber);
            positive = false;
        }

        string binaryNumber = string.Empty;
        int remainder;

        while (decimalNumber != 0)
        {
            remainder = decimalNumber % 2;
            binaryNumber = binaryNumber + remainder.ToString();
            decimalNumber /= 2;
        }

        // Adding leading zeroes.
        while (binaryNumber.Length % 4 != 0)
        {
            binaryNumber += "0";
        }

        // Convert the string into char array so it is easy to reverse it.
        char[] binaryArray = binaryNumber.ToCharArray();

        Array.Reverse(binaryArray);

        // Check if the entered number is 0.
        if (binaryNumber == string.Empty)
        {
            return "0";
        }

        binaryNumber = string.Empty;

        // Add leading spaces for easier reading.
        for (int i = 0; i < binaryArray.GetLongLength(0); i++)
        {
            if (i % 4 == 0 && i != 0)
            {
                binaryNumber += " ";
            }
            binaryNumber += binaryArray[i].ToString();
        }

        // Check if the number is negative to add -. I know this isn't the best solution but I couldn't think of better one.
        if (!positive)
        {
            binaryArray = binaryNumber.ToCharArray();
            Array.Reverse(binaryArray);
            binaryNumber = new string(binaryArray);
            binaryNumber += "-";
            binaryArray = binaryNumber.ToCharArray();
            Array.Reverse(binaryArray);
            binaryNumber = new string(binaryArray);
        }

        return binaryNumber;
    }

    static void Main()
    {
        Console.Title = "Convert from decimal to binary";

        Console.Write("Enter decimal number: ");
        string decimalNumberString = Console.ReadLine();
        int decimalNumber = CheckInput(decimalNumberString);

        string binaryNumber = ConvertToBinary(decimalNumber);

        Console.WriteLine("{0} d = {1} b", decimalNumber, binaryNumber);

    }
}