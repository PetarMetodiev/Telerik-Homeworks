
// Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 1 or 0.

using System;

class ThirdBitCheck
{
    static void Main()
    {
        Console.Title = "Is the third bit 1 or 0?";

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
        Console.WriteLine("{0} in binary is {1}", num, Convert.ToString(num, 2));
        Console.WriteLine("Bit number {0}(counting from 0) is {1}", position, bit);
        
    }
}
