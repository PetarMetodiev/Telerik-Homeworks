
// Write a program that reads a string, reverses it and prints the result at the console.
// Example: "sample" -> "elpmas".

using System;

class ReverseString
{
    static void Main()
    {
        Console.Title = "Reverse the string";

        Console.Write("Enter string to be reversed: ");
        string input = Console.ReadLine();

        char[] inputArray = input.ToCharArray();
        Array.Reverse(inputArray);
        input = new string(inputArray);

        Console.WriteLine(input);
    }
}