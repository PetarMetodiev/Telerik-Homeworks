
//Write an expression that calculates rectangle’s area by given width and height.

using System;

class RectangularArea
{
    static void Main()
    {
        Console.Title = "Rectangular area";

        Console.Write("Enter height: ");
        string heightString = Console.ReadLine();
        float height;
        while (float.TryParse(heightString, out height) == false)
        {
            Console.Write("Enter valid number for height: ");
            heightString = Console.ReadLine();
        }
        Console.Write("Enter width: ");
        string widthString = Console.ReadLine();
        float width;
        while (float.TryParse(widthString, out width) == false)
        {
            Console.Write("Enter valid number for width: ");
            heightString = Console.ReadLine();
        }
        Console.WriteLine("The area of a rectangle with height {0} and width {1} is {2}", height, width, height*width);
    }
}
