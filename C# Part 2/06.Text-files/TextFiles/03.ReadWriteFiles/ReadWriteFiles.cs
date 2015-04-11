
// Write a program that reads a text file and inserts line numbers in front of each of its lines. 
// The result should be written to another text file.

using System;
using System.IO;
using System.Text;

class ReadWriteFiles
{
    static void Main()
    {
        Console.Title = "Read from file, edit and write to another file";

        string readFile = @"..\..\text-files\Text file to read.txt";
        string writeFile = @"..\..\text-files\Text file to write.txt";

        // Cretating reader and writer.
        StreamReader reader = new StreamReader(readFile);
        StreamWriter writer = new StreamWriter(writeFile);

        // Using both reader and writer.
        using (reader)
        {
            using (writer)
            {
                int lineNumber = 0;
                string line = reader.ReadLine();
                while (line != null)
                {
                    lineNumber++;
                    writer.WriteLine("Line {0}: {1}", lineNumber, line);
                    line = reader.ReadLine();
                }

            }
        }
        Console.WriteLine("Done!");
    }
}