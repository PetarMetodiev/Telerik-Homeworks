using System;

class Program
{
    static void Main()
    {
        uint n1 = uint.Parse(Console.ReadLine());
        uint n2 = uint.Parse(Console.ReadLine());
        uint n3 = uint.Parse(Console.ReadLine());
        uint n4 = uint.Parse(Console.ReadLine());
        uint n5 = uint.Parse(Console.ReadLine());
        decimal moneyInTrays = n1*0.05m + n2*0.1m + n3*0.2m + n4*0.5m + n5*1m;

        decimal input = decimal.Parse(Console.ReadLine());
        decimal price = decimal.Parse(Console.ReadLine());
        decimal change = input - price;
        decimal leftInTrays = moneyInTrays - change;

        if (input < price)
        {
            Console.WriteLine("More {0:0.00}", (double)Math.Abs(input - price));
        }

        if (input == price)
        {
            Console.WriteLine("Yes {0:0.00}", moneyInTrays);
        }

        if (input > price)
        {
            if (leftInTrays < change)
            {
                Console.WriteLine("No {0}", (double)Math.Abs(input - price - moneyInTrays));
            }
            else if (leftInTrays == change)
            {
                Console.WriteLine("Yes {0}", (double)Math.Abs(input - price - moneyInTrays));
            }
            else
            {
                Console.WriteLine("Yes {0}", leftInTrays - change);
            }
        }
    }
}
