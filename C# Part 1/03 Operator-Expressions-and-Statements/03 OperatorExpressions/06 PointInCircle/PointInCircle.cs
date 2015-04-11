
// Write an expression that checks if given point (x,  y) is within a circle K(O, 5).

using System;

class PointInCircle
{
    static void Main()
    {
        Console.Title = "Is the point in the circle?";

        Console.Write("Enter x = ");
        string xString = Console.ReadLine();
        double x, y;                                        // Деклариране на координатите
        double r;                                           // Деклариране на радиусът на окръжността

        while (double.TryParse(xString, out x) == false)
        {
            Console.Write("Enter valid integer for x = ");
            xString = Console.ReadLine();
        }

        Console.Write("Enter y = ");
        string yString = Console.ReadLine();

        while ((double.TryParse(yString, out y)) == false)
        {
            Console.Write("Enter y = ");
            yString = Console.ReadLine();
        }

        Console.Write("Enter r = ");
        string rString = Console.ReadLine();

        while ((double.TryParse(rString, out r)) == false)
        {
            Console.Write("Enter r = ");
            rString = Console.ReadLine();
        }

        double position = Math.Sqrt((x*x) + (y*y));         // По питагорова теорема се намира разстоянието от (0,0) до зададената точка
                                                            // и после се сравнява с радиуса на окръжността
        if (position < r)
        {
            Console.WriteLine("The point with coordinates ({0}, {1}) is within the circle with r = {2}", x, y, r);
        }
        else if (position == r)
        {
            Console.WriteLine("The point with coordinates ({0}, {1}) is on the circle with r = {2}", x, y, r);
        }
        else
        {
            Console.WriteLine("The point with coordinates ({0}, {1}) is not in the circle with r = {2}", x, y, r);
        }
    }
}
