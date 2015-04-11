
// Write a program that reads two integer numbers N and K and an array of N elements from the console. 
// Find in the array those K elements that have maximal sum.

using System;

class MaximumSum
{
    static void Main()
    {
        Console.Title = "Find the maximum K elements of an array";

        Console.Write("Enter size of the array N = ");
        string sizeString = Console.ReadLine();
        uint size;

        while (!(uint.TryParse(sizeString, out size)) || size == 0)                             // Check if the entered data is valid
        {
            Console.Write("Enter size of the array(N > 0): ");
            sizeString = Console.ReadLine();
        }

        Console.WriteLine();

        int[] elements = new int[size];                                                         // Creating the array which will hold the numbers

        for (int i = 0; i < size; i++)                                                          // Loop for enetering the elements of the array
        {
            Console.Write("Enter element at position {0}: ", i + 1);
            string elementString = Console.ReadLine();

            while (!(int.TryParse(elementString, out elements[i])))                             // Check if the entered data is valid
            {
                Console.Write("Enter element at position {0}(valid integer): ", i + 1);
                elementString = Console.ReadLine();
            }
        }

        Array.Sort(elements);                                                                   // The sorting is done in order to have the greatest values at the end.

        Console.WriteLine();

        Console.Write("Enter the range of maximum sum elements, K = ");
        string rangeString = Console.ReadLine();
        uint range;

        while (!(uint.TryParse(rangeString, out range)) || range == 0 || range > size)          // Check if the entered data is valid
        {
            Console.Write("Enter the range of maximum sum elements, K(K > 0, K < {0}) = ", size);
            rangeString = Console.ReadLine();
        }

        int sum = 0;                                                                            // Holds the required sum

        Console.WriteLine();

        for (int i = elements.Length - 1; i > range; i--)                                       // Loop for the last K elements of the array
        {
            sum = sum + elements[i];
        }

        Console.WriteLine(sum);
    }
}
