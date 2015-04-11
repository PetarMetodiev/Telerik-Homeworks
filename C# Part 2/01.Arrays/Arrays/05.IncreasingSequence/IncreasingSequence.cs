
//Write a program that finds the maximal increasing sequence in an array. Example: {3, 2, 3, 4, 2, 2, 4} -> {2, 3, 4}.

using System;
using System.Collections.Generic;

class IncreasingSequence
{
    static void Main()
    {
        Console.Title = "Increasing sequence of an array";

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
        int maxElement = elements[0];                                                           // Holds the repeated element
        int lastElementPosition = 0;                                                            // This is used for the creation of the list. It holds the end point where the sequence starts

        List<int> increasingSequence = new List<int>();                                         // List to contain the new sequence

        for (int i = 1; i < size; i++)                                                          // The loop starts from 1 because of the first itteration where elements[i] is compared to elements[i - 1]
        {
            if (elements[i] > elements[i - 1])                                                  // Check if the next number is greater than the previuos one
            {
                currentCount++;                                                                 // If the requirement is met, then the counter increases

                if (currentCount > maxCount)                                                    // If the current sequence is bigger than the maximum one, then it becomes the maximum
                {
                    maxCount = currentCount;
                    lastElementPosition = i;
                }
            }

            if (elements[i] <= elements[i - 1])                                                 // If  the next number is smaller or equal to the previuos one, then the counter is returned to the initial position
            {
                currentCount = 1;
            }
        }

        int firstElementPosition = lastElementPosition - maxCount;                              // This holds the start point of the sequence in the array

        for (int i = firstElementPosition + 1; i <= lastElementPosition; i++)                   // Assigning the sequence to the list. The idea is that when the sequence is found, it is just extracted and added to the list
        {
            increasingSequence.Add(elements[i]);
        }

        Console.WriteLine();

        Console.Write("{");                                                                     // Writing the result
        Console.Write(string.Join(", ", elements));
        Console.Write("} ");

        if (maxCount == 1)                                                                      // Check if there has been a sequence
        {
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("There is no sequence of increasing elements");
        }
        else
        {
            Console.Write(" -> {");
            Console.Write(string.Join(", ", increasingSequence));
            Console.WriteLine("}");
        }
    }
}
