
// 
using System;

class Matrices
{
    static void Main()
    {
        Console.Title = "Four matrices";

        Console.Write("Enter n: ");
        string nString = Console.ReadLine();
        uint n;

        while (!uint.TryParse(nString, out n) || n == 0)                                        // Check for valid input data
        {
            Console.Write("Enter valid value for n(n > 0):");
            nString = Console.ReadLine();
        }

        int[,] matrix = new int[n, n];                                                          // Declaring the array
        int counter = 1;                                                                        // Used to fill the matrix
        int i, j;

        for (i = 0; i < n; i++)                                                                 // Loop for filling the matrix
        {
            for (j = 0; j < n; j++)
            {
                matrix[i, j] = counter;
                counter++;
            }
        }
        Console.WriteLine();
        Console.WriteLine("Matrix type a): ");
        Console.WriteLine();

        for (i = 0; i < n; i++)                                                                 // Printing the first matrx
        {
            for (j = 0; j < n; j++)
            {
                Console.Write(matrix[j, i].ToString().PadRight(4));                             // For it it is enough to just swap the rows and coloumns
            }

            Console.WriteLine();
        }

        Console.WriteLine(new string('-', (int)n));                                             // Creating visual separator. Not the best choice, but I couldn't think of better one
        Console.WriteLine("Matrix type b): ");
        Console.WriteLine();

        for (i = 0; i < n; i++)                                                                 // Printing the second matrix
        {
            for (j = 0; j < n; j++)
            {
                if (j % 2 == 0)                                                                 // The idea is to check if the current coloumn is odd or even and depending on that to choose how to print
                {
                    Console.Write(matrix[j, i].ToString().PadRight(4));
                }

                if (j % 2 != 0)
                {
                    Console.Write(matrix[j, n - i - 1].ToString().PadRight(4));
                }
            }

            Console.WriteLine();
        }

        counter = 1;

        for (i = (int)n - 1; i >= -n + 1; i--)                                                  // Loop for creating matrix type C. The counter goes to negative values, because it can be viewed as a kind of sandwatch, which is flipped
        {
            if (i >= 0)
            {
                for (j = 0; j <= (int)n - i - 1; j++)
                {
                    matrix[i + j, j] = counter;
                    counter++;
                }
            }

            if (i < 0)                                                                          // Check if considering the top part of the "sand watch"
            {
                for (j = Math.Abs(i); j < n; j++)
                {
                    matrix[i + j, j] = counter;
                    counter++;
                }
            }
        }

        Console.WriteLine(new string('-', (int)n));
        Console.WriteLine("Matrix type c): ");
        Console.WriteLine();

        for (i = 0; i < n; i++)                                                                 // Printing matrix type C
        {
            for (j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j].ToString().PadRight(4));
            }

            Console.WriteLine();
        }


        Array.Clear(matrix, 0, (int)n * (int)n);                                                // Zeroing the matrix to prepare it for the algorithm

        int currentRow = 0;                                                                     // These are used, instead i and j to make it easier to understand, since this algorithm is a bit different
        int currentCol = 0;
        string direction = "down";                                                              // Used to store the "direction" of movement. Makes it easier to follow the algorithm

        for (i = 1; i <= n * n; i++)                                                            // Loop to add the new values to the matrix
        {
            if (direction == "down" && (currentRow == n - 1 || matrix[currentRow + 1, currentCol] != 0))    // Always check which is the direction and depending on that, change it to another direction
            {                                                                                               // The checks for n-1 or the currentRow+1 are done to determine if the current position is at the border of the matrix or near a 0
                direction = "right";
            }
            if (direction == "right" && (currentCol == n - 1 || matrix[currentRow, currentCol + 1] != 0))
            {
                direction = "up";
            }
            if (direction == "up" && (currentRow == 0 || matrix[currentRow - 1, currentCol] != 0))
            {
                direction = "left";
            }
            if (direction == "left" && (currentCol == 0 || matrix[currentRow, currentCol - 1] != 0))
            {
                direction = "down";
            }

            matrix[currentRow, currentCol] = i;                                                 // Adding value to the matrix

            if (direction == "down")                                                            // Instructions what to change for every direction
            {
                currentRow++;
            }
            if (direction == "right")
            {
                currentCol++;
            }
            if (direction == "up")
            {
                currentRow--;
            }
            if (direction == "left")
            {
                currentCol--;
            }
        }

        Console.WriteLine(new string('-', (int)n));
        Console.WriteLine("Matrix type d): ");
        Console.WriteLine();

        for (i = 0; i < n; i++)                                                                 // Printing matrix type D
        {
            for (j = 0; j < n; j++)
            {
                Console.Write(matrix[i, j].ToString().PadRight(4));
            }

            Console.WriteLine();
        }
    }
}