using System;

class Program
{
    //Write a program that reads two dates in the format: 
    //day.month.year and calculates the number of days between them. Example:
    //Enter the first date: 27.02.2006
    //Enter the second date: 3.03.2006
    //Distance: 4 days

    static void Main()
    {
        Console.Write("First date (dd.mm.yyyy): ");
        string[] firstInputDate = Console.ReadLine().Split('.');
        int day = int.Parse(firstInputDate[0]);
        int month = int.Parse(firstInputDate[1]);
        int year = int.Parse(firstInputDate[2]);

        DateTime startDate = new DateTime(year, month, day);

        Console.Write("Second date (dd.mm.yyyy): ");
        string[] secondInputDate = Console.ReadLine().Split('.');
        day = int.Parse(secondInputDate[0]);
        month = int.Parse(secondInputDate[1]);
        year = int.Parse(secondInputDate[2]);


        DateTime endDate = new DateTime(year, month, day);
        Console.WriteLine("Days between them " + (endDate - startDate).TotalDays);
    }
}