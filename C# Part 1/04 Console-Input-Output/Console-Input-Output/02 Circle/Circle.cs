
// Write a program that reads the radius r of a circle and prints its perimeter and area.

using System;

class Circle
{
    static void Main()
    {
        Console.Title = "Radius and area of a circle";

        Console.Write("Enter radius of circle, r = ");
        string rString = Console.ReadLine();
        uint r;

        while (!uint.TryParse(rString, out r))
        {
            Console.Write("Enter radius of circle, r(r=>0) = ");
            rString = Console.ReadLine();
        }

        Console.WriteLine("The area of the circle is {0}", Math.Round((r*r*Math.PI), 2));
        Console.WriteLine("The perimeter of the circle is {0}", Math.Round((2*r*Math.PI), 2));
    }
}
