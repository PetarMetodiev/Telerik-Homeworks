
// You are given a sequence of positive integer values written into a string, separated by spaces. 
// Write a function that reads these values from given string and calculates their sum. 
using System;

class SumFromString
{
    static void Main()
    {
        Console.Title = "Calculate sum of numbers";

        Console.WriteLine("Enter row of positive integers, divided by spaces:");
        string row = Console.ReadLine();

        string[] separators = new string[] { " " };
        // This is to prevent if more than one space is entered.
        string[] numberAsString = row.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        int[] numbers = new int[numberAsString.Length];

        for (int i = 0; i < numberAsString.Length; i++)
        {
            numbers[i] = int.Parse(numberAsString[i]);
        }

        int sum = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }

        Console.WriteLine("The total sum is {0}", sum);
    }
}