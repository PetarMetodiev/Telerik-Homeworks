
// You are given an array of strings. Write a method that sorts the array by the length of its elements 
// (the number of characters composing them).

using System;
using System.Collections;

class StringLengthComparison
{
    class StringLengthComparer : IComparer
    {
        public int Compare(object a, object b)
        {
            if (a.ToString().Length != b.ToString().Length)
            {
                return a.ToString().Length.CompareTo(b.ToString().Length);
            }
            else
            {
                return a.ToString().CompareTo(b.ToString());
            }
        }
    }

    static void Main()
    {
        Console.Title = "Sort arrays of strings by their length";

        Console.Write("Enter size of the array: ");
        string sizeString = Console.ReadLine();
        int size;

        while (!int.TryParse(sizeString, out size) || size < 1)
        {
            Console.Write("Enter valid value(> 0) for the size of the array: ");
            sizeString = Console.ReadLine();
        }

        string[] arr = new string[size];

        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("Enter string at position {0}: ", i + 1);
            arr[i] = Console.ReadLine();
        }

        Array.Sort(arr,new StringLengthComparer());

        Console.WriteLine(string.Join(", ", arr));
    }
}