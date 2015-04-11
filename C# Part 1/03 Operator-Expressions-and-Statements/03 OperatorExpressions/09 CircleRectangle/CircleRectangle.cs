
// Write an expression that checks for given point (x, y) if it is within the circle K( (1,1), 3) 
// and out of the rectangle R(top=1, left=-1, width=6, height=2).

using System;

class CircleRectangle
{
    static void Main()
    {
        Console.Title = "Is the point in the circle and in the rectangle?";

        float x, y;                 // Координатите на търсената точка
        float h, k;                 // Координатите на центъра на окръжността
        float r;                    // Радиусът на окръжността
        float xr1, xr2, yr1, yr2;   // Координатите на правоъгълника. xr1 е лявата граница, а xr2 - дясната, yr1 - горната, yr2 - долната

        Console.Write("Enter x coordinate for the point, x = ");
        string xString = Console.ReadLine();

        while ((float.TryParse(xString, out x)) == false)
        {
            Console.Write("Enter x coordinate for the pont, x = ");
            xString = Console.ReadLine();
        }

        Console.Write("Enter y coordinate for the point, y = ");
        string yString = Console.ReadLine();

        while ((float.TryParse(yString, out y)) == false)
        {
            Console.Write("Enter y coordinate for the pont, y = ");
            yString = Console.ReadLine();
        }

        Console.Write("Enter x coordinate for the center of the circle, xc = ");
        string hString = Console.ReadLine();

        while ((float.TryParse(hString, out h)) == false)
        {
            Console.Write("Enter x coordinate for the center of the circle, xc = ");
            hString = Console.ReadLine();
        }

        Console.Write("Enter y coordinate for the center of the circle, yc = ");
        string kString = Console.ReadLine();

        while ((float.TryParse(kString, out k)) == false)
        {
            Console.Write("Enter y coordinate for the center of the circle, yc = ");
            kString = Console.ReadLine();
        }

        Console.Write("Enter radius of the circle, r = ");
        string rString = Console.ReadLine();

        while ((float.TryParse(rString, out r)) == false)
        {
            Console.Write("Enter radius of the circle, r = ");
            rString = Console.ReadLine();
        }

        Console.Write("Enter x coordinate for the top left corner of the rectangle, xr = ");
        string xrString = Console.ReadLine();

        while ((float.TryParse(xrString, out xr1)) == false)
        {
            Console.Write("Enter x coordinate for the top left corner of the rectangle, xr = ");
            xrString = Console.ReadLine();
        }

        Console.Write("Enter y coordinate for the top left angle of the rectangle, yr = ");
        string yrString = Console.ReadLine();

        while ((float.TryParse(yrString, out yr1)) == false)
        {
            Console.Write("Enter y coordinate for the top left angle of the rectangle, yr = ");
            yrString = Console.ReadLine();
        }

        Console.Write("Enter width of the rectangle, w = ");
        string widthString = Console.ReadLine();
        float width;                                    // Ширина на правоъгълника

        while ((float.TryParse(widthString, out width)) == false)
        {
            Console.Write("Enter width of the rectangle, w = ");
            widthString = Console.ReadLine();
        }

        Console.Write("Enter height of the rectangle, h = ");
        string heightString = Console.ReadLine();
        float height;                                    // Височина на правоъгълника

        while ((float.TryParse(heightString, out height)) == false)
        {
            Console.Write("Enter height of the rectangle, h = ");
            heightString = Console.ReadLine();
        }

        xr2 = xr1 + width;
        yr2 = yr1 - height;
        float conditionCircle = ((x - h) * (x - h)) + ((y - k) * (y - k));

        if (conditionCircle < r*r)
        {
            Console.WriteLine("The point is in the circle");
        }
        else if (conditionCircle == r*r)
        {
            Console.WriteLine("The point is on the circle");
        }
        else
        {
            Console.WriteLine("The point is not in the circle");
        }

        if ((x > xr1) && (x < xr2) && (y < yr1) && (y > yr2))
        {
            Console.WriteLine("The point is in the rectangle");
        }
        else
        {
            Console.WriteLine("The point is not in the rectangle");
        }
    }
}
