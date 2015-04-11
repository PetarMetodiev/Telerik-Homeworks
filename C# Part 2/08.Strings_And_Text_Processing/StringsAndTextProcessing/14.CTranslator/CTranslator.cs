using System;
using System.Collections.Generic;

class CTranslator
{
    //A dictionary is stored as a sequence of text lines containing words and their explanations.
    //Write a program that enters a word and translates it by using the dictionary. Sample dictionary:

    static void Main(string[] args)
    {

        string text = @".NET - platform for applications from Microsoft
          CLR - managed execution environment for .NET
          namespace - hierarchical organization of classes";

        string[] lines = text.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        Dictionary<string, string> dictionary = new Dictionary<string, string>();

        for (int i = 0; i < lines.Length; i++)
        {
            string[] str = lines[i].Split(new string[] { " - " }, StringSplitOptions.RemoveEmptyEntries);
            dictionary.Add(str[0].Trim().ToLower(), str[1]);

        }
        Console.Write("Choose a word ( {0} ): ", string.Join(", ", dictionary.Keys));
        string word = Console.ReadLine();
        if (dictionary.ContainsKey(word.ToLower()))
        {
            Console.WriteLine(word + " -> " + dictionary[word.ToLower()]);
        }
        else
        {
            Console.WriteLine("This word is not in the dictionary!");
        }
    }
}
