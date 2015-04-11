
// Write a program that reads an integer number and calculates and prints its square root. 
// If the number is invalid or negative, print "Invalid number". In all cases finally print "Good bye". Use try-catch-finally.

using System;

class CheckValidInteger
{
    static void Main()
    {
        Console.Title = "Check if the integer is valid";

        try
        {
            Console.Write("Enter integer: ");
            int number = int.Parse(Console.ReadLine());

            if (number < 0)
            {
                throw new ArithmeticException("The number should be positive.");
            }

            double root = Math.Sqrt(number);
            Console.WriteLine("The square root of {0} is {1}.", number, root);
        }
        catch (OverflowException oe)
        {
            Console.WriteLine(oe.Message);
        }
        catch (FormatException fe)
        {
            Console.WriteLine(fe.Message);
        }
        finally
        {
            Console.WriteLine("GoodBye!");
        }
    }
}
