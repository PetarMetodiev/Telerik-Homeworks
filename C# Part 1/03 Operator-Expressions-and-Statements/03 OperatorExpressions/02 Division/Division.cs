
// Write a boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 in the same time.

using System;

class Division
{
    static void Main()
    {
        Console.Title = "Can it be divided by 5 and 7 without reminder?";

        Console.Write("Enter number: ");
        string numString = Console.ReadLine();
        int num;
        bool answer = false;
        while (int.TryParse(numString, out num) == false)
        {
            Console.Write("Enter valid number(integer): ");
            numString = Console.ReadLine();
        }
        if (num % 35 == 0)
        {
            answer = true;
        }
        Console.WriteLine("Is the number divisible by 7 and 5 simultaniously? {0}", answer);
    }
}
