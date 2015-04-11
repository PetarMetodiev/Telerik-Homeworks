
// Write a method that counts how many times given number appears in given array. 
// Write a test program to check if the method is working correctly.

using System;

class CountNumber
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

    static int NumberInArrayCounter(int number, int[] array)                // Method to check how many times the required number is contained in the array
    {
        int count = 0;

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] == number)
            {
                count++;
            }
        }

        return count;
    }

    static void Main()
    {
        Console.Title = "Count number of times an integer appears in an array";

        Console.Write("Enter size of the array: ");
        string sizeString = Console.ReadLine();
        int size = Input(sizeString, true);                                 // Taking the size of the array

        int[] array = new int[size];                                        // Declaring the array

        Console.WriteLine();

        for (int i = 0; i < array.Length; i++)                              // Entering the elements of the array
        {
            Console.Write("Enter element at position {0}: ", i + 1);
            array[i] = Input(Console.ReadLine(), false);                    // Using the method to check if the entered element of the array is valid integer
        }

        Console.WriteLine();
        Console.Write("Enter the number you are looking for: ");
        string searchedNumberString = Console.ReadLine();
        int searchedNumber = Input(searchedNumberString, false);            // Converting the the entered number to int variable
        int counter = NumberInArrayCounter(searchedNumber, array);          // A varaible to contain the number of times the required element is contained in the array

        Console.WriteLine();
        if (counter == 0)                                                   // Simple condition statement so that the program prints what is approprate
        {
            Console.WriteLine("The number {0} does not appear in the array {1}", searchedNumber, string.Join(", ", array));
        }
        else if (counter == 1)
        {
            Console.WriteLine("The number {0} appears {1} time in the array {2}", searchedNumber, counter, string.Join(", ", array));
        }
        else
        {
            Console.WriteLine("The number {0} appears {1} times in the array {2}", searchedNumber, counter, string.Join(", ", array));
        }
        

    }
}
