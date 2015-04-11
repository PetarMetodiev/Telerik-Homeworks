
// Write a program that reads a text file containing a square matrix of numbers and finds 
// in the matrix an area of size 2 x 2 with a maximal sum of its elements. 
// The first line in the input file contains the size of matrix N. 
// Each of the next N lines contain N numbers separated by space. 
// The output should be a single number in a separate text file. 
using System;
using System.IO;

class Matrix
{
    static void Main()
    {
        Console.Title = "Look for a matrix in the matrix";

        string matrixFileRead = @"..\..\text-files\matrix.txt";
        string matrixFileWrite = @"..\..\text-files\matrixOutput.txt";

        // Creating the reader and writer.
        StreamReader reader = new StreamReader(matrixFileRead);
        StreamWriter writer = new StreamWriter(matrixFileWrite);

        using (reader)
        {
            string line = reader.ReadLine();
            // Taking the size of the matrix
            int size = int.Parse(line);
            int[,] matrix = new int[size, size];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                // Taking the elemets from each row, using separators.
                string[] separators = new string[] { " " };
                string currentRow = reader.ReadLine();
                string[] numbersAsString = currentRow.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = int.Parse(numbersAsString[col]);
                }
            }

            int maxSum = int.MinValue;
            int currentSum = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {

                    // Loop for calculating the sum of each submatrix.
                    for (int i = row; i < row + 2; i++)
                    {
                        for (int j = col; j < col + 2; j++)
                        {
                            currentSum += matrix[i, j];

                            if (currentSum >= maxSum)
                            {
                                maxSum = currentSum;
                            }
                        }
                    }

                    currentSum = 0;
                }
            }

            // Writting the final result to a file.
            using (writer)
            {
                writer.WriteLine(maxSum);
            }
        }

        Console.WriteLine("Done!");
    }
}