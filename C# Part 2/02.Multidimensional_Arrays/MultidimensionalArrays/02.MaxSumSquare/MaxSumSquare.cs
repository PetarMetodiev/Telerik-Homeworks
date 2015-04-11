
// Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements.

using System;

class MaxSumSquare
{
    static void Main()
    {
        Console.Title = "The maximum sum of a sub-matrix in a matrix";

        Console.Write("Enter number of rows of the sub-matrix: ");                              // Entering the sizes of the sub-matrix
        string rowsSubmatrixString = Console.ReadLine();
        int rowsSubmatrix;

        while (!int.TryParse(rowsSubmatrixString, out rowsSubmatrix) || rowsSubmatrix < 1)      // Checking if the entered data is valid
        {
            Console.Write("Enter number of rows of the sub-matrix(> 0):");
            rowsSubmatrixString = Console.ReadLine();
        }

        Console.Write("Enter number of columns of the sub-matrix: ");
        string colsSubmatrixString = Console.ReadLine();
        int colsSubmatrix;

        while (!int.TryParse(colsSubmatrixString, out colsSubmatrix) || colsSubmatrix < 1)
        {
            Console.Write("Enter number of cols of the sub-matrix(> 0):");
            colsSubmatrixString = Console.ReadLine();
        }

        Console.Write("Enter number of rows of the matrix, N = ");                              // Entering the sizes of the matrix
        string rowCountString = Console.ReadLine();
        int rowCount;

        while (!int.TryParse(rowCountString, out rowCount) || rowCount < rowsSubmatrix)         // Checking if the entered data is valid
        {
            Console.Write("Enter number of rows of the matrix(N => {0}), N = ", rowsSubmatrix);
            rowCountString = Console.ReadLine();
        }

        Console.Write("Enter number of columns of the matrix, M = ");
        string colCountString = Console.ReadLine();
        int colCount;

        while (!int.TryParse(colCountString, out colCount) || colCount < colsSubmatrix)
        {
            Console.Write("Enter number of columns of the matrix(M => {0}), M = ", colsSubmatrix);
            colCountString = Console.ReadLine();
        }

        int[,] matrix = new int[rowCount, colCount];                                            // Declaring the matrix

        Console.WriteLine();
        Console.WriteLine("Enter the elements of the matrix row by row.\nSeparate the elements of the same row by spaces, commas or tabulations.");
        Console.WriteLine("If you wish, you can enter each element on separate row.");          // Simple instructions for the user how to enter the elements of the matrix
        Console.WriteLine();

        for (int row = 0; row < matrix.GetLength(0); row++)                                     // Entering the elements of the matrix
        {                                                                                       // Following the procedure, explained in lectures
            string[] separators = new string[] { " ", "\t", ",", "\n" };                        // Very good explanation - http://youtu.be/Ih6p3w0xt8I?t=35m28s
            string currentRow = Console.ReadLine();
            string[] numbersAsStrings = currentRow.Split(separators, StringSplitOptions.RemoveEmptyEntries);    

            for (int col = 0; col < numbersAsStrings.Length; col++)
            {
                if (col < colCount)
                {
                    matrix[row, col] = int.Parse(numbersAsStrings[col]);
                }
            }
        }

        Console.WriteLine();

        int maxSum = int.MinValue;                                                              // Taking the inital maximal sum to be the minimum possible one, just in case there are negative numbers
        int currentSum = 0;                                                                     // Used to hold the sum for each sub-matrix with required sizes
        int maxSumRow = 0;                                                                      // Used to show the beginning of the obtained submatrix
        int maxSumCol = 0;

        for (int row = 0; row <= matrix.GetLength(0) - rowsSubmatrix; row++)                    // Loop for calculating the maximum sum
        {                                                                                       // The end condition for the first two loops is to continue until
            for (int col = 0; col <= matrix.GetLength(1) - rowsSubmatrix; col++)
            {
                for (int i = row; i < row + rowsSubmatrix; i++)                                 // Loops for checking the sum of every possible sub-matrix with the entered dimensions
                {                                                                               // The loops start from the current element and check the sum for the sub-matrix. The current element is the top left of the sub-matrix
                    for (int j = col; j < col + colsSubmatrix; j++)
                    {
                        currentSum = currentSum + matrix[i, j];                                 // Accumulating the current sum of the current sub-matrix
                        if (currentSum >= maxSum)                                               // Check if the current sum is greater than the maximum one
                        {
                            maxSum = currentSum;                                                // If the condition is met, the current sum becomes the maximum sum
                            maxSumRow = row;                                                    // The row and col of the top left element of the max sum sub-matrix are taken
                            maxSumCol = col;                                                    // Used for the printing. They serve as kind of flag to print the submatrix
                        }
                    }
                }
                currentSum = 0;                                                                 // After checking each sub-matrix, the sum is zeroed

            }
        }
        Console.WriteLine("Maximum sum of a sub-matrix with {0} rows and {1} columns is {2}",rowsSubmatrix,colsSubmatrix, maxSum);
        Console.WriteLine("The obtained submatrix is: ");                                       // Printing the maximum sum and the max-sum-sub-matrx

        for (int i = maxSumRow; i < rowsSubmatrix + maxSumRow; i++)
        {
            for (int j = maxSumCol; j < colsSubmatrix + maxSumCol; j++)
            {
                Console.Write(matrix[i,j] + " ");
            }
            Console.WriteLine();
        }
    }
}
