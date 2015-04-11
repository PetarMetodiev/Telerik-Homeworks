
// Write a program that prints all possible cards from a standard deck of 52 cards (without jokers). 
// The cards should be printed with their English names. Use nested for loops and switch-case.

using System;

class Cards
{
    static void Main()
    {
        Console.Title = "52 cards";

        for (int i = 1; i <= 4; i++)                                    // Loop for changing the suit
        {
            for (int j = 2; j < 15; j++)                                // Loop for changing the card
            {
                switch (j)                                              // At every j, a different card is written
                {
                    case 2:
                        Console.Write("2 of ");
                        switch (i)                                      // Depending on the value of i, different suit is printed
	                    {
                            case 1:
                                Console.WriteLine("hearts");
                                break;
                            case 2:
                                Console.WriteLine("clubs");
                                break;
                            case 3:
                                Console.WriteLine("diamonds");
                                break;
                            case 4:
                                Console.WriteLine("spades");
                                break;

	                    }
                        break;
                    case 3:
                        Console.Write("3 of ");
                        switch (i)
                        {
                            case 1:
                                Console.WriteLine("hearts");
                                break;
                            case 2:
                                Console.WriteLine("clubs");
                                break;
                            case 3:
                                Console.WriteLine("diamonds");
                                break;
                            case 4:
                                Console.WriteLine("spades");
                                break;

                        }
                        break;
                    case 4:
                        Console.Write("4 of ");                        
                        switch (i)
	                    {
                            case 1:
                                Console.WriteLine("hearts");
                                break;
                            case 2:
                                Console.WriteLine("clubs");
                                break;
                            case 3:
                                Console.WriteLine("diamonds");
                                break;
                            case 4:
                                Console.WriteLine("spades");
                                break;

	                    }
                        break;
                    case 5:
                        Console.Write("5 of ");
                        switch (i)
                        {
                            case 1:
                                Console.WriteLine("hearts");
                                break;
                            case 2:
                                Console.WriteLine("clubs");
                                break;
                            case 3:
                                Console.WriteLine("diamonds");
                                break;
                            case 4:
                                Console.WriteLine("spades");
                                break;

                        }
                        break;
                    case 6:
                        Console.Write("6 of ");
                        switch (i)
                        {
                            case 1:
                                Console.WriteLine("hearts");
                                break;
                            case 2:
                                Console.WriteLine("clubs");
                                break;
                            case 3:
                                Console.WriteLine("diamonds");
                                break;
                            case 4:
                                Console.WriteLine("spades");
                                break;

                        }
                        break;
                    case 7:
                        Console.Write("7 of ");
                        switch (i)
                        {
                            case 1:
                                Console.WriteLine("hearts");
                                break;
                            case 2:
                                Console.WriteLine("clubs");
                                break;
                            case 3:
                                Console.WriteLine("diamonds");
                                break;
                            case 4:
                                Console.WriteLine("spades");
                                break;

                        }
                        break;
                    case 8:
                        Console.Write("8 of ");
                        switch (i)
                        {
                            case 1:
                                Console.WriteLine("hearts");
                                break;
                            case 2:
                                Console.WriteLine("clubs");
                                break;
                            case 3:
                                Console.WriteLine("diamonds");
                                break;
                            case 4:
                                Console.WriteLine("spades");
                                break;

                        }
                        break;
                    case 9:
                        Console.Write("9 of ");
                        switch (i)
                        {
                            case 1:
                                Console.WriteLine("hearts");
                                break;
                            case 2:
                                Console.WriteLine("clubs");
                                break;
                            case 3:
                                Console.WriteLine("diamonds");
                                break;
                            case 4:
                                Console.WriteLine("spades");
                                break;

                        }
                        break;
                    case 10:
                        Console.Write("10 of ");
                        switch (i)
                        {
                            case 1:
                                Console.WriteLine("hearts");
                                break;
                            case 2:
                                Console.WriteLine("clubs");
                                break;
                            case 3:
                                Console.WriteLine("diamonds");
                                break;
                            case 4:
                                Console.WriteLine("spades");
                                break;

                        }
                        break;
                    case 11:
                        Console.Write("Jack of ");
                        switch (i)
                        {
                            case 1:
                                Console.WriteLine("hearts");
                                break;
                            case 2:
                                Console.WriteLine("clubs");
                                break;
                            case 3:
                                Console.WriteLine("diamonds");
                                break;
                            case 4:
                                Console.WriteLine("spades");
                                break;

                        }
                        break;
                    case 12:
                        Console.Write("Queen of ");
                        switch (i)
                        {
                            case 1:
                                Console.WriteLine("hearts");
                                break;
                            case 2:
                                Console.WriteLine("clubs");
                                break;
                            case 3:
                                Console.WriteLine("diamonds");
                                break;
                            case 4:
                                Console.WriteLine("spades");
                                break;

                        }
                        break;
                    case 13:
                        Console.Write("King of ");
                        switch (i)
                        {
                            case 1:
                                Console.WriteLine("hearts");
                                break;
                            case 2:
                                Console.WriteLine("clubs");
                                break;
                            case 3:
                                Console.WriteLine("diamonds");
                                break;
                            case 4:
                                Console.WriteLine("spades");
                                break;

                        }
                        break;
                    case 14:
                        Console.Write("Ace of ");
                        switch (i)
                        {
                            case 1:
                                Console.WriteLine("hearts");
                                break;
                            case 2:
                                Console.WriteLine("clubs");
                                break;
                            case 3:
                                Console.WriteLine("diamonds");
                                break;
                            case 4:
                                Console.WriteLine("spades");
                                break;

                        }
                        break;
                }
            }

        }
    }
}