
// Write a program that deletes from a text file all words that start with the prefix "test". 
// Words contain only the symbols 0...9, a...z, A…Z, _.

using System;
using System.IO;

class DeleteTest
{
    static void Main()
    {
        Console.Title = "Delete the test!";

        string filePath = @"..\..\text-files\testfile.txt";

        StreamReader reader = new StreamReader(filePath);

        string editedText = string.Empty;

        using (reader)
        {
            string wholeText = reader.ReadToEnd();
            char[] separators = new char[] { ' ' };
            string[] words = wholeText.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            string toDelete = "test";

            for (int i = 0; i < words.GetLength(0); i++)
            {
                if (words[i].Contains(toDelete))
                {
                    string currentWord = words[i];
                    string editedWord;
                    if (currentWord.Substring(0, toDelete.Length) == toDelete)
                    {
                        editedWord = currentWord.Substring(toDelete.Length);
                        words[i] = editedWord;
                    }
                }
            }

            editedText = string.Join(" ", words);
            //Console.WriteLine(editedText);

        }

        StreamWriter writer = new StreamWriter(filePath);

        using (writer)
        {
            writer.Write(editedText);
        }

        Console.WriteLine("Done!");
    }
}