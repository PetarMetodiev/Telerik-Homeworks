
// Write a method that adds two positive integer numbers represented as arrays of digits 
// (each array element arr[i] contains a digit; the last digit is kept in arr[0]). 
// Each of the numbers that will be added could have up to 10 000 digits.

using System;
using System.Collections.Generic;

class BigIntegerAddition
{
    static byte[] CreateDigitArray(string number)                                   // Method for creating array of digits from string
    {
        List<byte> digitList = new List<byte>();
        byte digit = 0;

        for (int i = 0; i < number.Length; i++)                                     // Loop for parsing each char to byte
        {
            if (byte.TryParse(number[i].ToString(), out digit) == true)             // This check is to determine if there symbols, different from digits
            {
                digitList.Add(byte.Parse(number[i].ToString()));
            }
        }

        byte[] digitArray = new byte[digitList.Count];

        for (int i = 0; i < digitList.Count; i++)                                   // Assigning the values from the list to the array
        {
            digitArray[i] = digitList[i];
        }

        return digitArray;
    }

    static byte[] AdditionOfBigNumbers(byte[] firstNumber, byte[] secondNumber)     // Method for the summation
    {
        Array.Reverse(firstNumber);                                                 // Reversing the arrays of digits
        Array.Reverse(secondNumber);

        List<byte> longNumber = new List<byte>();                                   // Creating lists to hold the long and short arrays. The length of the arrays is needed in order for the algorithm to work
        List<byte> shortNumber = new List<byte>();

        if (firstNumber.Length > secondNumber.Length)                               // Checking which number is longer and assigning it to the respecitve list
        {
            longNumber.AddRange(firstNumber);
            shortNumber.AddRange(secondNumber);
        }
        else
        {
            longNumber.AddRange(secondNumber);
            shortNumber.AddRange(firstNumber);
        }

        int longLength = longNumber.Count;
        int shortLength = shortNumber.Count;
        byte carry = 0;                                                             // Holds one when there is a member which is greater than 10 - едно на ум
        int currentMember = 0;                                                      // Holds the value for each member of the result

        List<byte> resultList = new List<byte>();                                   // Temporary list to hold the reversed result

        for (int i = 0; i < longLength; i++)                                        // Loop for carrying out the calculations
        {
            if (i < shortLength)                                                    // Check if it is possible to add three digits - current digit from the first and second number and the carry
            {
                currentMember = longNumber[i] + shortNumber[i] + carry;
                if (currentMember >= 10)                                            // Check if the current member is greater than 10. In that case only the last digit of that member is taken and carry is turned into 1
                {
                    currentMember = currentMember % 10;
                    carry = 1;
                    resultList.Add((byte)currentMember);
                }
                else
                {
                    carry = 0;
                    resultList.Add((byte)currentMember);
                }
            }
            else                                                                    // The case where only current digit of the first member and the carry are added
            {
                currentMember = longNumber[i] + carry;
                if (currentMember >= 10)
                {
                    currentMember = currentMember % 10;
                    carry = 1;
                    resultList.Add((byte)currentMember);
                }
                else
                {
                    carry = 0;
                    resultList.Add((byte)currentMember);
                }
            }
        }

        if (carry == 1)                                                             // Check if there is still left carry, then it is added (99 + 1 = 100)
        {
            resultList.Add(1);
        }

        byte[] result = new byte[resultList.Count];                                 // Declaring the final array which will hold the final result

        for (int i = 0; i < resultList.Count; i++)                                  // Reversing the list and assigning it to the final array
        {
            result[i] = resultList[resultList.Count - 1 - i];
        }

        return result;
    }

    static void Main()
    {
        Console.Title = "Adding big numbers";

        Console.Write("Enter first number: ");
        string firstNumberString = Console.ReadLine();
        byte[] firstNumber = CreateDigitArray(firstNumberString);

        Console.Write("Enter second number: ");
        string secondNumberString = Console.ReadLine();
        byte[] secondNumber = CreateDigitArray(secondNumberString);

        byte[] resultNumber = AdditionOfBigNumbers(firstNumber, secondNumber);      // Assigning the final result to an array
                                                                                    // Printing the final result
        Console.WriteLine("{0} + {1} = {2}", string.Join("", firstNumber), string.Join("", secondNumber), string.Join("", resultNumber));
    }
}