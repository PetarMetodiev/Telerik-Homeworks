
// Write a program that prints to the console which day of the week is today. Use System.DateTime.

using System;

    class DayOfTheWeek
    {
        static void Main()
        {
            Console.Title = "What day of the week is today?";

            Console.WriteLine("Today is {0}.",DateTime.Now.DayOfWeek);
        }
    }
