
// Write a method that checks if the element at given position in given array of integers is bigger than its two neighbors (when such exist).

using System;

class BiggerThanNeighbours
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

    static void IsBiggerThanNeighbours(int[] array, int position)           // Method for carrying out the comaprison between the numbers
    {                                                                       // Filled with borring and probably unoptimised code
        if (position >= array.Length || position < 0)
        {
            Console.WriteLine("The enetered position is out of the array's range.");
        }
        else
        {
            if (position == 0)
            {
                if (array[0] > array[1])
                {
                    Console.WriteLine("The element at position 0({0}) is greater than the element at position 1({1})", array[0], array[1]);
                }
                else if (array[0] == array[1])
                {
                    Console.WriteLine("The element at position 0({0}) is equal to the element at position 1({1})", array[0], array[1]);
                }
                else
                {
                    Console.WriteLine("The element at position 0({0}) is smaller than the element at position 1({1})", array[0], array[1]);
                }
            }
            else if (position == array.Length - 1)
            {
                if (array[position] > array[position - 1])
                {
                    Console.WriteLine("The element at position {0}({1}) is greater than the element at position {2}({3})", position, array[position], position - 1, array[position - 1]);
                }
                else if (array[position] == array[position - 1])
                {
                    Console.WriteLine("The element at position {0}({1}) is equal to the element at position {2}({3})", position, array[position], position - 1, array[position - 1]);
                }
                else
                {
                    Console.WriteLine("The element at position {0}({1}) is smaller than the element at position {2}({3})", position, array[position], position - 1, array[position - 1]);
                }
            }
            else
            {
                if (array[position] > array[position - 1] && array[position] > array[position + 1])
                {
                    Console.WriteLine("The element at position {0}({1}) is greater than the elements at positions {2}({3}) and {4}({5})", position, array[position], position - 1, array[position - 1], position + 1, array[position + 1]);
                }
                else if (array[position] > array[position - 1] && array[position] < array[position + 1])
                {
                    Console.WriteLine("The element at position {0}({1}) is greater than the element at position {2}({3}) and smaller than the element at position {4}({5})", position, array[position], position - 1, array[position - 1], position + 1, array[position + 1]);
                }
                else if (array[position] < array[position - 1] && array[position] > array[position + 1])
                {
                    Console.WriteLine("The element at position {0}({1}) is smaller than the element at position {2}({3}) and greater than the element at position {4}({5})", position, array[position], position - 1, array[position - 1], position + 1, array[position + 1]);
                }
                else if (array[position] < array[position - 1] && array[position] < array[position + 1])
                {
                    Console.WriteLine("The element at position {0}({1}) is smaller than the elements at positions {2}({3}) and {4}({5})", position, array[position], position - 1, array[position - 1], position + 1, array[position + 1]);
                }
                else if (array[position] == array[position - 1])
                {
                    if (array[position] > array[position + 1])
                    {
                        Console.WriteLine("The element at position {0}({1}) is equal to the element at position {2}({3}) and greater than the element at position {4}({5})", position, array[position], position - 1, array[position - 1], position + 1, array[position + 1]);
                    }
                    else if (array[position] < array[position + 1])
                    {
                        Console.WriteLine("The element at position {0}({1}) is equal to the element at position {2}({3}) and smaller than the element at position {4}({5})", position, array[position], position - 1, array[position - 1], position + 1, array[position + 1]);
                    }
                    else if (array[position] == array[position + 1])
                    {
                        Console.WriteLine("The element at position {0}({1}) is equal to the elements at positions {2}({3}) and {4}({5})", position, array[position], position - 1, array[position - 1], position + 1, array[position + 1]);
                    }
                }
                else if (array[position] == array[position + 1])
                {
                    if (array[position] > array[position - 1])
                    {
                        Console.WriteLine("The element at position {0}({1}) is greater than the element at position {2}({3}) and equal to the element at position {4}({5})", position, array[position], position - 1, array[position - 1], position + 1, array[position + 1]);
                    }
                    else if (array[position] < array[position - 1])
                    {
                        Console.WriteLine("The element at position {0}({1}) is smaller than the element at position {2}({3}) and equal to the element at position {4}({5})", position, array[position], position - 1, array[position - 1], position + 1, array[position + 1]);
                    }
                    else
                    {
                        Console.WriteLine("The element at position {0}({1}) is equal to the elements at positions {2}({3}) and {4}({5})", position, array[position], position - 1, array[position - 1], position + 1, array[position + 1]);
                    }
                }
            }
        }

    }

    static void Main()
    {
        Console.Title = "Check if a number at position is greater than its neighbours";

        Console.Write("Enter size of the array: ");
        int size = Input(Console.ReadLine(), true);

        Console.WriteLine();

        int[] array = new int[size];

        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("Enter element at position {0}: ", i);
            array[i] = Input(Console.ReadLine(), false);
        }

        Console.WriteLine();

        Console.Write("Enter desired position: ");
        int position = Input(Console.ReadLine(), false);
        Console.WriteLine();

        IsBiggerThanNeighbours(array, position);
    }
}