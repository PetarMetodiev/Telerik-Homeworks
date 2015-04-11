using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

class CountLetters
{
    //Write a program that reads a string from the console and prints all different 
    //letters in the string along with information how many times each letter is found. 

    static void Main()
    {
        Console.Write("Write text: ");
        string text = Console.ReadLine();

        Dictionary<char, int> countLetters = new Dictionary<char, int>();

        for (int i = 0; i < text.Length; i++)
        {
            if (Regex.IsMatch(text[i].ToString(), "[a-zA-Z]"))
            {

                if (countLetters.ContainsKey(text[i]))
                {
                    countLetters[text[i]]++;
                }
                else
                {
                    countLetters.Add(text[i], 1);
                }
            }
        }

        foreach (var letter in countLetters)
        {
            Console.WriteLine(letter.Key + ":" + letter.Value);
        }
    }
}