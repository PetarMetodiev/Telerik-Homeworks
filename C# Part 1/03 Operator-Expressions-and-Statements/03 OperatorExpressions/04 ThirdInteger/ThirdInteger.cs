
// Write an expression that checks for given integer if its third digit (right-to-left) is 7. E. g. 1732  true.

using System;

class ThirdInteger
{
    static void Main()
    {
        Console.Title = "Is the third digit 7?";

        Console.Write("Enter number: ");
        string numString = Console.ReadLine();
        float num;
        while (float.TryParse(numString, out num) == false)
        {
            Console.Write("Enter valid number for height: ");
            numString = Console.ReadLine();
        }
        if (Math.Abs((((int)(num / 100)) % 10)) == 7)      // Извличане на третата цифра.
        {                                                   // Първо се премахват последните две цифри, а после се извлича най-дясната цифра
            Console.WriteLine("True");
        }
        else
        {
            Console.WriteLine("False");
        }
    }
}
