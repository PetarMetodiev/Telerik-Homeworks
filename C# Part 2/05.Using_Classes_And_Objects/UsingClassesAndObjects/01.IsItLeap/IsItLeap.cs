
// Write a program that reads a year from the console and checks whether it is a leap. Use DateTime.

using System;

class IsItLeap
{
    static int IsValidYear(string yearString)
    {
        int year;

        while (int.TryParse(yearString, out year) && (year < 1 || year > 9999))
        {
            Console.Write("Enter valid year(integer between 1 and 9999): ");
            yearString = Console.ReadLine();
        }

        return year;
    }

    static void Main()
    {
        Console.Title = "Is your year leap?";

        Console.Write("Enter year to be checked: ");
        int year = IsValidYear(Console.ReadLine());

        bool isLeap = DateTime.IsLeapYear(year);

        if (isLeap)
        {
            Console.WriteLine("Year {0} is leap.", year);
        }
        else
        {
            Console.WriteLine("Year {0} is not leap.", year);
        }
    }
}
