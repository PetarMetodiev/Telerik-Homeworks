
// Write a program that reads from the console a positive integer number N (N < 20) and outputs a matrix 
using System;

class Matrix
{
    static void Main()
    {
        Console.Title = "Create the matrix";

        Console.Write("Enter number, N = ");
        string numString = Console.ReadLine();
        byte num;

        while (!(byte.TryParse(numString, out num)) || num ==0 || num >= 20)
        {
            Console.Write("Enter number, N(0 < N < 20) = ");
            numString = Console.ReadLine();
        }

        int[,] matrix = new int[num, num];                                      // Creating two dimensional array to store the matrix
        int counter = 1;

        for (int i = 0; i < num; i++)                                           // Creating the array
		{
            for (int j = 0; j < num; j++)
            {
                matrix[i, j] = counter++;
            }
            counter = i + 2;                                                    // Restarting the counter, giving it a new value

		}

        for (int i = 0; i < num; i++)
        {
            for (int j = 0; j < num; j++)
            {
                Console.Write(Convert.ToString(matrix[i,j]).PadLeft(3, ' '));
            }
            Console.WriteLine();
        }
    }
}