
// Write a program that creates an array containing all letters from the alphabet (A-Z). 
// Read a word from the console and print the index of each of its letters in the array.

using System;
using System.Collections.Generic;

class IndexOfLetter
{
    static void Main()
    {
        Console.Title = "Alphabetical index of letters";

        Console.Write("Enter your word: ");
        string word = Console.ReadLine().ToUpper();

        char[] alphabet = new char[26];

        for (int i = 0; i < alphabet.Length; i++)
        {
            alphabet[i] = (char)(i + 65);
        }

        foreach (char letter in word)
        {
            for (int i = 0; i < alphabet.Length; i++)
            {
                if (alphabet[i] == letter)
                {
                    Console.WriteLine("Index of {0}: {1}", letter, i + 1);
                    break;
                }
            }
        }
    }
}