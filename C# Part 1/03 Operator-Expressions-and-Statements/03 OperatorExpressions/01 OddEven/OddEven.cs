
//Write an expression that checks if given integer is odd or even.

using System;

class OddEven
{
    static void Main()
    {
        Console.Title = "Check if a number is odd or even";

        Console.Write("Enter number: ");
        string numString = Console.ReadLine();
        int num;
        while (int.TryParse(numString, out num) == false)
        {
            Console.Write("Enter valid number(integer): ");
            numString = Console.ReadLine();
        }
        if (num % 2 == 0)
        {
            Console.WriteLine("The number {0} is even", num);
        }
        else
        {
            Console.WriteLine("The number {0} is odd", num);
        }
    }
}
