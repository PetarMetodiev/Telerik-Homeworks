
// We are given 5 integer numbers. Write a program that checks if the sum of some subset of them is 0. 
// Example: 3, -2, 1, 1, 8 => 1+1-2=0.

using System;

class IsItZero
{
    static void Main()
    {
        Console.Title = "Subset of numbers divisible to 0";

        Console.Write("Enter how many elements would you like to enter: ");
        string elementsString = Console.ReadLine();
        uint elements;

        while ((!(uint.TryParse(elementsString, out elements))) || elements == 0)
        {
            Console.Write("Enter how many elements would you like to enter(positive integer): ");
            elementsString = Console.ReadLine();
        }

        double[] numbers = new double[elements];
        string[] numbersString = new string[elements];

        Console.WriteLine();                                                    // New line to make the program more pleasent to view.

        for (int i = 0; i < elements; i++)                                      // Loop for entering the elements of the array.
        {
            Console.Write("Enter number at position {0}: ", i + 1);
            numbersString[i] = Console.ReadLine();

            while (!(double.TryParse(numbersString[i], out numbers[i])))        // Check of the input data.
            {
                Console.Write("Enter number at position {0}: ", i + 1);
                numbersString[i] = Console.ReadLine();
            }
        }

        bool isSubset = false;                                                  // By default there is no 0 subset.

        double sum;                                                             // Variable to hold the sum of the numbers.

        for (int i = 0; i < elements; i++)                                      // Loop to walk through the array numbers[].
        {
            sum = numbers[i];                                                   // The inital sum is the first element of the current iteration.

            for (int k = i + 1; k < elements; k++)                              // Loop to walk through the array numbers[], starting from the i-th element. For example the array is composed of 10 elements, and the current position is 3. This loop tries to sum only numbers after element number 3.
            {
                sum = sum + numbers[k];                                         // Summation of the numbers after i-th element.

                if (sum == 0)                                                   // Check if the sum is 0.
                {
                    Console.WriteLine();                                        // New line to make the program look better.
                    for (int m = i; m < k; m++)
                    {
                        Console.Write("{0} + ", numbers[m]);                    // Writing the expression.
                    }
                    Console.WriteLine("{0} = 0", numbers[k]);                   // The final element of the summation and = 0 have to be outside the previuos loop, in order for the expression to look properly.
                    isSubset = true;                                            // Check if there is a zero subset.
                    break;                                                      // If there is a zero subset, the current loop is no longer needed.
                }
            }
        }
        if (!isSubset)                                                          // Check if there is no zero subset
        {
            Console.WriteLine();
            Console.WriteLine("No zero subset");
        }
    }
}