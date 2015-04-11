
// * Write a program that shows the internal binary representation of given 32-bit signed floating-point number in IEEE 754 format 
// (the C# type float). Example: -27,25  sign = 1, exponent = 10000011, mantissa = 10110100000000000000000.

using System;
using System.Text;


/*
 * 
 * GARBAGE!!!
 * 
 */


class BinRepresentationOfFloat
{
    static float CheckInput(string numberString)
    {
        float number;

        while (!float.TryParse(numberString, out number))
        {
            Console.Write("Enter valid float number: ");
            numberString = Console.ReadLine();
        }

        return number;
    }

    static string Sign(float number)
    {
        if (number >= 0)
        {
            return "0";
        }
        return "1";
    }

    static string ReverseString(string input)
    {
        char[] inputArray = input.ToCharArray();
        Array.Reverse(inputArray);
        input = new string(inputArray);

        return input;
    }

    static string WholePart(float number)
    {
        string wholePartString = number.ToString();
        if (!wholePartString.Contains(",") && !wholePartString.Contains("."))
        {
            return wholePartString;
        }

        StringBuilder wholePartBuilder = new StringBuilder();

        int i = 0;
        while (wholePartString[i] != ',' && wholePartString[i] != '.')
        {
            wholePartBuilder.Append(wholePartString[i]);
            i++;
        }

        wholePartString = wholePartBuilder.ToString();

        return wholePartString;
    }

    static string WholePartBinary(string wholePartString)
    {
        int wholePartInt = int.Parse(wholePartString);

        StringBuilder exponent = new StringBuilder();
        int remainder;

        while (wholePartInt != 0)
        {
            remainder = wholePartInt % 2;
            exponent.Append(remainder.ToString());
            wholePartInt /= 2;
        }

        string exponentString = exponent.ToString();
        exponentString = ReverseString(exponentString);

        return exponentString;
    }

    static string Fraction(float number)
    {
        string fracionString = number.ToString();

        if (!fracionString.Contains(",") && !fracionString.Contains("."))
        {
            return "0";
        }
        int i = fracionString.Length - 1;

        StringBuilder fractionBuilder = new StringBuilder();

        while (fracionString[i] != ',' && fracionString[i] != '.')
        {
            fractionBuilder.Append(fracionString[i].ToString());
            i--;
        }

        fracionString = fractionBuilder.ToString();
        fracionString = ReverseString(fracionString);

        return fracionString;
    }

    static string FractionBinary(string fractionString)
    {
        float fractionFloat = int.Parse(fractionString);
        fractionFloat /= 100;

        StringBuilder fractionBinaryBuilder = new StringBuilder();

        for (int i = 0; i < 23; i++)
        {
            fractionFloat = fractionFloat * 2;
            if (fractionFloat >= 1)
            {
                fractionBinaryBuilder.Append("1");
                fractionFloat = fractionFloat - 1;
            }
        }

        return fractionBinaryBuilder.ToString();

    }

    static string NormalizeBinary(string wholePartBinary, string fractionBinary)
    {
        string completeBinaryString = wholePartBinary + "," + fractionBinary;
        double completeBinary = double.Parse(completeBinaryString);

        

        int exponent = 0;

        while (completeBinary > 2)
        {
            completeBinary /= 10;
            exponent++;
        }
        exponent += 127;
        string mantissa = WholePartBinary(exponent.ToString());

        StringBuilder exponentBuilder = new StringBuilder();
        exponentBuilder.Append(mantissa);
        while (exponentBuilder.Length % 8 != 0)
        {
            exponentBuilder.Append("0");
        }
        Console.WriteLine("Exponent = {0}", exponentBuilder.ToString());
        Console.WriteLine("Complete binary = ", completeBinary.ToString());

        return completeBinary.ToString();
    }

    //static string Exponent(string wholePartString)
    //{

    //}

    //static string Mantissa(string decimalPart)
    //{

    //}

    static void Main()
    {
        Console.Write("Enter float number: ");
        float number = CheckInput(Console.ReadLine());

        string wholeNumber = WholePart(number);
        Console.WriteLine("Whole part = {0}", wholeNumber);

        string decimalPart = Fraction(number);
        Console.WriteLine("Decimal part = {0}", decimalPart);

        string wholePartBinary = WholePartBinary(wholeNumber);
        Console.WriteLine("Whole part binary = {0}", wholePartBinary);

        string fractionBinary = FractionBinary(decimalPart);
        Console.WriteLine("Fraction binary = {0}", fractionBinary);

        Console.WriteLine("Normalized binary = {0}", NormalizeBinary(wholePartBinary, fractionBinary));

        //string exponent = Exponent(wholeNumber);
        //Console.WriteLine("Exponent = {0}", exponent);
    }
}