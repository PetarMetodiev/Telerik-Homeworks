using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

class AllDatesInCanadaFormat
{
    //Write a program that extracts from a given text all dates that 
    //match the format DD.MM.YYYY. Display them in the standard date format for Canada.

    static DateTime GetDate(string str)
    {
        string[] currDate = str.ToString().Split('.');
        int day = int.Parse(currDate[0]);
        int month = int.Parse(currDate[1]);
        int year = int.Parse(currDate[2]);
        DateTime date = new DateTime(year, month, day);
        return date;
    }

    static void Main()
    {
        string text = @"I was born at 14.06.1980. My sister was born at 3.07.1984. In 5/1999 I graduated my high school. 
        The law says (see section 7.3.12) that we are allowed to do this (section 7.4.2.9).";

        Regex dateRegex = new Regex(@"\b\d{1,2}.\d{2}.\d{4}\b", RegexOptions.IgnoreCase);
        MatchCollection dateMatch = dateRegex.Matches(text);

        foreach (var item in dateMatch)
        {
            DateTime date = GetDate(item.ToString());
            Console.WriteLine(date.ToString(CultureInfo.GetCultureInfo("en-CA").DateTimeFormat.ShortDatePattern));
        }

    }
}
