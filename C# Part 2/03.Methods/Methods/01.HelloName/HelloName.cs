
// Write a method that asks the user for his name and prints “Hello, <name>” (for example, “Hello, Peter!”). 
// Write a program to test this method.

using System;

class HelloName
{
    static void Hello(string name)                      // Method to display the final result
    {
        Console.WriteLine("Hello, {0}", name);
    }

    static string Introduction()                        // Method for the input of the name
    {
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    static void Main()
    {
        Console.Title = "Hello Name";

        Hello(Introduction());                          // Calling the two methods consequently
    }
}
