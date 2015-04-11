
// Write a program that compares two text files line by line and prints the number of lines that are 
// the same and the number of lines that are different. Assume the files have equal number of lines.

using System;
using System.IO;

class EqualLines
{
    static void Main()
    {
        Console.Title = "Count the number of equal lines in two files";

        string readFirstFile = @"..\..\text-files\file1.txt";
        string readSecondFile = @"..\..\text-files\file2.txt";
        
        StreamReader readerFirst = new StreamReader(readFirstFile);
        StreamReader readerSecond = new StreamReader(readSecondFile);

        string lineFirstFile;
        string lineSecondFile;
        int equalRowsCount = 0;
        int differentRowsCount = 0;

        using (readerFirst)
        {
            using (readerSecond)
            {
                lineFirstFile = readerFirst.ReadLine();
                lineSecondFile = readerSecond.ReadLine();

                while (lineFirstFile != null)
                {
                    if (lineFirstFile == lineSecondFile)
                    {
                        equalRowsCount++;
                    }
                    else
                    {
                        differentRowsCount++;
                    }

                    lineFirstFile = readerFirst.ReadLine();
                    lineSecondFile = readerSecond.ReadLine();
                }
            }
        }

        Console.WriteLine("Number of equal rows: {0}", equalRowsCount);
        Console.WriteLine("Number of different rows: {0}", differentRowsCount);
    }
}
