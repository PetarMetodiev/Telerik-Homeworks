
// Write a program that reads from the console a string of maximum 20 characters. 
// If the length of the string is less than 20, the rest of the characters should be filled with '*'. 
// Print the result string into the console.

using System;
using System.Text;

class TwentyCharacters
{
    /// <summary>
    /// Checks if a given string is shorter than 20 characters and if so - adds * at the end. If not - trims the excess.
    /// </summary>
    /// <param name="text">String to be checked</param>
    /// <returns>Edited string</returns>
    static string TextEditor(string text)
    {
        StringBuilder textToEdit = new StringBuilder();

        if (text.Length == 20)
        {
            return text;
        }
        else if (text.Length > 20)
        {
            return text.Substring(0,20);
        }
        else
        {
            for (int i = 0; i < 20; i++)
            {
                if (i < text.Length)
                {
                    textToEdit.Append(text[i]);
                }
                else
                {
                    textToEdit.Append("*");
                }
            }
            return textToEdit.ToString();
        }
    }

    static void Main()
    {
        Console.Title = "The 20 character check";

        Console.Write("Enter your text: ");
        string text = Console.ReadLine();

        Console.WriteLine(TextEditor(text));
    }
}
