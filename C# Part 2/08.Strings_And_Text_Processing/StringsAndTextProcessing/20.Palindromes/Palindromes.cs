using System;
using System.Text;

class ExtractPalindromes
{
    //Write a program that extracts from a given text all palindromes, e.g. "ABBA", "lamal", "exe".

    static bool IsPalindrome(string s)
    {
        if (s.Length >= 3)
        {
            var chars = s.ToCharArray();
            Array.Reverse(chars);

            return s == new string(chars);
        }
        return false;
    }

    static void Main()
    {
        string text = "Write a program that extracts from a given text all palindromes, e.g. ABBA, lamal, exe";

        string[] words = text.Split(new string[] { ",", " " }, StringSplitOptions.RemoveEmptyEntries);
        StringBuilder palindromes = new StringBuilder();

        for (int i = 0; i < words.Length; i++)
        {
            if (IsPalindrome(words[i]))
            {
                palindromes.AppendLine(words[i]);
            }
        }

        if (palindromes.Length > 0)
        {
            Console.WriteLine("Palindromes in the text");
            Console.Write(palindromes);
        }
        else
        {
            Console.WriteLine("There are no palindromes in the text.");
        }
    }
}