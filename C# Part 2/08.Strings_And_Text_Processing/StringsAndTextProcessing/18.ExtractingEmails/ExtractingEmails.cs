using System;
using System.Text;
using System.Text.RegularExpressions;

class ExtractingEmails
{
    //Write a program for extracting all email addresses from given text. 
    //All substrings that match the format <identifier>@<host>…<domain> should be recognized as emails.

    static void Main()
    {
        string text = @"My name is Jonny and my email is jonny@begood.com
                       my friend's email is my_friend@best.bg";

        Regex emailRegex = new Regex(@"\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", // @"\w+@\w+\.\w+"
            RegexOptions.IgnoreCase);
        MatchCollection emailMatches = emailRegex.Matches(text);

        StringBuilder emails = new StringBuilder();

        foreach (Match emailMatch in emailMatches)
        {
            emails.AppendLine(emailMatch.Value);
        }

        Console.WriteLine(emails);
    }
}
