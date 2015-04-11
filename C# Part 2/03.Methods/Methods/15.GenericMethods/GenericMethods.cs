using System;
using System.Collections.Generic;

class GenericMethods
{
    static void Min<T>(params T[] sequence)
    {
        dynamic minValue = sequence[0];

        for (int i = 1; i < sequence.Length; i++)
        {
            if (minValue > sequence[i])
            {
                minValue = sequence[i];
            }
        }

        Console.WriteLine("The minimal value of the sequence {0} is {1}.", string.Join("; ", sequence), minValue);
    }

    static void Max<T>(params T[] sequence)
    {
        dynamic maxValue = sequence[0];

        for (int i = 1; i < sequence.Length; i++)
        {
            if (maxValue < sequence[i])
            {
                maxValue = sequence[i];
            }
        }

        Console.WriteLine("The maximal value of the sequence {0} is {1}.", string.Join("; ", sequence), maxValue);
    }

    static T Sum<T>(params T[] sequence)
    {
        dynamic sum = 0;

        for (int i = 0; i < sequence.Length; i++)
        {
            sum = sum + sequence[i];
        }

        return sum;
    }

    static void Average<T>(params T[] sequence)
    {
        dynamic sum = Sum(sequence);
        dynamic average = sum / sequence.Length;

        Console.WriteLine("The average value of the sequence {0} is {1}.", string.Join("; ", sequence), average);
    }

    static void Product<T>(params T[] sequence)
    {
        dynamic product = 1;

        for (int i = 0; i < sequence.Length; i++)
        {
            product = product * sequence[i];
        }

        Console.WriteLine("The product of the sequence {0} is {1}.", string.Join("; ", sequence), product);
    }

    static void Main()
    {
        Min('a', 'f', 'f', '4', ' ');
        Min(1, 4, 8, 0, -8, -345, 5, 88);
        Min(3.5m, -98.3m, -9.3m, 6m, 5m, 55.3m);

        Console.WriteLine();

        Max('a', 'f', 'f', '4', ' ');
        Max(1, 4, 8, 0, -8, -345, 5, 88);
        Max(3.5m, -98.3m, -9.3m, 6m, 5m, 55.3m);

        Console.WriteLine();

        Console.WriteLine("The sum of the sequence {0} is {1}.", string.Join(", ", 1, 4, 8, 0, -8, -345, 5, 88), Sum(1, 4, 8, 0, -8, -345, 5, 88));
        Console.WriteLine("The sum of the sequence {0} is {1}.", string.Join(", ", 3.5, -98.3, -9.3, 6, 5, 55.3), Sum(3.5, -98.3, -9.3, 6, 5, 55.3));

        Console.WriteLine();

        Average(1, 4, 8, 0, -8, -345, 5, 88);
        Average(3.5m, -98.3m, -9.3m, 6m, 5m, 55.3m);

        Console.WriteLine();

        Product(1, 4, 8, 0, -8, -345, 5, 88);
        Product(3.5m, -98.3m, -9.3m, 6m, 5m, 55.3m);
    }
}