using System;

class ExchangeValues
{
    static void Main()
    {
        Console.Title = "Exhange of variables' values";
        int a, b, c;
        string aString, bString;
        Console.Write("Enter value for a: ");
        aString = Console.ReadLine();
        while (int.TryParse(aString, out a) == false)
        {
            Console.Write("Enter value for a(integers only): ");
            aString = Console.ReadLine();
        }
        Console.Write("Enter value for b: ");
        bString = Console.ReadLine();
        while (int.TryParse(bString, out b) == false)
        {
            Console.Write("Enter value for b(integers only): ");
            bString = Console.ReadLine();
        }
        c = a;
        a = b;
        b = c;
        Console.WriteLine();
        Console.WriteLine("New values for a and b:");
        Console.WriteLine("a = {0}", a);
        Console.WriteLine("b = {0}", b);
    }
}
