
// Write a program that replaces all occurrences of the substring "start" with the substring "finish" in a text file. 
// Ensure it will work with large files (e.g. 100 MB).

using System;
using System.IO;

class ReplaceStartFinish
{
    static void Main()
    {
        Console.Title = "Replace start with finish";

        string startFilePath = @"..\..\text-files\start file.txt";
        string endFilePath = @"..\..\text-files\end file.txt";

        StreamReader reader = new StreamReader(startFilePath);
        StreamWriter writer = new StreamWriter(endFilePath);

        string searchedWord = "start";
        string replaceWord = "finish";

        using (reader)
        {
            using (writer)
            {
                // Reading the file line by line ensures there will be no memory overflow.
                string line = reader.ReadLine();

                while (line != null)
                {
                    string replace = line.Replace(searchedWord, replaceWord);
                    writer.WriteLine(replace);
                    line = reader.ReadLine();
                }
            }
        }

    }
}
