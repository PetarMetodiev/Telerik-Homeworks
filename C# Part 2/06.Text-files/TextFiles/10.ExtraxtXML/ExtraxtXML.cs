
// Write a program that extracts from given XML file all the text without the tags. 

using System;
using System.IO;
using System.Text;

class ExtraxtXML
{
    static void Main()
    {
        Console.Title = "Extract contents from XML file";

        string filePath = @"..\..\text-files\xmlfile2.xml";

        StreamReader reader = new StreamReader(filePath);

        StringBuilder contentOfXML = new StringBuilder();

        using (reader)
        {
            string line = reader.ReadLine();

            while (line != null)
            {
                // Check if the current line starts with a tag. The assumption is that if it doesn't start with a tag,
                // then the whole line does not contain a tag.
                if (line[0] != '<')
                {
                    contentOfXML.AppendLine(line);
                }
                // If there is a tag on the current line, check if there is text between tags.
                else
                {
                    for (int i = 1; i < line.Length; i++)
                    {
                        if (line[i - 1] == '>')
                        {
                            while (line[i] != '<')
                            {
                                contentOfXML.Append(line[i]);
                                i++;
                            }

                            contentOfXML.AppendLine();
                        }

                    }
                }
                line = reader.ReadLine();
            }
        }
        Console.WriteLine(contentOfXML.ToString());
    }
}
