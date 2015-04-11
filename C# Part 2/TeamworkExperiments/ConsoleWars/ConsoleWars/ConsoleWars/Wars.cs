using System;
using System.Threading;

namespace ConsoleWars
{
    struct player
    {
        // Col of the player. Petar.
        public int col;
        // Row of the player. Petar.
        public int row;
        // Color of the player. Petar.
        public ConsoleColor color;
        // Symbol of the player. Petar.
        public string symbol;
    }

    // Napravih Player da e obekt i chast ot klas // Iztrii komentara kato go pro4ete6
    // Player
    public class Player
    {
        // Col of the player. Petar.
        public int Col;
        // Row of the player. Petar.
        public int Row;
        // Color of the player. Petar.
        public ConsoleColor Color;
        // Symbol of the player. Petar.
        public string Symbol;
        // Player object
        public Player(int col, int row, ConsoleColor color, string symbol)
        {
            Col = col;
            Row = row;
            Color = color;
            Symbol = symbol;
        }
    }

    class Wars
    {
        // Printing a required element on a required position. Petar.
        static void PrintOnPosition(int row, int col, string c, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.SetCursorPosition(col, row);
            Console.ForegroundColor = color;
            Console.Write(c);
        }

        static void Main()
        {
            Console.Title = "ConsoleWars";
            Console.CursorVisible = false; // Hide cursor. Vlade2

            // Max window width - 136. Petar.
            int playField1 = 50;
            int playField2 = 50;
            int scoreBoard1 = 18;
            int scoreBoard2 = 18;

            Console.BufferHeight = Console.WindowHeight = 20;
            Console.BufferWidth = Console.WindowWidth = playField1 + scoreBoard1 + playField2 + scoreBoard2;

            int scoreFirstPlayer = 0;
            int scoreSecondPlayer = 0;
            int livesFirstPlayer = 0;
            int livesSecondPlayer = 0;
            int speed;

            // Test player 
            Player test = new Player(scoreBoard1 + playField1 / 2, Console.WindowHeight - 1, ConsoleColor.Red, "_+_");

            // TODO: Difficulty settings. Petar.
            // Probably include initial life count, speed, etc... Petar.

            player user1 = new player();
            user1.col = scoreBoard1 + playField1 / 2;
            user1.row = Console.WindowHeight - 1;
            user1.symbol = "_+_";
            user1.color = ConsoleColor.Red;

            player user2 = new player();
            user2.col = scoreBoard1 + playField1 + playField2 / 2;
            user2.row = Console.WindowHeight - 1;
            user2.symbol = "_+_";
            user2.color = ConsoleColor.Blue;

            while (true)
            {
                // Cikulut bavi i miga (Iztrii kato pro4ete6)
                // Loop for drawing the dividing lines between the playfields and the information(score, lives, speed, acceleration) for each player. Petar.
                //for (int i = 0; i < Console.WindowHeight; i++)
                //{
                //    PrintOnPosition(i, scoreBoard1, "|", ConsoleColor.Red);
                //    PrintOnPosition(i, scoreBoard1 + playField1, "|", ConsoleColor.Red);
                //    PrintOnPosition(i, scoreBoard1 + playField1 + playField2, "|", ConsoleColor.Red);

                //}

                // Move players. Vlade2
                if (Console.KeyAvailable)
                {
                    // Move second player
                    ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                    while (Console.KeyAvailable)                // This is to clear the stored pressed keys, so there is no lag when pressing a button
                    {
                        Console.ReadKey();
                    }
                    if (keyInfo.Key == ConsoleKey.LeftArrow)
                    {
                        user2.col--;
                    }
                    if (keyInfo.Key == ConsoleKey.RightArrow)
                    {
                        user2.col++;
                    }

                    // Move first player
                    if (keyInfo.Key == ConsoleKey.A)
                    {
                        test.Col--;
                    }
                    if (keyInfo.Key == ConsoleKey.D)
                    {
                        test.Col++;
                    }
                }

                // Example of separation of the plafield. Petar.
                PrintOnPosition(1, 0, "Scores 1 player", ConsoleColor.White);
                PrintOnPosition(1, scoreBoard1 + playField1 / 4, "Playfield 1 player", ConsoleColor.White);
                PrintOnPosition(1, scoreBoard1 + playField1 + playField2 / 4, "Playfield 2 player", ConsoleColor.White);
                PrintOnPosition(1, scoreBoard1 + playField1 + playField2 + 1, "Scores 2 player", ConsoleColor.White);

                // These have to be placed in a loop for moving the users. I put them here only to show initial positions. Petar.
                //PrintOnPosition(user1.row, user1.col, user1.symbol, user1.color);
                PrintOnPosition(user2.row, user2.col, user2.symbol, user2.color);
                PrintOnPosition(test.Row, test.Col, test.Symbol, test.Color);
                Thread.Sleep(200);
                Console.Clear();
            }
        }
    }
}