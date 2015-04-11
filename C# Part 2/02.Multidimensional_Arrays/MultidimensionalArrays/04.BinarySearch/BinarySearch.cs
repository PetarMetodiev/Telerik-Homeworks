
// Write a program, that reads from the console an array of N integers and an integer K, 
// sorts the array and using the method Array.BinSearch() finds the largest number in the array which is ≤ K. 

using System;

class BinarySearch
{
    static void Main()
    {
        Console.Title = "Binary search";

        Console.Write("Enter size of the array, N = ");
        string sizeString = Console.ReadLine();
        int size;

        while (!int.TryParse(sizeString, out size) || size < 1)
        {
            Console.Write("Enter size of the array, N(N > 0) = ");
            sizeString = Console.ReadLine();
        }

        Console.WriteLine();

        int[] arr = new int[size];

        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write("Enter integer at position {0}: ", i + 1);
            string positionString = Console.ReadLine();

            while (!int.TryParse(positionString, out arr[i]))
            {
                Console.Write("Enter valid integer at position {0}: ", i + 1);
                positionString = Console.ReadLine();
            }
        }

        Console.Write("Enter K = ");
        string kString = Console.ReadLine();
        int k;

        while (!int.TryParse(kString, out k))
        {
            Console.Write("Enter valid integer for K, K = ");
            kString = Console.ReadLine();
        }

        Array.Sort(arr);

        int index = Array.BinarySearch(arr, k);

        if (arr[0] > k)
        {
            Console.WriteLine("There is no integer smaller or equal to K = {0}.", k);
        }
        else
        {
            if (index >= 0)
            {
                Console.WriteLine("The number is {0}.", arr[index]);
            }
            else
            {
                Console.WriteLine("The number is {0}.", arr[-index - 2]);
            }
        }
    }
}
