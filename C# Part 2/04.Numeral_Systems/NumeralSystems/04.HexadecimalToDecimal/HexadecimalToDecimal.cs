
// Write a program to convert hexadecimal numbers to their decimal representation.

using System;
using System.Globalization;

class HexadecimalToDecimal
{
    /// <summary>
    /// Check if all characters of a given string are valid hexadecimal digits
    /// </summary>
    /// <param name="hexNumberString">The hexadecimal number as string</param>
    /// <returns>True if the number is hexadeciamal</returns>
    static bool IsHexCharacter(string hexNumberString)
    {
        for (int i = 0; i < hexNumberString.Length; i++)
        {

            if (hexNumberString[0] != '-' && ((int)hexNumberString[i] < 48 || (int)hexNumberString[i] > 57) && ((int)hexNumberString[i] < 65 || (int)hexNumberString[i] > 70))
            {
                return false;
            }
        }

        return true;
    }

    /// <summary>
    /// Check if the entered hexadecimal number is positive
    /// </summary>
    /// <param name="hexNumberString">The hexadecimal number as string</param>
    /// <returns>True if the number is positive</returns>
    static bool IsPositive(string hexNumberString)
    {
        if (hexNumberString[0] == '-')
        {
            return false;
        }

        return true;
    }

    /// <summary>
    /// Ensures a given string is valid hexadecimal number
    /// </summary>
    /// <param name="hexNumberString">The hexadecimal number as string</param>
    /// <returns>Valid hexadecimal number</returns>
    static string CheckInputData(string hexNumberString)
    {
        hexNumberString = hexNumberString.ToUpper();

        while (!IsHexCharacter(hexNumberString))
        {
            for (int i = 0; i < hexNumberString.Length; i++)
            {
                if (GetHexChar(hexNumberString[i]) == -1)
                {

                    Console.Write("Enter valid hexadecimal number: ");
                    hexNumberString = Console.ReadLine();
                }
            }

        }

        hexNumberString = hexNumberString.ToUpper();

        return hexNumberString;
    }

    /// <summary>
    /// Contains a list of all valid hexadecimal digits
    /// </summary>
    /// <param name="hexChar">Valid hexadecimal digit as char</param>
    /// <returns>The equvalent decimal number</returns>
    static int GetHexChar(char hexChar)
    {
        switch (hexChar)
        {
            case '0': return 0;
            case '1': return 1;
            case '2': return 2;
            case '3': return 3;
            case '4': return 4;
            case '5': return 5;
            case '6': return 6;
            case '7': return 7;
            case '8': return 8;
            case '9': return 9;
            case 'A': return 10;
            case 'B': return 11;
            case 'C': return 12;
            case 'D': return 13;
            case 'E': return 14;
            case 'F': return 15;
        }
        return -1;
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
    /// Converts given valid hexadecimal number to decimal number
    /// </summary>
    /// <param name="hexNumberString">Valid hexadecimal number as string</param>
    /// <returns>The equivalent decimal number</returns>
    static int ConvertHexToDec(string hexNumberString)
    {
        int decimalNumber = 0;


        for (int i = 0; i < hexNumberString.Length; i++)
        {
            if (!IsPositive(hexNumberString) && i == 0)
            {
                continue;
            }
            decimalNumber = decimalNumber + GetHexChar(hexNumberString[i]) * Power(16, hexNumberString.Length - 1 - i);
        }

        return decimalNumber;
    }

    static void Main()
    {
        Console.Title = "Convert hexadecimal to decimal";

        Console.Write("Enter hexadecimal number: ");
        string hexNumberString = CheckInputData(Console.ReadLine());

        int decimalNumber = ConvertHexToDec(hexNumberString);

        if (IsPositive(hexNumberString))
        {
            Console.WriteLine("{0} hex = {1} d", hexNumberString, decimalNumber);
        }
        else
        {
            decimalNumber = -decimalNumber;
            Console.WriteLine("{0} hex = {1} d", hexNumberString, decimalNumber);
        }
    }
}