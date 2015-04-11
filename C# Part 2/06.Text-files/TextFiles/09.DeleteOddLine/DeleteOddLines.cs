
// Write a program that deletes from given text file all odd lines. The result should be in the same file.

using System;
using System.IO;
using System.Collections.Generic;

class DeleteOddLines
{
    static void Main()
    {
        Console.Title = "Remove all odd lines from a file";

        string filePath = @"..\..\text-files\file.txt";

        StreamReader reader = new StreamReader(filePath);

        // Creating a list to contain all the odd lines
        List<string> oddLinesList = new List<string>();

        using (reader)
        {
            string line = reader.ReadLine();

            // Adding the odd lines to the list.
            while (line != null)
            {
                oddLinesList.Add(line);
                reader.ReadLine();
                line = reader.ReadLine();
            }
        }

        StreamWriter writer = new StreamWriter(filePath);

        using (writer)
        {
            for (int i = 0; i < oddLinesList.Count; i++)
            {
                writer.WriteLine(oddLinesList[i]);
            }
        }

        Console.WriteLine("Done!");
    }
}
