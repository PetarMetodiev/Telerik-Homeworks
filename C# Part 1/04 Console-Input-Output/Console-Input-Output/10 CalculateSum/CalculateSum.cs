
// Write a program to calculate the sum (with accuracy of 0.001): 1 + 1/2 - 1/3 + 1/4 - 1/5 + ...

using System;

class CalculateSum
{
    static void Main()
    {
        Console.Title = "Calculation of a sum";

        double member = 2;
        double sum = 1;
        int sign = 1;

        while (1 / member > 0.001)
        {
            sum = sum + (1 / member) * sign;
            member++;
            sign = sign * (- 1);
        }

        Console.WriteLine("{0:0.000}", sum);

    }
}