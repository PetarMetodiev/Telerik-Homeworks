using System;

class AgeCalculator
{
    static void Main()
    {
        Console.Title = "Age Calculator";
        Console.WriteLine("My current age is ");
        string agestring = Console.ReadLine();
        int age = int.Parse(agestring);
        Console.WriteLine("I will be {0} years old in 10 years",age+10);
    }
}
