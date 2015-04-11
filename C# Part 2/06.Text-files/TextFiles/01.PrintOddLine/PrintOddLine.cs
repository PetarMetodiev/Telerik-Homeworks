
// Write a program that reads a text file and prints on the console its odd lines.

using System;
using System.IO;

class PrintOddLine
{
    static void Main()
    {
        Console.Title = "Print odd lines from a file";

        string fileName = @"..\..\PrintOddLine.cs";

        StreamReader reader = new StreamReader(fileName);
        using (reader)
        {
            int lineCount = 1;
            string line = reader.ReadLine();
            while (line != null)
            {
                Console.Write("Line number {0}: ", lineCount);
                Console.WriteLine(line);
                reader.ReadLine();
                line = reader.ReadLine();
                lineCount += 2;
            }
        }
    }
}
