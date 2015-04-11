using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

struct rock                         // Structure for the falling rocks
{
    public int row;                 // x - coordinate of a falling rock
    public int col;                 // y - coordinate of a falling rock
    public string symbol;           // symbol for a falling rock
    public ConsoleColor color;      // color for a falling rock
}

struct dwarf                        // Structure for the dwarf
{
    public int col;                 // column - coordinate for the dwarf
    public int row;                 // row - coordinate of the dwarf
    public ConsoleColor color;      // color of the dwarf
    public string dwarfSymbol;      // symbol of the dwarf
}

class FallingRocks
{
    static void PrintOnPosition(int row, int col, string c, ConsoleColor color = ConsoleColor.Gray)     // Printing a required element on a required position
    {
        Console.SetCursorPosition(col, row);
        Console.ForegroundColor = color;
        Console.Write(c);
    }

    static void Main()
    {
        Console.Title = "Falling rocks";

        int playFieldWidth = 30;            // Size of the playfield, the remaining part of the window is for infomration such as remaining lives, score, speed
        int scoreBoard = 30;                // Size of the scoreboard

        Console.BufferHeight = Console.WindowHeight = 20;       // Set the size of the console window
        Console.BufferWidth = Console.WindowWidth = playFieldWidth + scoreBoard;    // Setting the width of the console to be dependent on the playfield and scoreboard widths

        Console.WriteLine("At what difficulty would you like to play?");
        Console.WriteLine();
        Console.WriteLine("Option 1 - I am a noob dwarf and I am affraid of getting a scratch");
        Console.WriteLine("Option 2 - I am experianced dwarf and I can take a few punches");
        Console.WriteLine("Option 3 - AS SAM BOK!");
        Console.WriteLine();
        Console.Write("Enter the number of the option you would like: ");
        string difficultyString = Console.ReadLine();
        int difficulty;

        while (!(int.TryParse(difficultyString, out difficulty)) || (difficulty != 1) && (difficulty != 2) && (difficulty != 3))
        {
            Console.Write("Enter the number of the option you would like: ");
            difficultyString = Console.ReadLine();
        }

        double speed;                   // Speed of game
        double acceleration;            // Speed increment
        int lives;                      // Lives
        double score;                   // Score counter
        double scoreIncrement;          // Different score increment depending on the difficulty
        int speedLimit;                 // Speed limit of the game

        if (difficulty == 1)            // Setting the difficulty
        {
            speed = 50;
            acceleration = 0.1;
            lives = 7;
            score = -100;
            scoreIncrement = 0.25;
            speedLimit = 300;
        }
        else if (difficulty == 2)
        {
            speed = 100; 
            acceleration = 0.5; 
            lives = 5; 
            score = 0; 
            scoreIncrement = 1;
            speedLimit = 400;
        }
        else
        {
            speed = 150; 
            acceleration = 1;
            lives = 3;
            score = 50;
            scoreIncrement = 2;
            speedLimit = 500;
        }

        dwarf player = new dwarf();         // Defining the initial parameters of the dwarf
        player.col = playFieldWidth / 2;    // The dwarf's initial position is at the middle of the playfield
        player.row = Console.WindowHeight - 1;  // The dwarf is always at the lowest row - 1, because the counitng of the rows starts from 0, so if the row = Console.WindowHeight, there will be an exception
        player.dwarfSymbol = "(0)";         // Defining the symbol for the dwarf
        player.color = ConsoleColor.White;  // Defining the color of the dwarf

        //rock enemy = new rock();            // Defining the falling rocks. I use enemy, since I couldn't think of a better name for the rocks

        Random randomGenerator = new Random();  // A random generator for the falling rocks

        List<rock> rocks = new List<rock>();    // Defining a new list with rocks

        Console.BackgroundColor = ConsoleColor.White;       // Change of the background color of the console. I am sick of that black background
        Console.Clear();                                    // The console has to be cleared on order to change the whole background color




        while (true)
        {
            speed += acceleration;      // Restraining the speed so there is no exception, when there is negative value in the Thread.Sleep function
           
            if (speed > speedLimit)
            {
                speed = speedLimit;
            }

            bool hit = false;

            rock newRock = new rock();                                  // Defining a new rock

            switch(randomGenerator.Next(1, 15))                         // Random choice of a color for a falling rock
            {                                                           // Using switch for both the color and symbol is long, but I cant think of another option
                case 1: newRock.color = ConsoleColor.Black; break;
                case 2: newRock.color = ConsoleColor.Blue; break;
                case 3: newRock.color = ConsoleColor.Cyan; break;
                case 4: newRock.color = ConsoleColor.DarkBlue; break;
                case 5: newRock.color = ConsoleColor.DarkCyan; break;
                case 6: newRock.color = ConsoleColor.DarkGray; break;
                case 7: newRock.color = ConsoleColor.DarkGreen; break;
                case 8: newRock.color = ConsoleColor.DarkMagenta; break;
                case 9: newRock.color = ConsoleColor.DarkRed; break;
                case 10: newRock.color = ConsoleColor.DarkYellow; break;
                case 11: newRock.color = ConsoleColor.Gray; break;
                case 12: newRock.color = ConsoleColor.Green; break;
                case 13: newRock.color = ConsoleColor.Magenta; break;
                case 14: newRock.color = ConsoleColor.Red; break;
            }

            newRock.col = randomGenerator.Next(0, playFieldWidth);      // Random generator for the falling rocks

            switch(randomGenerator.Next(1, 13))                         // Random choice of a symbol for a rock
            {                                                           // Symbols: ^, @, *, &, +, %, $, #, !, ., ;, -
                case 1: newRock.symbol = "^"; break;
                case 2: newRock.symbol = "@"; break;
                case 3: newRock.symbol = "*"; break;
                case 4: newRock.symbol = "&"; break;
                case 5: newRock.symbol = "+"; break;
                case 6: newRock.symbol = "%"; break;
                case 7: newRock.symbol = "$"; break;
                case 8: newRock.symbol = "#"; break;
                case 9: newRock.symbol = "!"; break;
                case 10: newRock.symbol = "."; break;
                case 11: newRock.symbol = ";"; break;
                case 12: newRock.symbol = "-"; break;
            }

            rocks.Add(newRock);

            if (Console.KeyAvailable)                       // Check if a key is pressed
            {
                ConsoleKeyInfo pressedKey = Console.ReadKey(true);

                while (Console.KeyAvailable)                // This is to clear the stored pressed keys, so there is no lag when pressing a button
                {
                    Console.ReadKey();
                }

                if (pressedKey.Key == ConsoleKey.LeftArrow) // Check if the left arrow is pressed
                {
                    if (player.col - 1 >= 0)                // If the player is at 0 column, the dwarf cant go to a lower position
                    {
                        player.col--;                       // Moving the dwarf to the left
                    }
                }
                else if (pressedKey.Key == ConsoleKey.RightArrow)    // Check if the right arrow is pressed
                {
                    if (player.col + 3 < playFieldWidth)        // Check if the dwarf is not going outside the playfield
                    {
                        player.col++;                           // Moving the dwarf to the right
                    }
                }
            }

            Console.Clear();                                    // Clearing of the console after each iteration

            List<rock> newList = new List<rock>();

            for (int i = 0; i < rocks.Count; i++)               // Movement of the rocks
            {
                rock oldRocks = rocks[i];
                rock newRocks = new rock();
                newRocks.col = oldRocks.col;
                newRocks.row = oldRocks.row + 1;
                newRocks.symbol = oldRocks.symbol;
                newRocks.color = oldRocks.color;
                if ((newRocks.col == player.col && newRocks.row == player.row) || (newRocks.col == player.col + 1 && newRocks.row == player.row) || (newRocks.col == player.col + 2 && newRocks.row == player.row))     // Check if the dwarf is hit. The dwarf is composed by three symbols - (0), so it has to be checked if it is hit on any of them
                {
                    lives--;
                    hit = true;

                    if (lives <= 0)         // Check if there are anymore lives left
                    {
                        Console.Clear();
                        PrintOnPosition(Console.WindowHeight / 2 - 5, Console.WindowWidth / 3, "Game over!", ConsoleColor.Red);
                        PrintOnPosition(Console.WindowHeight / 2 - 3, (Console.WindowWidth / 3 - 2), "Final score: " + score, ConsoleColor.Red);
                        PrintOnPosition(Console.WindowHeight / 2 - 1, Console.WindowWidth / 3 - 5, "Press [enter] to exit", ConsoleColor.Red);
                        Console.SetCursorPosition(0, Console.WindowHeight - 1);     // Moves the cursor to a position where it would look a bit better
                        Environment.Exit(0);
                    }
                }
                if (oldRocks.row + 1 < Console.WindowHeight)    // Check if the new position of the rocks is going to be out of the console
                {
                    newList.Add(newRocks);   
                }
            }

            rocks = newList;

            for (int i = 0; i < Console.WindowHeight; i++)      // Loop for drawing the dividing line between the playfield and the information(score, lives, speed, acceleration)
            {
                PrintOnPosition(i, playFieldWidth, "|", ConsoleColor.Red);
            }

            if (hit)
            {
                PrintOnPosition(player.row, player.col, "xXx", player.color = ConsoleColor.Red);    // If being hit, the dwarf symbol changes to indicate that
                score -= 20;        // Penalty for being hit
                rocks.Clear();      // Clearing the falling rocks
            }
            else
            {
                PrintOnPosition(player.row, player.col, player.dwarfSymbol, player.color = ConsoleColor.Black);
            }


            foreach (rock newRocks in rocks)                    // Displaying the falling rocks
            {
                PrintOnPosition(newRocks.row, newRocks.col, newRocks.symbol, newRocks.color);
            }

            score += scoreIncrement;        // Increasing of the score
            
            PrintOnPosition(Console.WindowHeight / 3, (playFieldWidth + playFieldWidth / 3), "Lives remaining: " + lives, ConsoleColor.Black);  // Displaying the remaining lives
            PrintOnPosition(Console.WindowHeight / 3 + 1, (playFieldWidth + playFieldWidth / 3), "Speed: " + speed, ConsoleColor.Black);        // Displaying the current speed
            PrintOnPosition(Console.WindowHeight / 3 + 2, (playFieldWidth + playFieldWidth / 3), "Score: " + score, ConsoleColor.Black);        // Displaying the current score

            Thread.Sleep((int)(550-speed));

        }
    }
}