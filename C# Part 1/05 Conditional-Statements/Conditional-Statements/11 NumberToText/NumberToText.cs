using System;

class NumbersToText
{
    public static void Digits(uint input)        // Case for numbers between 0 and 9
    {
        switch (input)
        {
            case 0:
                Console.WriteLine("Zero ");
                break;
            case 1:
                Console.Write("One ");
                break;
            case 2:
                Console.Write("Two ");
                break;
            case 3:
                Console.Write("Three ");
                break;
            case 4:
                Console.Write("Four ");
                break;
            case 5:
                Console.Write("Five ");
                break;
            case 6:
                Console.Write("Six ");
                break;
            case 7:
                Console.Write("Seven ");
                break;
            case 8:
                Console.Write("Eight ");
                break;
            case 9:
                Console.Write("Nine ");
                break;
            default:
                break;
        }
    }

    public static void TenToNineteen(uint input)     // Case for numbers between 10 and 19
    {
        switch (input)
        {
            case 10:
                Console.Write("Ten ");
                break;
            case 11:
                Console.Write("Eleven ");
                break;
            case 12:
                Console.Write("Twelve ");
                break;
            case 13:
                Console.Write("Thirteen ");
                break;
            case 14:
                Console.Write("Fourteen ");
                break;
            case 15:
                Console.Write("Fifteen ");
                break;
            case 16:
                Console.Write("Sixteen ");
                break;
            case 17:
                Console.Write("Seventeen ");
                break;
            case 18:
                Console.Write("Eighteen ");
                break;
            case 19:
                Console.Write("Nineteen ");
                break;
            default:
                break;
        }
    }

    public static void Tens(uint number)     // 20, 30, 40, 50, 60, 70, 80, 90
    {
        switch (number)
        {
            case 2:
                Console.Write("Twenty ");
                break;
            case 3:
                Console.Write("Thirty ");
                break;
            case 4:
                Console.Write("Fourty ");
                break;
            case 5:
                Console.Write("Fifty ");
                break;
            case 6:
                Console.Write("Sixty ");
                break;
            case 7:
                Console.Write("Seventy ");
                break;
            case 8:
                Console.Write("Eighty ");
                break;
            case 9:
                Console.Write("Ninety ");
                break;
            default:
                break;
        }
    }

    public static void Hundreds(uint input)     // 100, 200, 300, 400, 500, 600, 700, 800, 900
    {
        switch (input)
        {
            case 1:
                Console.Write("One Hundred ");
                break;
            case 2:
                Console.Write("Two Hunderd ");
                break;
            case 3:
                Console.Write("Three Hundred ");
                break;
            case 4:
                Console.Write("Four Hundred ");
                break;
            case 5:
                Console.Write("Five Hundred ");
                break;
            case 6:
                Console.Write("Six Hundred ");
                break;
            case 7:
                Console.Write("Seven Hundred ");
                break;
            case 8:
                Console.Write("Eight Hundred ");
                break;
            case 9:
                Console.Write("Nine Hundred ");
                break;
            default:
                break;
        }
    }

    static void Main()
    {
        Console.Title = "Convert number to text";

        uint input, firstDigit, secondDigit, thirdDigit;

        Console.WriteLine("Enter number between 0 and 999");
        Console.Write("Enter number: ");
        string inputString = Console.ReadLine();

        while (!(uint.TryParse(inputString, out input)) || input > 999)
        {
            Console.Write("Enter number between 0 and 999: ");
            inputString = Console.ReadLine();
        }

        if (input < 10)         //Check if the entered number is between 1 and 10
        {
            Digits(input);
        }
        else if (input >= 10 && input <= 19)        // Check if the entered number is between 11 and 19
        {
            TenToNineteen(input);
        }
        else if (input >= 20 && input < 100)        //Check if the entered number is between 20 and 99
        {
            firstDigit = input / 10;                // Take first digit
            secondDigit = input % 10;               // Take second digit

            if (secondDigit == 0)
            {
                Tens(firstDigit);
            }
            else
            {
                Tens(firstDigit);
                Digits(secondDigit);
            }


        }
        else if (input >= 100 && input < 1000)      // Check if the entered number is between 100 and 999
        {
            firstDigit = input / 100;
            secondDigit = (input / 10) % 10;
            thirdDigit = input % 10;
            Hundreds(firstDigit);

            uint specials = input % 100;

            uint digits = input % 100;              // Check for digits (0 to 9). Example: 501 (five hundred and one)
            if ((digits > 0 && digits < 10) || (specials >= 10 && specials < 20) && specials != 0)
            {
                Console.Write("and ");
                Digits(digits);
            }

            if (specials >= 10 && specials < 20)    // Check if the number is between 10 and 19
            {
                TenToNineteen(specials);
            }

            uint noZero = input % 100;              // check for zero in third and second digit
            if (noZero == 0)
            {
                Hundreds(noZero);
            }
            else if (input > 20 && input < 1000)
            {
                Tens(secondDigit);
                uint zeroChecker = input % 100;
                uint otherZeroChecker = input % 10;
                if (otherZeroChecker != 0 && zeroChecker != 1 && zeroChecker != 2 && zeroChecker != 3 &&
                    zeroChecker != 4 && zeroChecker != 5 && zeroChecker != 6 &&
                    zeroChecker != 7 && zeroChecker != 8 && zeroChecker != 9 &&
                    !(specials >= 10 && specials < 20)) // Check for zero in third digit
                {
                    Digits(thirdDigit);
                }
            }



        }
        Console.WriteLine();

    }
}