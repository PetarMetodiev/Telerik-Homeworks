using System;
using System.Text;

class ReverseSentance
{
    //Write a program that reverses the words in given sentence.
    //Example: "C# is not C++, not PHP and not Delphi!" -> "Delphi not and PHP, not C++ not is C#!".

    static void Main()
    {

        string text = "C# is not C++, not PHP and not Delphi!";
        string[] words = text.Split(new char[] { ' ', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
        string[] punctuations = text.Split(words, StringSplitOptions.RemoveEmptyEntries);

        Array.Reverse(words);
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < punctuations.Length; i++)
        {
            builder.Append(words[i]);
            builder.Append(punctuations[i]);

        }
        Console.WriteLine(builder.ToString());

    }
}
