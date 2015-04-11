
// Sorting an array means to arrange its elements in increasing order. Write a program to sort an array. 
// Use the "selection sort" algorithm: Find the smallest element, move it at the first position, 
// find the smallest from the rest, move it at the second position, etc.

using System;

class SelectionSort
{
    static void Main()
    {
        Console.Title = "Selection sort";

        Console.Write("Enter size of the array: ");
        string sizeString = Console.ReadLine();
        uint size;

        while (!(uint.TryParse(sizeString, out size)) || size == 0)                             // Check if the entered data is valid
        {
            Console.Write("Enter size of the array(> 0): ");
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

        int min;                                                                                // Holds the index of the current smallest element
        int temp;                                                                               // Temporary variable used for exchange of values

        for (int i = 0; i < size - 1; i++)                                                      // The loop is for the size - 1 element, because a comparison is made between the current and the next element
        {
            min = i;                                                                            // Everytime the smallest element is taken to be the current one

            for (int j = i + 1; j < size; j++)                                                  // Loop for checking the smalles element from the subset after the ith element
            {
                if (elements[j] < elements[min])                                                // Check if the nex element is greater than the previuos one
                {
                    min = j;                                                                    // If so, the next element is the smallest one
                }

            }
                temp = elements[i];                                                             // Exchange of values
                elements[i] = elements[min];
                elements[min] = temp;
        }

        Console.WriteLine();
        Console.Write("The array after sorting is: ");                                          // Printing of the sorted array
        Console.WriteLine(string.Join(", ", elements));
    }
}
