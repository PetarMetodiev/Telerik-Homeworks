
// Write a program to calculate n! for each n in the range [1..100]. 
using System;
using System.Text;

class Factorial
{
    static string NumberMultiplyer(string number, int digit)
    {
        string result = null;
        int carry = 0;
        for (int i = number.Length - 1; i >= 0; i--)
        {
            int currDigit = int.Parse(number[i].ToString());
            int currProduct = currDigit * digit;
            if (currProduct + carry < 10)
            {
                result = (currProduct + carry) + result;
                carry = 0;
            }
            else
            {
                result = ((currProduct + carry) % 10) + result;
                carry = (currProduct + carry) / 10;
            }
        }

        if (carry != 0)
        {
            result = carry + result;
        }

        return result;
    }

    public static void Main()
    {

        string answer = "1";

        for (int i = 2; i <= 100; i++)
        {
            answer = NumberMultiplyer(answer, i);
        }
        Console.WriteLine(answer);
    }
}