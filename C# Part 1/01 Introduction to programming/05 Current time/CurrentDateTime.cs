using System;

class CurrentDateTime
{
    static void Main()
    {
        Console.Title = "Current Date and Time";
        DateTime now = DateTime.Now;
        Console.WriteLine(now);
    }
}
