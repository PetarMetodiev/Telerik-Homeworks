
// Write a program that concatenates two text files into another text file.

using System;
using System.IO;

class ConcatenateTwoFiles
{
    static void Main()
    {
        Console.Title = "Concatenate two files into third";

        string fileName1 = @"..\..\text-files\textfile1.txt";
        string fileName2 = @"..\..\text-files\textfile2.txt";
        string final = @"..\..\text-files\final.txt";

        string fileOneContents;

        StreamReader reader = new StreamReader(fileName1);
        using (reader)
        {
            fileOneContents = reader.ReadToEnd();
        }

        string fileTwoContents;

        reader = new StreamReader(fileName2);
        using (reader)
        {
            fileTwoContents = reader.ReadToEnd();
        }

        StreamWriter writer = new StreamWriter(final);
        using (writer)
        {
            writer.WriteLine(fileOneContents);
            writer.WriteLine(fileTwoContents);
        }
        Console.WriteLine("Done!");

    }
}