using System;

class Sequence
{
    static void Main()
    {
        Console.Title = "Sequence";
        for (int i = 2; i < 12; i++)        //A cycle is used to determine any nth member of the sequence
        {
            if (i % 2 == 0)
            {
                Console.WriteLine("The {0} member is {1}",i-1,i);
            }
            else
            {
                Console.WriteLine("The {0} member is {1}",i-1,-i);
            }
        }
    }
}
