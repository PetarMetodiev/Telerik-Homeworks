
// Write a program that reads two arrays from the console and compares them element by element.

using System;

class TwoArrays
{
    static void Main()
    {
        Console.Title = "Compare the arrays";

        Console.Write("Enter size of arrays: ");
        string sizeString = Console.ReadLine();
        uint size;

        while (!uint.TryParse(sizeString, out size) || size == 0)                                   // Check if the entered data is valid
        {
            Console.Write("Enter size of arrays: ");
            sizeString = Console.ReadLine();
        }

        int[] array1 = new int[size];
        int[] array2 = new int[size];

        for (int i = 0; i < size; i++)                                                              // Loop for entering the first array
        {
            Console.Write("Enter element at position {0} of the first array: ", i + 1);
            string array1String = Console.ReadLine();

            while (!int.TryParse(array1String, out array1[i]))                                      // Everytime a check for the input data is done
            {
                Console.Write("Enter element at position {0} of the first array: ", i + 1);
                array1String = Console.ReadLine();
            }
        }

        Console.WriteLine();

        for (int i = 0; i < size; i++)                                                              // Loop for entering the second array
        {
            Console.Write("Enter element at position {0} of the second array: ", i + 1);
            string array2String = Console.ReadLine();

            while (!int.TryParse(array2String, out array2[i]))                                      // Check for the input data
            {
                Console.Write("Enter element at position {0} of the second array: ", i + 1);
                array2String = Console.ReadLine();
            }
        }

        Console.WriteLine();

        for (int i = 0; i < size; i++)                                                              // Loop for comaprison between the elements of the two arrays
        {
            if (array1[i] == array2[i])
            {
                Console.WriteLine("{0} = {1}", array1[i], array2[i]);
            }
            else
            {
                Console.WriteLine("{0} != {1}", array1[i], array2[i]);
            }
        }
    }
}