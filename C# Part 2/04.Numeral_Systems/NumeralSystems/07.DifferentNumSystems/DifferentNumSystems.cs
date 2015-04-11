
// Write a program to convert from any numeral system of given base s to any other numeral system of base d (2 ≤ s, d ≤  16).

using System;

class DifferentNumSystems
{
    /// <summary>
    /// Contains the possible digits for bases 2-16
    /// </summary>
    static char[] symbols = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' }; // If you wish you can add or remove symbols, the program will still work.

    /// <summary>
    /// Checks if the entered number is valid base
    /// </summary>
    /// <param name="numberString">Number to be checked</param>
    /// <returns>Valid number for base</returns>
    static int CheckBase(string numberString)
    {
        int number;
        while (!int.TryParse(numberString, out number) || number < 2 || number > symbols.Length)
        {
            Console.Write("Enter valid number: ");
            numberString = Console.ReadLine();
        }

        return number;
    }

    /// <summary>
    /// Checks if a number is valid in a given base
    /// </summary>
    /// <param name="numberString">Number to be checked</param>
    /// <param name="numberBase">Needed base</param>
    /// <returns>True if the number is valid in the given base</returns>
    static bool CheckInputNumber(string numberString, int numberBase)
    {
        numberString = numberString.ToUpper();

        // String to contain only the needed digits
        string digitsForBase = new string(symbols, 0, numberBase);

        foreach (char digit in numberString)
        {
            if (digitsForBase.Contains(digit.ToString()) || numberString[0] == '-')
            {
                return true;
            }
        }

        return false;
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
    /// Converts number from given base to decimal
    /// </summary>
    /// <param name="numberString">Valid number to be converted</param>
    /// <param name="numberBase">Base of the given number</param>
    /// <returns>Decimal representation of the number</returns>
    static int ConvertToDecimal(string numberString, int numberBase)
    {
        int decimalNumber = 0;
        int numberDigit;
        int baseToPower;

        for (int i = 0; i < numberString.Length; i++)
        {
            if (numberString[i] != '-')
            {
                numberDigit = Array.IndexOf(symbols, numberString[i]);
                baseToPower = Power(numberBase, numberString.Length - 1 - i);
                decimalNumber += numberDigit * baseToPower;
            }

        }

        return decimalNumber;
    }

    /// <summary>
    /// Converts a decimal number to any given base
    /// </summary>
    /// <param name="decimalNumber">Valid decimal number</param>
    /// <param name="numberBase">Base to convert the decimal to</param>
    /// <returns>Converted to custom base number</returns>
    static string ConvertToAnyBase(int decimalNumber, int numberBase)
    {
        string numberWithCustomBase = string.Empty;
        int remainder = 0;

        // In case the entered number is negative.
        decimalNumber = Math.Abs(decimalNumber);

        while (decimalNumber != 0)
        {
            remainder = decimalNumber % numberBase;
            numberWithCustomBase = numberWithCustomBase + remainder.ToString();
            decimalNumber /= numberBase;
        }

        // Simple algorithm for reversing the string.
        char[] numberWithCustomBaseArray = numberWithCustomBase.ToCharArray();
        Array.Reverse(numberWithCustomBaseArray);
        numberWithCustomBase = new string(numberWithCustomBaseArray);

        if (numberWithCustomBase == string.Empty)
        {
            return "0";
        }

        return numberWithCustomBase;
    }

    static void Main()
    {
        Console.Title = "Convert between different numberal systems";

        Console.Write("Enter base of first numeral system: ");
        int firstBase = CheckBase(Console.ReadLine());

        Console.Write("Enter number with base {0}: ", firstBase);
        string numberString = Console.ReadLine();

        while (!CheckInputNumber(numberString, firstBase))
        {
            Console.Write("Enter valid number with base {0}: ", firstBase);
            numberString = Console.ReadLine();
        }

        Console.WriteLine();

        Console.Write("Enter base of second numeral system: ");
        int secondBase = CheckBase(Console.ReadLine());

        Console.WriteLine();

        bool positive = numberString[0] != '-';

        int decimalNumber = ConvertToDecimal(numberString, firstBase);
        string numberToNewBase = ConvertToAnyBase(decimalNumber, secondBase);

        if (positive)
        {
            Console.WriteLine("{0} (base {1}) = {2} (base {3})", numberString, firstBase, numberToNewBase, secondBase);
        }
        else
        {
            Console.WriteLine("{0} (base {1}) = -{2} (base {3})", numberString, firstBase, numberToNewBase, secondBase);
        }

    }
}