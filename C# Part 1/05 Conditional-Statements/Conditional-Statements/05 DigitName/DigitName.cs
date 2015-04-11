
// Write program that asks for a digit and depending on the input shows the name of that digit (in English) using a switch statement.

using System;

class DigitName
{
    static void Main()
    {
        Console.Title = "The digit in English";

        Console.Write("Enter a digit: ");
        string numString = Console.ReadLine();
        byte num;

        while (!(byte.TryParse(numString, out num))/* || (num < 0 || num > 9)*/) // The check if the entered integer is a digit is not required, due to the default option in switch
        {
            Console.Write("Enter digit: ");
            numString = Console.ReadLine();
        }

        switch (num)
        {
            case 1: Console.WriteLine("In English 1 is One"); break;
            case 2: Console.WriteLine("In English 2 is Two"); break;
            case 3: Console.WriteLine("In English 3 is Three"); break;
            case 4: Console.WriteLine("In English 4 is Four"); break;
            case 5: Console.WriteLine("In English 5 is Five"); break;
            case 6: Console.WriteLine("In English 6 is Six"); break;
            case 7: Console.WriteLine("In English 7 is Seven"); break;
            case 8: Console.WriteLine("In English 8 is Eight"); break;
            case 9: Console.WriteLine("In English 9 is Nine"); break;
            default: Console.WriteLine("Not a valid digit."); break;
        }
    }
}
