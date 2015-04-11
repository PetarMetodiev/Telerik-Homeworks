
// Write a boolean expression that returns if the bit at position p (counting from 0) 
// in a given integer number v has value of 1. Example: v=5; p=1 => false.

using System;

class CheckBit
{
    static void Main()
    {
        Console.Title = "Is the bit 1 or 0?";

        Console.Write("Enter integer: ");
        string numString = Console.ReadLine();
        int num;

        while ((int.TryParse(numString, out num)) == false)
        {
            Console.Write("Enter integer: ");
            numString = Console.ReadLine();
        }

        int position;

        Console.Write("Enter desired position (counting from 0): ");
        string positionString = Console.ReadLine();

        while (((int.TryParse(positionString, out position)) == false) || (position < 0))
        {
            Console.Write("Enter desired position (positive integer, counting from 0): ");
            positionString = Console.ReadLine();
        }

        int mask = 1 << position;
        int nAndMask = num & mask;
        int bit = nAndMask >> position;
        bool check = (bit == 1);

        Console.WriteLine("{0} in binary is {1}", num, Convert.ToString(num, 2));

        if (check)
        {
            Console.WriteLine("True");
        }
        else
        {
            Console.WriteLine("False");
        }

    }
}
