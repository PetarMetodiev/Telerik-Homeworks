using System;
using System.Threading;


public class Menu
{
    // Contains each menu line
    static string[] menu = { "    CONSOLE WARS", "", "Choose Difficulty:", "", "  1. -> Easy", "  2. -> Medium", "  3. -> Hard", "" };
    // Contains difficulty messages
    static string[] difficultyMessages = { "Easy: Like a walk in the park.", "Medium: Let's get ready to rumble.", "Hard: Today is a good day to die." };
    // User's difficulty level choice
    static int choice;
    // Max width of the menu
    static int maxWidth;
    // Menu row index sets the position of the selector in the menu, serves as an index for menu[] and holds the user input
    static int menuRowIndex = 4;

    // Print on given position
    static void PrintOnPosition(int row, int col, string c, ConsoleColor color = ConsoleColor.Gray)
    {
        Console.SetCursorPosition(col, row);
        Console.ForegroundColor = color;
        Console.Write(c);
    }

    // Print the menu
    public static void PrintMenu()
    {
        maxWidth = 0;

        // Print left and right side lines
        for (int i = 0; i < menu.Length; i++)
        {
            if (menu[i].Length > maxWidth)
            {
                maxWidth = menu[i].Length;
            }
        }

        // Increment maxWidth by six for visual appeal
        maxWidth = maxWidth + 6;
        // Top and bottom menu lines
        string menuTopAndBottomLine = new string('-', maxWidth);

        // Print top line
        PrintOnPosition(Console.WindowHeight / 3, Console.WindowWidth / 2 - maxWidth / 2 - 1, "+", ConsoleColor.Green);
        PrintOnPosition(Console.WindowHeight / 3, Console.WindowWidth / 2 - maxWidth / 2, menuTopAndBottomLine, ConsoleColor.Green);
        PrintOnPosition(Console.WindowHeight / 3, Console.WindowWidth / 2 + maxWidth / 2, "+", ConsoleColor.Green);

        // Print side menu lines
        for (int i = 0; i < menu.Length; i++)
        {
            PrintOnPosition(Console.WindowHeight / 3 + i + 1, Console.WindowWidth / 2 - maxWidth / 2 - 1, "|", ConsoleColor.Green);
            PrintOnPosition(Console.WindowHeight / 3 + i + 1, Console.WindowWidth / 2 + maxWidth / 2, "|", ConsoleColor.Green);
        }

        // Print bottom line
        PrintOnPosition(Console.WindowHeight / 3 + menu.Length + 1, Console.WindowWidth / 2 - maxWidth / 2 - 1, "+", ConsoleColor.Green);
        PrintOnPosition(Console.WindowHeight / 3 + menu.Length + 1, Console.WindowWidth / 2 + maxWidth / 2, "+", ConsoleColor.Green);
        PrintOnPosition(Console.WindowHeight / 3 + menu.Length + 1, Console.WindowWidth / 2 - maxWidth / 2, menuTopAndBottomLine, ConsoleColor.Green);

        // Print menu
        for (int i = 0; i < menu.Length; i++)
        {
            Console.SetCursorPosition(Console.WindowWidth / 3, Console.WindowHeight / 3 + 1 + i);
            Console.WriteLine(menu[i]);
        }
    }

    // Select difficulty level
    private static int SelectDificulty()
    {
        // Highlight selected option
        PrintOnPosition(Console.WindowHeight / 2 - (menu.Length / 2 + 1) + menuRowIndex, Console.WindowWidth / 3, menu[menuRowIndex], ConsoleColor.Blue);
        ConsoleKeyInfo kI;
        kI = Console.ReadKey();

        // Move selector up and down and get user choice
        if (kI.Key == ConsoleKey.DownArrow && menuRowIndex < 6)
        {
            menuRowIndex++;
        }
        if (kI.Key == ConsoleKey.UpArrow && menuRowIndex > 4)
        {
            menuRowIndex--;
        }
        if (kI.Key == ConsoleKey.Enter)
        {
            return menuRowIndex - 3;
        }

        return -1;
    }

    // Start the menu
    public static int StartMenu()
    {
        while (true)
        {
            PrintMenu();
            choice = SelectDificulty();
            Console.Clear();

            // Close menu when the user has selected difficulty level
            if (choice >= 1 && choice <= 3)
            {
                PrintOnPosition(0, 0, string.Empty, ConsoleColor.Green);
                break;
            }
        }

        // Clear the console and print difficulty message slowly
        Console.Clear();
        string current = difficultyMessages[choice - 1];

        for (int i = 0; i < current.Length; i++)
        {
            Thread.Sleep(100);
            Console.SetCursorPosition(Console.WindowWidth / 4 + i, Console.WindowHeight / 3 + 1);
            Console.Write(current[i]);
        }
        Thread.Sleep(1500);
        Console.Clear();

        return choice;
    }
}
