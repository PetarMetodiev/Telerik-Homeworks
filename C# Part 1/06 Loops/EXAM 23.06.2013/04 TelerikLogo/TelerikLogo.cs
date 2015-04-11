using System;

class Telerik
{
    static void Main()
    {
        // initialization
        int X = int.Parse(Console.ReadLine());
        int Y = X;
        int Z = (X / 2) + 1;

        int width = (2 * X + 2 * Z) - 3;
        int height = width;

        int[,] matrix = new int[width, width];

        // solution - filling the path with ones (1)

        int currentRow = X / 2;
        int currentCol = 0;

        while (true)
        {
            matrix[currentRow, currentCol] = 1;

            currentRow--;
            currentCol++;

            if (currentRow < 0)
            {
                currentRow++;
                currentCol--;
                break;
            }
        }

        while (true)
        {
            matrix[currentRow, currentCol] = 1;

            currentRow++;
            currentCol++;

            if (currentRow == 2 * X - 1)
            {
                currentRow--;
                currentCol--;
                break;
            }
        }

        while (true)
        {
            matrix[currentRow, currentCol] = 1;

            currentRow++;
            currentCol--;

            if (currentRow == width)
            {
                currentRow--;
                currentCol++;
                break;
            }
        }

        while (true)
        {
            matrix[currentRow, currentCol] = 1;

            currentRow--;
            currentCol--;

            if (currentCol == X / 2 - 1)
            {
                currentRow++;
                currentCol++;
                break;
            }
        }

        while (true)
        {
            matrix[currentRow, currentCol] = 1;

            currentRow--;
            currentCol++;

            if (currentRow < 0)
            {
                currentRow++;
                currentCol--;
                break;
            }
        }

        while (true)
        {
            matrix[currentRow, currentCol] = 1;

            currentRow++;
            currentCol++;

            if (currentCol == width)
            {
                break;
            }
        }

        // printing
        for (int row = 0; row < width; row++)
        {
            for (int col = 0; col < width; col++)
            {
                if (matrix[row, col] == 0)
                {
                    Console.Write('.');
                }
                else if (matrix[row, col] == 1)
                {
                    Console.Write('*');
                }
            }

            Console.WriteLine();
        }
    }
}