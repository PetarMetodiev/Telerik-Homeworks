using System;

class CompareNumbers
{
    static void Main()
    {
        Console.Title = "Comparison of float type numbers";
        Console.Write("Enter a:");
        string astring = Console.ReadLine();
        float a = float.Parse(astring);
        Console.Write("Enter b:");
        string bstring = Console.ReadLine();
        float b = float.Parse(bstring);
        bool check = true;
        if (a == b)
        {
            Console.WriteLine(check);
        }
        else
        { 
            Console.WriteLine(!check); 
        }
    }
}
