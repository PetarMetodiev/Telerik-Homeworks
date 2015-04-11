using System;
using System.Text;

class ForbiddenWords
{
    //We are given a string containing a list of forbidden words and a text containing 
    //some of these words. Write a program that replaces the forbidden words with asterisks. Example
    //Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 
    //and is implemented as a dynamic language in CLR.
    //Words: "PHP, CLR, Microsoft"
    //The expected result:
    //********* announced its next generation *** compiler today. It is based on
    //.NET Framework 4.0 and is implemented as a dynamic language in ***.



    static void Main()
    {
        string text = "Microsoft announced its next generation PHP compiler today. It is based on .NET" +
        "Framework 4.0 and is implemented as a dynamic language in CLR.";

        string[] forbiddenWords = "PHP, CLR, Microsoft, generation".Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries);
        StringBuilder newText = new StringBuilder(text);
        for (int i = 0; i < forbiddenWords.Length; i++)
        {
            int startWordPos = text.IndexOf(forbiddenWords[i]);
            for (int j = startWordPos; j < startWordPos + forbiddenWords[i].Length; j++)
            {
                newText[j] = '*';
            }

        }
        Console.WriteLine(newText);
    }
}
