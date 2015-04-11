using System;
using System.Text;

class ConvertToUNICODE
{
    //Write a program that converts a string to a sequence of C# Unicode character literals.
    //Use format strings. Sample input: Hi!
    //Expected output: \u0048\u0069\u0021

    static void Main()
    {
        string word = "Telerik Academy!";

        for (int i = 0; i < word.Length; i++)
        {
            Console.Write("\\u{0:x4}", (ushort)word[i]);
        }
        Console.WriteLine();
    }
}