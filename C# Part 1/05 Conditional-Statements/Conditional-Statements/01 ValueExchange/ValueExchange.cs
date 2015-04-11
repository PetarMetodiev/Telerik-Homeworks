
// Write an if statement that examines two integer variables and exchanges their values if the first one is greater than the second one.

using System;

class ValueExchange
{
    static void Main()
    {
        Console.Title = "Value exchange";

        Console.Write("Enter first number, a = ");
        string aString = Console.ReadLine();
        int a;

        while (!(int.TryParse(aString, out a)))
        {
            Console.Write("Enter first number(integer), a = ");
            aString = Console.ReadLine();
        }

        Console.Write("Enter second number, b = ");
        string bString = Console.ReadLine();
        int b;

        while (!(int.TryParse(bString, out b)))
        {
            Console.Write("Enter second number(integer), b = ");
            bString = Console.ReadLine();
        }

        int temp;       // Temporary variable for making the exchange
        bool check = a > b;

        if (check)
        {
            Console.WriteLine("a = {0} is greater than b = {1}, so their values have to be exchanged.", a, b);
            temp = a;
            a = b;
            b = temp;
            Console.WriteLine("The new values after the exchange are a = {0} and b = {1}.", a, b);
        }
        else
        {
            Console.WriteLine("a = {0} is smaller than b = {1}, so no exchange of the values is required.", a, b);
        }
    }
}
