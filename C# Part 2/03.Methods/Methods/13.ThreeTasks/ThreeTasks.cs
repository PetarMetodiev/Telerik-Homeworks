using System;
using System.Collections.Generic;

class ThreeTasks
{
    static void ReverseDigits()
    {
        Console.WriteLine();
        Console.Write("Enter your number: ");
        string numberString = Console.ReadLine();
        int number;

        while (!int.TryParse(numberString, out number) || number < 0)
        {
            Console.Write("Enter valid integer: ");
            numberString = Console.ReadLine();
        }

        numberString = number.ToString();
        string reversedNumberString = "";

        for (int i = numberString.Length - 1; i >= 0; i--)
        {
            if (numberString[i] != '-')
            {
                reversedNumberString = reversedNumberString + numberString[i];
            }
        }

        Console.WriteLine("The reversed number is {0}", reversedNumberString);
    }

    static void AverageOfSequence()
    {
        Console.WriteLine();

        Console.Write("Enter your sequence. Separate the elements by spaces: ");
        string sequenceString = Console.ReadLine();
        while (sequenceString == "")
        {
            Console.Write("Enter sequence with at least one element: ");
            sequenceString = Console.ReadLine();
        }
        string[] separators = new string[] { " " };
        string[] numbersAsStrings = sequenceString.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        int count = numbersAsStrings.Length;
        int sum = 0;

        for (int i = 0; i < numbersAsStrings.Length; i++)
        {
            sum = sum + int.Parse(numbersAsStrings[i]);
        }

        double average = (double)sum / (double)count;
        Console.WriteLine("The average of you sequence is {0}", average);

    }

    static void LinearEquation()
    {
        Console.WriteLine();

        Console.Write("Enter coefficient a = ");
        string aString = Console.ReadLine();
        double a;

        while (!double.TryParse(aString, out a) || a == 0)
        {
            Console.Write("Enter valid non-zero value for a. a = ");
            aString = Console.ReadLine();
        }

        Console.Write("Enter coefficient b = ");
        string bString = Console.ReadLine();
        double b;

        while (!double.TryParse(bString, out b))
        {
            Console.Write("Enter valid number for b. b = ");
            bString = Console.ReadLine();
        }

        double x = -b / a;

        Console.WriteLine("Your equation is {0}*x - {1} = 0", a, b);
        Console.WriteLine("x = {0}", x);
    }

    static void Main()
    {
        Console.Title = "Solve three tasks";

        Console.WriteLine("Choose one of three tasks to be done.");
        Console.WriteLine("Enter 1 for reversing digits.");
        Console.WriteLine("Enter 2 for calculating average of a sequence.");
        Console.WriteLine("Enter 3 for solving linear equation.");
        Console.Write("Your choice? ");
        string choiceString = Console.ReadLine();
        uint choice;

        while (uint.TryParse(choiceString, out choice) && (choice < 1 || choice > 3))
        {
            Console.Write("Please enter valid option from the menu: ");
            choiceString = Console.ReadLine();
        }

        if (choice == 1)
        {
            ReverseDigits();
        }
        if (choice == 2)
        {
            AverageOfSequence();
        }
        if (choice == 3)
        {
            LinearEquation();
        }
    }
}
