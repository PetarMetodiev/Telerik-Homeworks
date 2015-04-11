
// Write a program to convert decimal numbers to their hexadecimal representation.

using System;

class DecimalToHexadecimal
{
    /// <summary>
    /// Check if the input data is valid
    /// </summary>
    /// <param name="numberString">String entered from the user</param>
    /// <returns>Valid hexadecimal number</returns>
    static int CheckInput(string numberString)
    {
        int number;

        while (!int.TryParse(numberString, out number))
        {
            Console.Write("Enter valid decimal number: ");
            numberString = Console.ReadLine();
        }

        return number;
    }

    /// <summary>
    /// Converts decimal number to hexadecimal
    /// </summary>
    /// <param name="decimalNumber">Decimal number</param>
    /// <returns>The hexadeximal number as string</returns>
    static string ConvertDecimalToHex(int decimalNumber)
    {
        string hexNumber = string.Empty;
        string remainder = string.Empty;
        if (decimalNumber < 0)
        {
            decimalNumber = -decimalNumber;
        }
        while (decimalNumber != 0)
        {
            if (decimalNumber % 16 < 10)
            {
                remainder = (decimalNumber % 16).ToString();
            }
            else
            {
                switch (decimalNumber % 16)
                {
                    case 10: remainder = "A"; break;
                    case 11: remainder = "B"; break;
                    case 12: remainder = "C"; break;
                    case 13: remainder = "D"; break;
                    case 14: remainder = "E"; break;
                    case 15: remainder = "F"; break;
                    
                }
            }

            hexNumber += remainder;
            decimalNumber /= 16;
        }

        char[] hexArray = hexNumber.ToCharArray();

        Array.Reverse(hexArray);

        return new string(hexArray);
    }

    static void Main()
    {
        Console.Title = "Convert decimal to hexadecimal";

        Console.Write("Enter decimal number: ");
        int number = CheckInput(Console.ReadLine());

        if (number > 0)
        {
            Console.WriteLine("{0}d = {1}hex", number, ConvertDecimalToHex(number));
        }
        else
        {
            Console.WriteLine("{0} d = -{1} hex", number, ConvertDecimalToHex(number));
        }
        
    }
}