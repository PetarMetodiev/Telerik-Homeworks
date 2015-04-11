
// Write a method that calculates the number of workdays between today and given date, passed as parameter. 
// Consider that workdays are all days from Monday to Friday except a fixed list of public holidays specified preliminary as array.

using System;
using System.Linq;

class Workdays
{

    /// <summary>
    /// Just some test dates.
    /// </summary>
    static DateTime[] holidays = {
                              new DateTime(2014,03,03),
                              new DateTime(2014,12,24),
                              new DateTime(2014,12,25),
                              new DateTime(2014,12,26),
                              new DateTime(2014,12,30),
                              new DateTime(2014,12,31),
                              new DateTime(2014,01,22)
                          };
    static void Main()
    {
        Console.Write("Enter end date(format - dd.mm.yyyy):");
        string[] endDateString = Console.ReadLine().Split('.');
        int day = int.Parse(endDateString[0]);
        int month = int.Parse(endDateString[1]);
        int year = int.Parse(endDateString[2]);

        DateTime currentDate = DateTime.Today;
        DateTime givenDate = new DateTime(year, month, day);

        int totalDays = Math.Abs((givenDate - currentDate).Days);
        if (givenDate < currentDate)
        {
            givenDate = currentDate;
            currentDate = DateTime.Today;
        }

        int workDayCounter = 0;

        for (int i = 0; i < totalDays; i++)
        {
            currentDate = currentDate.AddDays(1);
            // Check if the current day is Saturday or Sunday.
            if (currentDate.DayOfWeek != DayOfWeek.Saturday && currentDate.DayOfWeek != DayOfWeek.Sunday)
            {
                // Check if not Saturday or Sunday if it is holiday.
                if (!holidays.Contains(currentDate))
                {
                    workDayCounter++;
                }
            }
        }

        Console.WriteLine("Total working days between {0} and {1} - {2}", DateTime.Today, givenDate.Date, workDayCounter);

    }
}
