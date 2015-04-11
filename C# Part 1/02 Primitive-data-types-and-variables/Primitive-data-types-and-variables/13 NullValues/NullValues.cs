using System;

class NullValues
{
    static void Main()
    {
        Console.Title = "Null values";
        int? a = null;
        double? b = null;
        Console.WriteLine("Null value of the integer variable: {0}", a);
        Console.WriteLine("Null value of the double variable: {0}", b);
        Console.WriteLine("Null integer + 5: {0}", (a + 5));
        Console.WriteLine("Null double + 5: {0}", (b + 5));
        Console.WriteLine("Null integer + null: ", a + null);
        Console.WriteLine("Null double + null: ", b + null);
    }
}
