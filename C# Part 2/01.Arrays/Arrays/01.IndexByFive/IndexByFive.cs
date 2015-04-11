
// Write a program that allocates array of 20 integers and initializes each element by its index multiplied by 5. 
// Print the obtained array on the console.

using System;

class IndexByFive
{
    static void Main()
    {
        Console.Title = "The 20 integer array";

        int[] array = new int[20];

        for (int i = 0; i < 20; i++)
        {
            array[i] = i * 5;
        }

        for (int i = 0; i < 20; i++)
        {
            Console.WriteLine(array[i]);            // The inital element is zero, because the arrays are zero based. Hence the first index is 0
        }
    }
}