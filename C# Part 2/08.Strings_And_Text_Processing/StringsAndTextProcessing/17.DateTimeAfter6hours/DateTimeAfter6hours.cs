using System;
using System.Globalization;

class DateTimeAfter6hours
{
    //Write a program that reads a date and time given in the format: day.month.year
    //hour:minute:second and prints the date and time after 6 hours and 30 minutes 
    //(in the same format) along with the day of week in Bulgarian

    static string BgDayOfWeeks(DateTime date)
    {
        string bgDayOfWeek = String.Empty;
        switch (date.DayOfWeek)
        {
            case DayOfWeek.Friday:
                bgDayOfWeek = "Петък";
                break;
            case DayOfWeek.Monday:
                bgDayOfWeek = "Понеделник";
                break;
            case DayOfWeek.Saturday:
                bgDayOfWeek = "Събота";
                break;
            case DayOfWeek.Sunday:
                bgDayOfWeek = "Неделя";
                break;
            case DayOfWeek.Thursday:
                bgDayOfWeek = "Четвъртък";
                break;
            case DayOfWeek.Tuesday:
                bgDayOfWeek = "Вторник";
                break;
            case DayOfWeek.Wednesday:
                bgDayOfWeek = "Сряда";
                break;
            default:
                break;
        }
        return bgDayOfWeek;
    }

    static void Main()
    {
        string inputDate = "13.10.2012 16:30:00";
        string[] dateArr = inputDate.Split(new string[] { ".", ":", " " }, StringSplitOptions.RemoveEmptyEntries);
        int day = int.Parse(dateArr[0]);
        int month = int.Parse(dateArr[1]);
        int year = int.Parse(dateArr[2]);
        int hours = int.Parse(dateArr[3]);
        int minutes = int.Parse(dateArr[4]);
        int seconds = int.Parse(dateArr[5]);

        DateTime date = new DateTime(year, month, day, hours, minutes, seconds);
        date = date.AddHours(6);
        date = date.AddMinutes(30);

        Console.WriteLine(date + " " + BgDayOfWeeks(date));

        Console.WriteLine("{0} {1}", date, date.ToString("dddd", new CultureInfo("bg-BG")));
    }
}
