
// Write a method ReadNumber(int start, int end) that enters an integer number in given range [start…end]. 
// If an invalid number or non-number text is entered, the method should throw an exception. 
// Using this method write a program that enters 10 numbers:
// a1, a2, … a10, such that 1 < a1 < … < a10 < 100

using System;

class Boundaries
{
    static int ReadNumber(int start, int end, int currentPosition)
    {
        int number;

        Console.Write("Enter number at position {0}: ", currentPosition);
        number = int.Parse(Console.ReadLine());

        if (number <= start || number > end)
        {
            throw new ArgumentOutOfRangeException();
        }

        return number;
    }

    static void Main()
    {
        Console.Title = "Check if a number is within the boundaries";

        int number = 1;

        try
        {
            for (int i = 1; i < 11; i++)
            {
                number = ReadNumber(number, 100, i);
            }
        }
        catch (FormatException fe)
        {
            Console.WriteLine(fe.Message);
        }
        catch(OverflowException oe)
        {
            Console.WriteLine(oe.Message);
        }
        catch(ArgumentNullException ane)
        {
            Console.WriteLine(ane.Message);
        }
    }
}