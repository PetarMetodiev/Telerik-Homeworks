namespace Points
{
    using System;
    using System.IO;

    public static class PathStorage
    {
        public static void SaveToFile(Path inputPath, string fileName)
        {
            StreamWriter writer = new StreamWriter(fileName + ".txt");
            using (writer)
            {
                foreach (var point in inputPath.Points)
                {
                    writer.WriteLine(point);
                }
            }
            writer.Close();
        }

        public static Path LoadFromFile(string fileName)
        {
            StreamReader reader = new StreamReader(fileName + ".txt");
            Path loadedPath = new Path();
            Point3D currentPoint3D = new Point3D();
            using (reader)
            {
                // Reading each point row by row and converting the read strings into Point3D.
                while (reader.EndOfStream == false)
                {
                    string[] separators = new string[]
                    {
                        "{{",
                        "}}",
                        "{",
                        "}",
                        ";"
                    };
                    string currentRow = reader.ReadLine();
                    string[] currentPoint = currentRow.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    currentPoint3D.X = decimal.Parse(currentPoint[0]);
                    currentPoint3D.Y = decimal.Parse(currentPoint[1]);
                    currentPoint3D.Z = decimal.Parse(currentPoint[2]);
                    loadedPath.AddPoint(currentPoint3D);
                }
            }
            reader.Close();
            return loadedPath;
        }
    }
}
