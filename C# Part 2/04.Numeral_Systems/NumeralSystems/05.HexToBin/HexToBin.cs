
// Write a program to convert hexadecimal numbers to binary numbers (directly).

using System;

class HexToBin
{

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
    /// Check if all characters of a given string are valid hexadecimal digits
    /// </summary>
    /// <param name="hexNumberString">The hexadecimal number as string</param>
    /// <returns>True if the number is hexadeciamal</returns>
    static bool IsHexCharacter(string hexNumberString)
    {
        hexNumberString = hexNumberString.ToUpper();


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
    /// Gets the binary representation of each hexadecimal digit
    /// </summary>
    /// <param name="hexChar">Valid hexadecimal digit</param>
    /// <returns>The equal binary representation of the digit or negative sign(-)</returns>
    static string GetHexRepresentationAsBin(char hexChar)
    {
        switch (hexChar)
        {
            case '0': return "0000";
            case '1': return "0001";
            case '2': return "0010";
            case '3': return "0011";
            case '4': return "0100";
            case '5': return "0101";
            case '6': return "0110";
            case '7': return "0111";
            case '8': return "1000";
            case '9': return "1001";
            case 'A': return "1010";
            case 'B': return "1011";
            case 'C': return "1100";
            case 'D': return "1101";
            case 'E': return "1110";
            case 'F': return "1111";
                // The only case after checking the number to not be a valid hexadecimal digit is to have a negative number.
            default: return "-";
        }
    }

    /// <summary>
    /// Converts valid hexadecimal number to binary
    /// </summary>
    /// <param name="hexNumberString">Valid hexadecimal number</param>
    /// <returns>Binary representation of hexadecimal number</returns>
    static string ConvertHexToBin(string hexNumberString)
    {
        string binNumberString = string.Empty;

        for (int i = 0; i < hexNumberString.Length; i++)
        {
            binNumberString += GetHexRepresentationAsBin(hexNumberString[i]) + " ";
        }

        return binNumberString;
    }

    static void Main()
    {
        Console.Title = "Convert directly from hexadecimal to binary";

        Console.Write("Enter hexadecimal number: ");
        string hexNumberString = CheckInputData(Console.ReadLine());

        string binNumberString = ConvertHexToBin(hexNumberString);

        Console.WriteLine("{0} hex = {1} b",hexNumberString, binNumberString);
    }
}