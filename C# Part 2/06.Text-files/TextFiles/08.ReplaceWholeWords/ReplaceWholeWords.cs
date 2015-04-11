
// Modify the solution of the previous problem to replace only whole words (not substrings).

using System;
using System.IO;
using System.Text.RegularExpressions;

class ReplaceWholeWords
{
    static void Main()
    {

        Console.Title = "Replace start with finish";

        string startFilePath = @"..\..\text-files\start file.txt";
        string endFilePath = @"..\..\text-files\end file.txt";

        StreamReader reader = new StreamReader(startFilePath);
        StreamWriter writer = new StreamWriter(endFilePath);

        string searchedWord = @"\bstart\b";
        string replacedWord = "finish";

        using (reader)
        {
            using (writer)
            {
                // Reading the file line by line ensures there will be no memory overflow.
                string line = reader.ReadLine();

                while (line != null)
                {
                    // Using regular expressions.
                    string result = Regex.Replace(line, searchedWord, replacedWord);
                    writer.WriteLine(result);
                    line = reader.ReadLine();
                }
            }
        }

        Console.WriteLine("Done!");
    }
}
