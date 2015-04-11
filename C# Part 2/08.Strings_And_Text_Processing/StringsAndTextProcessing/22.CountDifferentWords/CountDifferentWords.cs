using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class CountDifferentWords
{
    static void Main()
    {
        Console.Write("Write some text: ");
        string text = Console.ReadLine();
        string[] words = text.Split(new string[] { ",", " ", "." }, StringSplitOptions.RemoveEmptyEntries);
        Dictionary<string, int> countWords = new Dictionary<string, int>();

        for (int i = 0; i < words.Length; i++)
        {
            if (countWords.ContainsKey(words[i]))
            {
                countWords[words[i]]++;
            }
            else
            {
                countWords.Add(words[i], 1);
            }
        }

        foreach (var word in countWords)
        {
            Console.WriteLine(word.Key + ":" + word.Value);
        }
    }
}
