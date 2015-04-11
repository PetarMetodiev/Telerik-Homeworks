using System;

class MinMaxAvSumProd
{
    static void Min(params int[] sequence)
    {
        int minValue = sequence[0];

        for (int i = 1; i < sequence.Length; i++)
        {
            if (minValue > sequence[i])
            {
                minValue = sequence[i];
            }
        }

        Console.WriteLine("The minimal value of the sequence {0} is {1}.", string.Join(", ", sequence), minValue);
    }

    static void Max(params int[] sequence)
    {
        int maxValue = sequence[0];

        for (int i = 1; i < sequence.Length; i++)
        {
            if (maxValue < sequence[i])
            {
                maxValue = sequence[i];
            }
        }

        Console.WriteLine("The maximal value of the sequence {0} is {1}.", string.Join(", ", sequence), maxValue);
    }

    static double Sum(params double[] sequence)
    {
        double sum = 0;

        for (int i = 0; i < sequence.Length; i++)
        {
            sum = sum + sequence[i];
        }

        return sum;
    }

    static void Average(params double[] sequence)
    {
        double sum = Sum(sequence);
        double average = sum / sequence.Length;

        Console.WriteLine("The average value of the sequence {0} is {1}.", string.Join(", ", sequence), average);
    }

    static void Product(params int[] sequence)
    {
        int product = 1;

        for (int i = 0; i < sequence.Length; i++)
        {
            product = product * sequence[i];
        }

        Console.WriteLine("The product of the sequence {0} is {1}.", string.Join(", ", sequence), product);
    }

    static void Main()
    {
        Min(6, 58, -9, 0, 5, 5, 69, -98, -23);
        Max(6, 58, -9, 0, 5, 5, 69, -98, -23);
        Console.WriteLine("The sum of the sequence {0} is {1}.", string.Join(", ", 6, 58, -9, 0, 5, 5, 69, -98, -23), Sum(6, 58, -9, 0, 5, 5, 69, -98, -23));
        Average(1, 2, 3);
        Product(1, 2, 3);
    }
}
