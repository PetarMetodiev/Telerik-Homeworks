
// Write a program that compares two char arrays lexicographically (letter by letter).

using System;

class LexicographicalComaprison
{
    static void Main()
    {
        Console.Title = "Compare two char arrays lexicographically";

        Console.Write("Enter first array: ");                                                       // A string variable i actually an array of chars
        string firstArray = Console.ReadLine();                                                     // Getting the first array of chars

        Console.Write("Enter second array: ");
        string secondArray = Console.ReadLine();                                                    // Getting the second array of chars

        if (firstArray.Length < secondArray.Length)                                                 // If the first array is shorter, then it is deffinately before the second
        {
            Console.WriteLine("The first array is lexicographically before the second");
        }
        else if (firstArray.Length > secondArray.Length)                                            // The same check, just the other way around
        {
            Console.WriteLine("The second array is lexicographically before the first");
        }
        else
        {
            int earlier = 0;                                                                        // Flag to show which array is earlier
            int length = firstArray.Length;                                                        // Taking the minimum length of the two arrays. This is done to prevent exceptions
            for (int i = 0; i < length; i++)                                                        // Loop to check which array is earlier
            {
                if (firstArray[i] < secondArray[i])
                {
                    earlier = 1;                                                                    // If the first array is earlier, the flag is equal to 1
                    break;                                                                          // If there is a difference between the arrays, no more loops are required
                }
                else if (firstArray[i] > secondArray[i])                                            // Same procedure but to check if the second array is earlier lexigoraphically
                {
                    earlier = 2;
                    break;
                }
            }

            if (earlier == 1)                                                                       // Check which array is earlier
            {
                Console.WriteLine("The first array is lexicographically before the second");
            }
            else if (earlier == 2)
            {
                Console.WriteLine("The second array is lexicographically before the first");
            }
            else if (earlier == 0)                                                                  // These checks are done if the two arrays have different length but same initial characters
            {

                Console.WriteLine("The two arrays are equal");                                      // To this point it is guaranteed that the two arrays have the same length, so if they have the same content, this means they are equal
            }
        }

        

    }
}