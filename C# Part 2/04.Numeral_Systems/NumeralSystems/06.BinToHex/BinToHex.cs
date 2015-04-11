
// Write a program to convert binary numbers to hexadecimal numbers (directly).

using System;

class BinToHex
{
    /// <summary>
    /// Check if the input data is valid
    /// </summary>
    /// <param name="inputString">String entered from the user</param>
    /// <returns>Valid binary number</returns>
    static string CheckInput(string inputString)
    {
        while (!IsBinary(inputString))
        {
            Console.Write("Enter valid binary number: ");
            inputString = Console.ReadLine();
        }

        return inputString;
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
    /// <param name="numberString">Number as string</param>
    /// <returns>False if the first member is -</returns>
    static bool IsPositive(string numberString)
    {
        if (numberString[0] == '-')
        {
            return false;
        }
        return true;
    }

    /// <summary>
    /// Converts every four binary digits into one hexadecmial
    /// </summary>
    /// <param name="binNumberString">Four binary digits</param>
    /// <returns>The equivelent hexadecimal representation</returns>
    static string GetBinRepresentationAsHex(string binNumberString)
    {
        switch (binNumberString)
        {
            case "0000": return "0";
            case "0001": return "1";
            case "0010": return "2";
            case "0011": return "3";
            case "0100": return "4";
            case "0101": return "5";
            case "0110": return "6";
            case "0111": return "7";
            case "1000": return "8";
            case "1001": return "9";
            case "1010": return "A";
            case "1011": return "B";
            case "1100": return "C";
            case "1101": return "D";
            case "1110": return "E";
            case "1111": return "F";
            default: return "-1";
        }
    }

    /// <summary>
    /// Reverses a string
    /// </summary>
    /// <param name="inputString"></param>
    /// <returns>Reversed string</returns>
    static string ReverseString(string inputString)
    {
        char[] numberArray = inputString.ToCharArray();
        Array.Reverse(numberArray);
        string reversedNumberString = new string(numberArray);

        return reversedNumberString;
    }

    /// <summary>
    /// Converts given valid binary number to hexadecimal
    /// </summary>
    /// <param name="binNumberString">Valid binary number</param>
    /// <returns>Equivalent hexadecimal number</returns>
    static string ConvertBinToHex(string binNumberString)
    {
        string hexNumberString = string.Empty;

        if (!IsPositive(binNumberString))
        {
            binNumberString = ReverseString(binNumberString);
            binNumberString = binNumberString.TrimEnd('-');
        }
        else
        {
            binNumberString = ReverseString(binNumberString);
        }

        while (binNumberString.Length % 4 != 0)
        {
            binNumberString += "0";
        }

        binNumberString = ReverseString(binNumberString);

        string temp = string.Empty;

        for (int i = 0; i < binNumberString.Length; i++)
        {
            temp += binNumberString[i].ToString();
            if (temp.Length % 4 == 0 && i != 0)
            {
                hexNumberString += GetBinRepresentationAsHex(temp);
                temp = string.Empty;
            }
        }

        return hexNumberString;
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
        Console.Title = "Convert directly binary to hexadecimal";

        Console.Write("Enter binary number: ");
        string binaryString = CheckInput(Console.ReadLine());

        string hexNumberString = ConvertBinToHex(binaryString);

        if (IsPositive(binaryString))
        {
            binaryString = AddLeadingZeroes(binaryString);
            Console.WriteLine("{0} b = {1} hex", binaryString, hexNumberString);
        }
        else
        {
            binaryString = AddLeadingZeroes(binaryString);
            Console.WriteLine("-{0} b = -{1} hex", binaryString, hexNumberString);
        }
    }
}