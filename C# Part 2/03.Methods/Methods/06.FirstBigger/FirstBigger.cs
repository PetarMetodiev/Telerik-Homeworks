
// Write a method that returns the index of the first element in array that is bigger than its neighbors, or -1, if there’s no such element.

using System;

class FirstBigger
{
    static int Input(string numberString, bool isSize)                      // Method for checking and converting the input data. It is used for all input data - size of the array(>0), elements of the array and searched number(any integer)
    {                                                                       // the isSize variable is used as a flag if the processed number is size of the array(only integers greater than 0) or not
        int number;
        if (isSize == true)                                                 // If the requred number is size of the array
        {
            while (!int.TryParse(numberString, out number) || number < 1)   // The number has to be a valid positive integer
            {
                Console.Write("Enter valid positive integer: ");
                numberString = Console.ReadLine();
            }
        }
        else                                                                // The case where only a valid integer is needed
        {
            while (!int.TryParse(numberString, out number))
            {
                Console.Write("Enter valid integer: ");
                numberString = Console.ReadLine();
            }
        }

        return number;

    }

    static int[] CreateArray(int size)                                      // Method for creating the array
    {
        Console.WriteLine();

        int[] array = new int[size];
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("Enter element at position {0}: ", i);
            array[i] = Input(Console.ReadLine(), false);
        }

        return array;
    }

    static int FirstBiggerThanNeighbours(int[] array)                       // Method for checking if there is an element which is greater than its neighbours
    {
        Console.WriteLine();

        for (int i = 1; i < array.Length - 1; i++)
        {
            if (array[i] > array[i - 1] && array[i] > array[i + 1])
            {
                return i;
            }
        }
        return -1;                                                          // Only if there is no element that meets the requirement, the method returns -1
    }

    static void Main()
    {
        Console.Title = "Return the index of the first bigger neighbour";

        Console.Write("Enter size of the array: ");
        int size = Input(Console.ReadLine(), true);

        int[] array = CreateArray(size);

        int index = FirstBiggerThanNeighbours(array);

        if (index == -1)                                                    // Printing the final result
        {
            Console.WriteLine("There is no element meeting the requirement.");
        }
        else
        {
            Console.WriteLine("The element at position {0}({1}) is greater than its neighbours.", index, array[index]);
        }


    }
}