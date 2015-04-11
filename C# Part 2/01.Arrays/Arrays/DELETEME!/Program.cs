using System;

class TemperatureConverter
{
    static double FahrenheitToCelsius(double degrees)
    {
        Console.WriteLine("CHECK");

        double celsius = (degrees - 32) * 5 / 9;

        Console.WriteLine("CHECK");
        return celsius;
    }

    static void Main()
    {
        Console.WriteLine("Enter your body temperature in Fahrenheit degrees: ");
        double temperature = Double.Parse(Console.ReadLine());

        temperature = FahrenheitToCelsius(temperature);
        Console.WriteLine("CHECK MAIN");

        Console.WriteLine("Your body temperature in Celsius degrees is {0}.", temperature);

        if (temperature >= 37)
        {
            Console.WriteLine("You are ill!");
        }
    }
}
