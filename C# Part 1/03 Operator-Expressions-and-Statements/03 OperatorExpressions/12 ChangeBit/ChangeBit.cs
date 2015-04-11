
// We are given integer number n, value v (v=0 or 1) and a position p. Write a sequence of operators 
// that modifies n to hold the value v at the position p from the binary representation of n.
//	Example: n = 5 (00000101), p=3, v=1 => 13 (00001101)
//	n = 5 (00000101), p=2, v=0 => 1 (00000001)

using System;

class ChangeBit
{
    static void Main()
    {
        Console.Title = "Change the bit at a position";

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

        int newBit;

        Console.Write("Enter new value for position {0}: ", position);
        string newBitString = Console.ReadLine();

        while (((int.TryParse(newBitString, out newBit)) == false) || ((newBit != 0) && (newBit != 1)))
        {
            Console.Write("Enter new value for position {0} (0 or 1): ", position);
            newBitString = Console.ReadLine();
        }

        Console.WriteLine("{0} in binary is {1}", num, Convert.ToString(num, 2).PadLeft(32, '0'));

        int mask = 1 << position;
        int mask2 = ~(1 << position);
        int nAndMask = num & mask;
        int bit = nAndMask >> position;

        if (bit == newBit)
        {
            Console.WriteLine("The number is the same {0} ({1})", num, Convert.ToString(num, 2).PadLeft(32, '0'));
        }
        else if(bit != newBit && bit == 1)
        {
            Console.WriteLine("The new number is {0} ({1})", (num & mask2), Convert.ToString((num & mask2), 2).PadLeft(32, '0'));
        }
        else if (bit != newBit && bit == 0)
        {
            Console.WriteLine("The new number is {0} ({1})", (num | mask), Convert.ToString((num | mask), 2).PadLeft(32, '0'));
        }

        //Console.WriteLine("The bit at position {0} (counting from 0) is {1}", position, bit);
    }
}
