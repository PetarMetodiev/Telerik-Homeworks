
//Write an expression that extracts from a given integer i the value of a given bit number b. Example: i=5; b=2 => value=1.

using System;

class BitExtract
{
    static void Main()
    {
        Console.Title = "What is the bit at the position?";

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
        Console.WriteLine("The bit at position {0} (counting from 0) is {1}", position, bit);
    }
}
