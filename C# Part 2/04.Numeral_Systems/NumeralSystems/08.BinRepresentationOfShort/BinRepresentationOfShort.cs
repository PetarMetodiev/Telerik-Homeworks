
// Write a program that shows the binary representation of given 16-bit signed integer number (the C# type short).

using System;
using System.Text;

class BinRepresentationOfShort
{
    /// <summary>
    /// Checks if the entered number is valid short integer
    /// </summary>
    /// <param name="numberString">String to be checked</param>
    /// <returns>Valid short integer</returns>
    static short CheckInputDataShort(string numberString)
    {
        short number;

        while (!short.TryParse(numberString, out number))
        {
            Console.Write("Enter valid short integer: ");
            numberString = Console.ReadLine();
        }

        return number;
    }

    /// <summary>
    /// Converts decimal number to binary
    /// </summary>
    /// <param name="number">Number to be converted</param>
    /// <returns>Returns the binary represenation as string to avoid Overflow Exception</returns>
    static string ConvertToBinary(short number)
    {
        bool positive = number > 0;
        if (!positive)
        {
            number = Math.Abs(number);
        }

        StringBuilder binaryNumber = new StringBuilder();

        int remainder;

        while (number != 0)
        {
            remainder = number % 2;
            binaryNumber.Append(remainder.ToString());
            number /= 2;
        }

        // Adding leading zeroes.
        while (binaryNumber.Length % 16 != 0)
        {
            binaryNumber.Append("0");
        }

        string binaryNumberString = binaryNumber.ToString();

        // Convert the string into char array so it is easy to reverse it.
        char[] binaryArray = binaryNumberString.ToCharArray();

        Array.Reverse(binaryArray);

        // Check if the entered number is 0.
        if (binaryNumberString == string.Empty)
        {
            return "0000 0000";
        }

        binaryNumberString = string.Empty;
        binaryNumber.Clear();

        // Add leading spaces for easier reading.
        for (int i = 0; i < binaryArray.GetLongLength(0); i++)
        {
            if (i % 8 == 0 && i != 0)
            {
                binaryNumber.Append(" ");
            }
            binaryNumber.Append(binaryArray[i].ToString());
        }

        binaryNumberString = binaryNumber.ToString();

        // Check if the number is negative to add -. I know this isn't the best solution but I couldn't think of better one.
        if (!positive)
        {
            binaryArray = binaryNumberString.ToCharArray();
            Array.Reverse(binaryArray);
            binaryNumberString = new string(binaryArray);
            binaryNumberString += "-";
            binaryArray = binaryNumberString.ToCharArray();
            Array.Reverse(binaryArray);
            binaryNumberString = new string(binaryArray);
        }

        return binaryNumberString;
    }

    static void Main()
    {
        Console.Title = "Show the binary representation of sbyte";

        Console.Write("Enter integer: ");
        string integerString = Console.ReadLine();

        short number = CheckInputDataShort(integerString);

        string binaryNumber = ConvertToBinary(number);

        Console.WriteLine("{0} d = {1} b",number,binaryNumber);

    }
}
