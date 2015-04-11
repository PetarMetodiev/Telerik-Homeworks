using System;

class WordsInAlphabeticalOrder
{
    //Write a program that reads a list of words, separated by
    //spaces and prints the list in an alphabetical order.


    static void Main()
    {
        Console.WriteLine("Write list of words, separated by spaces");
        string text = Console.ReadLine();
        string[] words = text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

        Array.Sort(words);

        for (int i = 0; i < words.Length; i++)
        {
            Console.WriteLine(words[i]);
        }
    }
}