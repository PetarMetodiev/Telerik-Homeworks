using System;

class Quotations
{
    static void Main()
    {
        Console.Title = "Usage of quotations";
        string a = "The \"use\" of quotations causes difficulties.";
        string b = @"The ""use"" of quotations causes difficulties.";
        Console.WriteLine(a);
        Console.WriteLine(b);
    }
}
