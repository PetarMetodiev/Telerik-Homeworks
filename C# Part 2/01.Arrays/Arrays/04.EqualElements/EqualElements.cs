
// Write a program that finds the maximal sequence of equal elements in an array.
// Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1} -> {2, 2, 2}.

using System;

class EqualElements
{
    static void Main()
    {
        Console.Title = "Maximal sequence of equal elements in an array";

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

        int maxCount = 1;                                                                       // Holds the maximum length of the required sequence. In the begining it is 1, because one number is a sequence
        int currentCount = 1;                                                                   // Counter for comparing to the maximum length of the sequence
        int repeatedElement = elements[0];                                                      // Holds the repeated element

        for (int i = 1; i < size; i++)                                                          // The loop starts from 1 because of the first itteration where elements[i] is compared to elements[i - 1]
        {
            if (elements[i] == elements[i - 1])                                                 // Check if two neighbouring elements are the same
            {
                currentCount++;                                                                 // If two elements are the same, then the counter increases

                if (currentCount > maxCount)                                                    // If the current sequence is bigger than the maximum one, then it becomes the maximum
                {
                    maxCount = currentCount;
                    repeatedElement = elements[i];                                              // Taking the repeated element
                }
            }

            if (elements[i] != elements[i - 1])                                                 // If two neighbouring elements are different, then the counter is returned to the initial position
            {
                currentCount = 1;
            }
        }

        Console.WriteLine();

        Console.Write("{");                                                                     // Writing the result
        for (int i = 0; i < size - 1; i++)
        {
            Console.Write("{0}, ", elements[i]);
        }

        Console.Write(elements[size - 1] + "}");

        if (maxCount == 1)                                                                      // Check if there has been a sequence
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("There is no sequence of two or more equal elements");
        }
        else
        {
            Console.Write(" -> {");

            for (int i = 0; i < maxCount - 1; i++)                                              // Printing the sequence
            {
                Console.Write("{0}, ", repeatedElement);
            }
            Console.WriteLine(repeatedElement + "}");
        }
    }
}
