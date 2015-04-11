
// Write a program that finds the sequence of maximal sum in given array. Example:
//	{2, 3, -6, -1, 2, -1, 6, 4, -8, 8} -> {2, -1, 6, 4}
//	Can you do it with only one loop (with single scan through the elements of the array)?

using System;
using System.Collections.Generic;

class SequenceMaximumSum
{
    static void Main()
    {
        Console.Title = "Maximum sum of a subarray";

        Console.Write("Enter size of the array: ");
        string sizeString = Console.ReadLine();
        uint size;

        while (!uint.TryParse(sizeString, out size) || size == 0)
        {
            Console.Write("Enter positive size of the array: ");
            sizeString = Console.ReadLine();
        }

        int[] elements = new int[size];

        Console.WriteLine();

        for (int i = 0; i < elements.Length; i++)
        {
            Console.Write("Enter element at {0} position: ", i + 1);
            string elemetString = Console.ReadLine();

            while (!int.TryParse(elemetString, out elements[i]))
            {
                Console.Write("Enter valid integer at {0} position: ", i + 1);
                elemetString = Console.ReadLine();
            }
        }

        Console.WriteLine();

        int maxSum = elements[0];
        int currentSum = elements[0];
        int finalSequenceLength = 1;
        int currentSequnceLength = 1;
        int startIndex = 0;
        int tempStartIndex = 0;

        for (int i = 1; i < elements.Length; i++)
        {
            if (elements[i] + currentSum > elements[i])
            {
                currentSum = elements[i] + currentSum;
                currentSequnceLength++;
            }
            else
            {
                currentSum = elements[i];
                tempStartIndex = i;
                currentSequnceLength = 1;
            }

            if (currentSum > maxSum)
            {
                maxSum = currentSum;
                finalSequenceLength = currentSequnceLength;
                startIndex = tempStartIndex;
            }
        }

        Console.Write("{");
        Console.Write(string.Join(", ", elements));
        Console.Write("} -> {");

        for (int i = startIndex; i < (startIndex + finalSequenceLength) - 1; i++)
        {
            Console.Write("{0}, ", elements[i]);
        }

        Console.Write("{0}", elements[(startIndex + finalSequenceLength) - 1]);
        Console.WriteLine("}");
    }
}
