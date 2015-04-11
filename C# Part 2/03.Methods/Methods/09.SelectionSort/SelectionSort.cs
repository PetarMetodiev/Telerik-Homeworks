using System;

class SelectionSort
{
    static int Input(string numberString, bool isSize)
    {
        int number;
        if (isSize == true)
        {
            while (!int.TryParse(numberString, out number) || number < 1)
            {
                Console.Write("Enter valid positive integer: ");
                numberString = Console.ReadLine();
            }
        }
        else
        {
            while (!int.TryParse(numberString, out number))
            {
                Console.Write("Enter valid integer: ");
                numberString = Console.ReadLine();
            }
        }

        return number;
    }

    static int FindBiggest(int startIndex, int endIndex, int[] arr)
    {
        int biggest = int.MinValue;
        int indexOfBiggest = 0;
        for (int i = startIndex; i < endIndex; i++)
        {
            if (arr[i] > biggest)
            {
                biggest = arr[i];
                indexOfBiggest = i;
            }
        }
        return indexOfBiggest;
    }

    static int[] SwapElements(int[] arr, int firstElement, int secondElement)
    {
        int temp = arr[firstElement];
        arr[firstElement] = arr[secondElement];
        arr[secondElement] = temp;
        return arr;
    }

    static int[] SelectionSortMethod(int[] arr, bool ascend)
    {
        if (ascend == true)
        {
            for (int i = arr.Length - 1; i > 0; i--)
            {
                int indexOfBiggest = FindBiggest(0, i, arr);

                if (arr[indexOfBiggest] > arr[i])
                {
                    SwapElements(arr, i, indexOfBiggest);
                }
            }
        }
        else
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                int indexOfBiggest = FindBiggest(i + 1, arr.Length, arr);

                if (arr[indexOfBiggest] > arr[i])
                {
                    SwapElements(arr, i, indexOfBiggest);
                }
            }
        }

        return arr;
    }

    static void Main()
    {
        Console.Title = "Selection Sort";
        Console.Write("Enter size of the array: ");
        string sizeString = Console.ReadLine();
        int size = Input(sizeString, true);

        int[] array = new int[size];

        Console.WriteLine();

        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("Enter element at position {0}: ", i + 1);
            array[i] = Input(Console.ReadLine(), false);
        }

        Console.WriteLine();
        bool ascend = true;
        Console.WriteLine("The array after ascending sorting:\n{0}", string.Join(", ", SelectionSortMethod(array, ascend)));

        bool descend = false;
        Console.WriteLine("The array after descending sorting:\n{0}", string.Join(", ", SelectionSortMethod(array, descend)));
    }
}