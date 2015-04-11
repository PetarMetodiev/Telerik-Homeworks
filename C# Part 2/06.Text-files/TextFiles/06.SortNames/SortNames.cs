
// Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file. 
using System;
using System.IO;
using System.Collections.Generic;

class SortNames
{
    static void Main()
    {
        Console.Title = "Sort the names";

        string readFile = @"..\..\text-files\unsorted list.txt";
        string writeFile = @"..\..\text-files\sorted list.txt";

        StreamReader reader = new StreamReader(readFile);
        StreamWriter writer = new StreamWriter(writeFile);

        using (reader)
        {
            // Using the list to store the names.
            List<string> stringList = new List<string>();
            string line = reader.ReadLine();

            while (line != null)
            {
                stringList.Add(line);
                line = reader.ReadLine();
            }

            // Sroting the list.
            stringList.Sort();

            using (writer)
            {
                // Writing the sorted names to another file.
                for (int i = 0; i < stringList.Count; i++)
                {
                    writer.WriteLine(stringList[i]);
                }
            }
        }

        Console.WriteLine("Done!");
    }
}
