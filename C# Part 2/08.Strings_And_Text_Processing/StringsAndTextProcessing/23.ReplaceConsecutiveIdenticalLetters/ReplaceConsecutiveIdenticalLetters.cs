using System;
using System.Text;

class ReplaceConsecutiveIdenticalLetters
{
    //Write a program that reads a string from the console and replaces all series of consecutive
    //identical letters with a single one. Example: "aaaaabbbbbcdddeeeedssaa"  "abcdedsa".

    static void Main()
    {
        Console.Write("Write some text: ");
        string text = Console.ReadLine();
        StringBuilder result = new StringBuilder();

        char prevCh = text[0];
        for (int i = 1; i < text.Length; i++)
        {
            if (prevCh != text[i])
            {
                result.Append(prevCh);
                prevCh = text[i];
            }
            if (i + 1 == text.Length)
            {
                result.Append(text[i]);
            }
        }
        Console.WriteLine("Result: {0}", result);
    }
}