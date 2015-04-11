
// Write a program that finds in given array of integers a sequence of given sum S (if present). 
// Example:	 {4, 3, 1, 4, 2, 5, 8}, S=11 -> {4, 2, 5}
using System;
using System.Collections.Generic;

class SequenceOfSum
{
    static void Main()
    {
        Console.Title = "Sequence of given sum";

        Console.Write("Enter size of the array: ");
        string sizeString = Console.ReadLine();
        uint size;

        while (!uint.TryParse(sizeString, out size) || size == 0)
        {
            Console.Write("Enter valid size of the array: ");
            sizeString = Console.ReadLine();
        }

        Console.Write("Enter the required sum to be found: ");
        string sumString = Console.ReadLine();
        int sum;

        while (!int.TryParse(sumString, out sum))
        {
            Console.Write("Enter the required sum to be found(valid integer): ");
            sumString = Console.ReadLine();
        }

        int[] elements = new int[size];

        for (int i = 0; i < elements.Length; i++)
        {
            Console.Write("Enter element position {0}: ", i + 1);
            string elementString = Console.ReadLine();

            while (!int.TryParse(elementString, out elements[i]))
            {
                Console.Write("Enter valind integer at position {0}: ", i + 1);
                elementString = Console.ReadLine();
            }
        }

        int currentSum = 0;
        int startElement = 0;
        int printStart = 0;
        int printEnd = 0;

        for (int i = 0; i < elements.Length; i++)
        {
            currentSum += elements[i];

            if (currentSum == sum)
            {
                printStart = startElement;
                printEnd = i;
                break;
            }

            if (i == elements.Length - 1)
            {
                currentSum = 0;
                startElement++;

                if (startElement == elements.Length)
                {
                    break;
                }

                i = startElement - 1;
            }
        }

        if (sum != currentSum)
        {
            Console.WriteLine("There is no such sum in the array.");
            return;
        }

        for (int i = printStart; i <= printEnd; i++)
        {
            Console.Write("{0} ", elements[i]);
        }

        Console.WriteLine();
    }
}