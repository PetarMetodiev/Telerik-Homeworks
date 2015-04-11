
// Write a program to convert binary numbers to their decimal representation.

using System;

class BinaryToDecimal
{
    /// <summary>
    /// Check if the input data is valid
    /// </summary>
    /// <param name="numberString">String entered from the user</param>
    /// <returns>Valid binary number</returns>
    static string CheckInput(string numberString)
    {
        while (!IsBinary(numberString))
        {
            Console.Write("Enter valid binary number: ");
            numberString = Console.ReadLine();
        }

        return numberString;
    }

    /// <summary>
    /// Checks if the entered number is binary
    /// </summary>
    /// <param name="numberString">Entered string</param>
    /// <returns></returns>
    static bool IsBinary(string numberString)
    {
        foreach (char digit in numberString)
        {
            if (digit != '0' && digit != '1' && digit != '-')
            {
                return false;
            }
        }
        for (int i = 1; i < numberString.Length; i++)
        {
            if (numberString[i] != '0' && numberString[i] != '1')
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Check if the first member of a given string i -
    /// </summary>
    /// <param name="binNumberString">Number as string</param>
    /// <returns>False if the first member is -</returns>
    static bool IsPositive(string binNumberString)
    {
        if (binNumberString[0] == '-')
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// Rises a number to a power
    /// </summary>
    /// <param name="number">Number to be raised to power</param>
    /// <param name="power">Power</param>
    /// <returns>Final number</returns>
    static int Power(int number, int power)
    {
        int product = 1;
        for (int i = 0; i < power; i++)
        {
            product *= number;
        }

        return product;
    }

    /// <summary>
    /// Converts binary number to decimal
    /// </summary>
    /// <param name="binaryString">Binary number</param>
    /// <returns>The equivelent decimal number</returns>
    static int ConvertToDecimal(string binaryString)
    {
        int decimalNumber = 0;

        for (int i = 0; i < binaryString.Length; i++)
        {
            if (binaryString[i] != '-')
            {
                decimalNumber += int.Parse(binaryString[i].ToString()) * Power(2, binaryString.Length - 1 - i);
            }

        }

        return decimalNumber;
    }

    /// <summary>
    /// Adds leading zeroes to a valid binary number
    /// </summary>
    /// <param name="binaryNumber">Valid binary nuber as string</param>
    /// <returns>Binary number with required leding zeroes</returns>
    static string AddLeadingZeroes(string binaryNumber)
    {
        char[] binaryArray = binaryNumber.ToCharArray();

        // Check if the binary number is positive.
        if (binaryNumber[0] == '-')
        {
            Array.Reverse(binaryArray);
            binaryNumber = new string(binaryArray);
            binaryNumber = binaryNumber.TrimEnd('-');
        }
        else
        {
            binaryArray = binaryNumber.ToCharArray();
            Array.Reverse(binaryArray);
            binaryNumber = new string(binaryArray);
        }

        // Loop for adding the required zeroes.
        while (binaryNumber.Length % 4 != 0)
        {
            binaryNumber += "0";
        }

        binaryArray = binaryNumber.ToCharArray();
        binaryNumber = string.Empty;

        // Creating the final number with zeroes and spaces between groups.
        for (int i = 0; i < binaryArray.GetLongLength(0); i++)
        {
            if (i % 4 == 0 && i != 0)
            {
                binaryNumber += " ";
            }
            binaryNumber += binaryArray[i].ToString();
        }

        binaryArray = binaryNumber.ToCharArray();
        Array.Reverse(binaryArray);
        binaryNumber = new string(binaryArray);

        return binaryNumber;
    }

    static void Main()
    {
        Console.Title = "Convert from binary to decimal";

        Console.Write("Enter binary number: ");
        string binaryString = CheckInput(Console.ReadLine());
        int decimalNumber = ConvertToDecimal(binaryString);

        if (IsPositive(binaryString))
        {
            binaryString = AddLeadingZeroes(binaryString);
            Console.WriteLine("{0} b = {1} d", binaryString, decimalNumber);
        }
        else
        {
            binaryString = AddLeadingZeroes(binaryString);
            Console.WriteLine("{0} b = -{1} d", binaryString, decimalNumber);
        }

    }
}