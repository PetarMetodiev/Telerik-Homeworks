
// Write a program that finds the most frequent number in an array. Example:
// {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3} -> 4 (5 times)

using System;
using System.Collections.Generic;

class FrequentNumber
{
    static void Main()
    {
        Console.Title = "Most frequent number in a sequence";

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

        List<int> mostFreqNum = new List<int>();
        mostFreqNum.Add(elements[0]);
        int freqNum = elements[0];
        int maxRepeat = 1;
        int currentRepeat = 1;

        for (int i = 1; i < elements.Length; i++)
        {
            if (elements[i] == freqNum)
            {
                currentRepeat++;
            }
            else
            {
                freqNum = elements[i];
                currentRepeat = 1;
            }

            if (currentRepeat > maxRepeat)
            {
                maxRepeat = currentRepeat;
                mostFreqNum.Clear();
                mostFreqNum.Add(elements[i]);
            }
            else if (currentRepeat == maxRepeat)
            {
                mostFreqNum.Add(elements[i]);
            }
        }

        if (mostFreqNum.Count == 1)
        {
            Console.WriteLine("Most frequent number in the array is {0}({1} times)", mostFreqNum[0], maxRepeat);
        }
        else
        {
            Console.Write("Most frequent numbers: ");
            for (int i = 0; i < mostFreqNum.Count; i++)
            {
                if (i == mostFreqNum.Count - 1)
                {
                    Console.WriteLine(", {0}({1} times)", mostFreqNum[i], maxRepeat);
                }

                Console.Write("{0}", mostFreqNum[i]);

                if (i < mostFreqNum.Count - 2)
                {
                    Console.Write(", ");
                }
            }
        }
    }
}