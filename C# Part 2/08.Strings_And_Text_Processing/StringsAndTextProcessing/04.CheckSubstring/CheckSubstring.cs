using System;
using System.Text.RegularExpressions;

class CheckSubstring
{
    static void Main()
    {
        Console.Title = "Check the number of times a substring occurs";

        string text = "We are living in an yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.";

        string searcedSubstring = "in";

        int countOfOccurance = Regex.Matches(text.ToLower(), searcedSubstring).Count;

        Console.WriteLine("The substring \"{0}\" appears in the text {1} times", searcedSubstring, countOfOccurance);
    }
}