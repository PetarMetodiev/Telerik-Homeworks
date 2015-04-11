
// You are given a text. Write a program that changes the text in all regions surrounded by the tags <upcase> and </upcase> to uppercase. 
// The tags cannot be nested.
using System;
using System.Text;

class ChangeCase
{
    static void Main()
    {
        Console.Title = "Change the casing in the tag";

        string text = @"We <upcase>are living</upcase> in a <upcase>yellow submarine</upcase>. We don't have <upcase>anything</upcase> else.";

        string openTag = "<upcase>";
        string closeTag = "</upcase>";

        // StringBuilder to hold the final text.
        StringBuilder editedText = new StringBuilder();
        // String builder to hold only UPPER CASE parts.
        StringBuilder textToChangeCase = new StringBuilder();

        // Loop to check the whole text.
        for (int i = 0; i < text.Length; i++)
        {
            // Check if the current symbol is a start of a tag.
            if (i == text.IndexOf(openTag, i))
            {
                // If so - skip the tag.
                i += openTag.Length;

                // After skipping the tag, add the new text to a stringbuilder
                while (i != text.IndexOf(closeTag, i))
                {
                    textToChangeCase.Append(text[i]);
                    // Increase i(still running through the same text).
                    i++;
                }

                // Add the text between the tags to the inital text and make it UPPER CASE.
                editedText.Append(textToChangeCase.ToString().ToUpper());
                // Clear the previous text between tags.
                textToChangeCase.Clear();

                // Skip the closing tag.
                i += closeTag.Length;
            }

            // If a tag is not met, just add the next symbol.
            editedText.Append(text[i]);
        }

        Console.WriteLine(editedText.ToString());
    }
}
