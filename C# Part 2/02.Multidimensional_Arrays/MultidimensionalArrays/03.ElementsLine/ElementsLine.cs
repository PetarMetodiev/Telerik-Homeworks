
// We are given a matrix of strings of size N x M. Sequences in the matrix we define as sets of several neighbor elements located 
// on the same line, column or diagonal. Write a program that finds the longest sequence of equal strings in the matrix. 

using System;

class ElementsLine
{
    static void Main()
    {
        Console.Title = "Sequence in the matrix";

        string rowsCountString;
        int rowsCount;

        do
        {
            Console.Write("Enter number of rows, N = ");
            rowsCountString = Console.ReadLine();
        } while (!int.TryParse(rowsCountString, out rowsCount) || rowsCount < 1);

        string colsCountString;
        int colsCount;

        do
        {
            Console.Write("Enter number of columns, M = ");
            colsCountString = Console.ReadLine();
        } while (!int.TryParse(colsCountString, out colsCount) || colsCount < 1);

        string[,] matrix = new string[rowsCount, colsCount];

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                matrix[row, col] = "";
            }
        }

        Console.WriteLine();
        Console.WriteLine("Enter the elements row by row. Separate them by space or comma.");
        Console.WriteLine();

        int maxLengthElement = 0;                                                               // Used for the alignment of the matrix when it is being printed

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            string[] separators = new string[] { " ", "\t", ",", "\n" };
            string currentRow = Console.ReadLine();
            string[] rowElements = currentRow.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            for (int col = 0; col < rowElements.Length; col++)
            {
                if (col < colsCount)
                {
                    matrix[row, col] = rowElements[col];
                    if (maxLengthElement < matrix[row, col].Length)
                    {
                        maxLengthElement = matrix[row, col].Length;
                    }
                }
            }
        }


        int currentCount = 1;
        int maxCount = 1;
        string repeatedString = "";

        for (int row = 0; row < matrix.GetLength(0); row++)                                     // Check rows
        {
            for (int col = 0; col < matrix.GetLength(1) - 1; col++)
            {
                if (matrix[row, col] == matrix[row, col + 1])
                {
                    currentCount++;
                    if (currentCount >= maxCount)
                    {
                        maxCount = currentCount;
                        repeatedString = matrix[row, col];
                    }
                }
            }
            currentCount = 1;
        }

        for (int col = 0; col < matrix.GetLength(1); col++)                                     // Check cols
        {
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                if (matrix[row, col] == matrix[row + 1, col])
                {
                    currentCount++;
                    if (currentCount >= maxCount)
                    {
                        maxCount = currentCount;
                        repeatedString = matrix[row, col];
                    }
                }
            }
            currentCount = 1;
        }

        int minDimension = Math.Min(matrix.GetLength(0), matrix.GetLength(1));

        for (int row = 0; row < matrix.GetLength(0); row++)                                     
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                for (int i = 1; i < minDimension; i++)                                          // Check main diagonals. The loop goes until the smaller dimension of the array.
                {
                    if (row + i < matrix.GetLength(0) && col + i < matrix.GetLength(1))         // Check if the next element is within the boundary of the array
                    {
                        if (matrix[row, col] == matrix[row + i, col + i])                       // Comparison of the current and next element
                        {
                            currentCount++;

                            if (currentCount >= maxCount)
                            {
                                maxCount = currentCount;
                                repeatedString = matrix[row, col];
                            }
                        }
                    }
                }

                currentCount = 1;

                for (int i = 1; i < minDimension; i++)                                      // Check secondary diagonals
                {
                    if (row - 1 >= 0 && col + i < matrix.GetLength(1))
                    {
                        if (matrix[row, col] == matrix[row - 1, col + 1])
                        {
                            currentCount++;

                            if (currentCount >= maxCount)
                            {
                                maxCount = currentCount;
                                repeatedString = matrix[row, col];
                            }
                        }
                    }
                }

                currentCount = 1;
            }
        }

        Console.WriteLine();

        for (int row = 0; row < matrix.GetLength(0); row++)                                     // Printing the matrix so it looks better if strings with different length are added
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col].PadRight((maxLengthElement + 1), ' '));
            }
            Console.WriteLine();
        }

        Console.WriteLine();

        if (repeatedString == "")                                                               // Check if a sequence is present
        {
            Console.WriteLine("No sequence found.");
        }
        else
        {
            Console.WriteLine("Max repeated element: {0}({1} times)", repeatedString, maxCount);
        }

    }
}