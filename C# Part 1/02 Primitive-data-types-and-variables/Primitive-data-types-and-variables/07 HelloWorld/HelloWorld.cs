using System;

class HelloWorld
{
    static void Main()
    {
        Console.Title = "Hello World";
        string a = "Hello";
        string b = "World";
        object c = a + " " + b;
        string d = (string)c;
        Console.WriteLine(c);
    }
}
