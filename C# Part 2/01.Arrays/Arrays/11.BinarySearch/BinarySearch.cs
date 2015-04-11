
// Write a program that finds the index of given element in a sorted array of integers by using the binary search algorithm.

using System;
using System.Collections.Generic;

class BinarySearch
{
    static void Main()
    {
        Console.Title = "Binary Search";

        Console.Write("Enter size of the array: ");
        string sizeString = Console.ReadLine();
        uint size;

        while (!uint.TryParse(sizeString, out size) || size == 0)
        {
            Console.Write("Enter valid size of the array: ");
            sizeString = Console.ReadLine();
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

        Array.Sort(elements);

        Console.Write("The array after sorting: ");
        Console.WriteLine(string.Join(", ", elements));

        Console.Write("Enter desired element: ");
        string numberString = Console.ReadLine();
        uint number;

        while (!uint.TryParse(numberString, out number))
        {
            Console.Write("Enter desired element(positive integer): ");
            numberString = Console.ReadLine();
        }

        int start = 0;
        int end = elements.Length - 1;
        int middle;

        while (start <= end)
        {
            middle = (start + end) / 2;

            if (elements[middle] == number)
            {
                Console.WriteLine("The index is {0}", middle + 1);
                break;
            }

            if (elements[middle] < number)
            {
                start = middle + 1;
            }

            if (elements[middle] > number)
            {
                end = middle - 1;
            }
        }
    }
}