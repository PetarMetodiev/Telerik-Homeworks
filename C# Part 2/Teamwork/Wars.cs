using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ConsoleWars
{
    // Enemies and players classes are in separate files. The way they are created is supposed to be the right way, according to trainers.

    class Wars
    {
        // Introduction.
        const string introFilePath = @"..\..\Introduction\Intro.txt";

        // Getting the highscore.
        const string highScorePath = @"..\..\Scores\Highscore.txt";

        const int numberOfEnemiesPerRow = 5;
        const string enemySymbol = "### ";
        const string bullet = "!";   // Tsveti

        // Max window width - 136. Petar.
        static int playFieldHeight = 30;
        static int playFieldWidth = 50;
        //static int playField2 = 50;
        static int scoreBoardHeight = 9;
        //static int scoreBoard2 = 18;

        static int initailVerticalSizeOfConsole = 10;
        static int initalHorizontalSizeOfConsole = 80;

        static int verticalSizeOfConsole = initailVerticalSizeOfConsole;

        // These are used for the increasing size of the console window.
        static int maxVerticalSizeConsole = playFieldHeight + scoreBoardHeight;
        static int minHorizontalSizeConsole = playFieldWidth;

        static int initialEnemyCol = playFieldWidth / 2;
        static int initaialEnemyRow = 2;

        static int scoreFirstPlayer = 0;
        static int scoreSecondPlayer = 0;
        static int livesFirstPlayer = 5;
        static int livesSecondPlayer = 0;
        static int speed = 100;

        // Printing a required element on a required position. Petar.
        /// <summary>
        /// Prints a string on a specified position.
        /// </summary>
        /// <param name="row">Required row</param>
        /// <param name="col">Required col</param>
        /// <param name="c">String to be printed</param>
        /// <param name="color">Text color to be used, default value is gray.</param>
        static void PrintOnPosition(int row, int col, string c, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.SetCursorPosition(col, row);
            Console.ForegroundColor = color;
            Console.Write(c);
        }

        // Move first player left. Vlade2
        /// <summary>
        /// Moves the first player to the left.
        /// </summary>
        /// <param name="col">A required new position to the left</param>
        /// <returns>Valid position for the player</returns>
        static int MoveFirstPlayerLeft(int col)
        {
            if (col > 0)
            {
                col--;
            }

            return col;
        }

        // Move first player right. Vlade2
        /// <summary>
        /// Moves the first player to the right.
        /// </summary>
        /// <param name="col">A required new position to the right</param>
        /// <param name="symbol">The symbol of the player. Used only for its length</param>
        /// <returns>Valid position for the player</returns>
        static int MoveFirstPlayerRight(int col, string symbol)
        {
            if (col < playFieldWidth - symbol.Length)
            {
                col++;
            }
            return col;
        }

        /// <summary>
        /// Creats a single row of enemies.
        /// </summary>
        /// <param name="row">Inital row of the lefmost enemy</param>
        /// <param name="col">Initial col of the leftmost enemy</param>
        /// <param name="color">Color of the enemies</param>
        /// <param name="symbol">Symbol for the enemies</param>
        /// <returns>An array of enemies.</returns>
        static Enemy[] CreateRowOfEnemies(int row, int col, ConsoleColor color, string symbol)
        {
            Enemy[] rowOfEnemies = new Enemy[numberOfEnemiesPerRow];
            int currCol = col;

            for (int count = 0; count < numberOfEnemiesPerRow; count++)
            {
                rowOfEnemies[count] = new Enemy(row, currCol);
                currCol += enemySymbol.Length;
            }

            return rowOfEnemies;


        }

        /// <summary>
        /// Draws a row of enemies at certain position
        /// </summary>
        /// <param name="rowOfEnemies">An array of enemies</param>
        /// <param name="addedRow">If required, adds a row(for going to a new line)</param>
        /// <param name="addedCol">If required, adds a col(for moving left or right)</param>
        static void DrawRowOfEnemmies(Enemy[] rowOfEnemies, int addedRow, int addedCol)
        {

            foreach (var enemy in rowOfEnemies)
            {
                PrintOnPosition(enemy.Row, enemy.Col, enemy.Symbol);
                enemy.Row += addedRow;
                enemy.Col += addedCol;
            }
        }

        /// <summary>
        /// Gets the last col of a given array(row) of enemies
        /// </summary>
        /// <param name="enemyRow">Array(row) of enemies</param>
        /// <returns>The position of the last alive enemy on the current row</returns>
        static int GetLastColOfEnemyRow(Enemy[] enemyRow)
        {
            int lastIndexOfEnemyRow = 0;

            for (int i = 0; i < enemyRow.Length; i++)
            {
                if (enemyRow[i].Symbol == enemySymbol)
                {
                    lastIndexOfEnemyRow = i;
                }
            }

            int colOflastEnemyInRow = enemyRow[lastIndexOfEnemyRow].Col;

            return colOflastEnemyInRow;
        }

        /// <summary>
        /// Gets the first col of a given array(row) of enemies
        /// </summary>
        /// <param name="enemyRow">Array(row) of enemies</param>
        /// <returns>The position of the first alive enemy on the current row</returns>
        static int GetFirstColOfEnemyRow(Enemy[] enemyRow)
        {
            int lastIndexOfEnemyRow = 0;

            for (int i = enemyRow.Length - 1; i >= 0; i--)
            {
                if (enemyRow[i].Symbol == enemySymbol)
                {
                    lastIndexOfEnemyRow = i;
                }
            }

            int colOflastEnemyInRow = enemyRow[lastIndexOfEnemyRow].Col;

            return colOflastEnemyInRow;
        }

        static void Main()
        {
            Bullet bullet1 = new Bullet(0, 0);
            bullet1.visible = false;

            Console.Title = "ConsoleWars";

            // Set inital sizes of the console.
            #region
            // Set inital window size.
            Console.BufferHeight = Console.WindowHeight = initailVerticalSizeOfConsole;
            Console.BufferWidth = Console.WindowWidth = initalHorizontalSizeOfConsole;
            // Set inital console position
            Console.SetWindowPosition(0, 0);
            #endregion

            // TODO: Difficulty settings. Petar.
            // Probably include initial life count, speed, etc... Petar.

            // Just a flag to show the direction of movement of the enemies. Petar.
            string direction = "right";

            // Print the intro.
            #region
            StreamReader readIntro = new StreamReader(introFilePath);
            Console.Clear();

            using (readIntro)
            {
                string intro = readIntro.ReadToEnd();

                for (int i = 0; i < intro.Length; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(intro[i]);
                    Thread.Sleep(100);
                }
            }

            Thread.Sleep(3000);
            #endregion

            Console.Clear();

            // Change window size.
            #region
            for (int i = initalHorizontalSizeOfConsole; i > minHorizontalSizeConsole; i--)
            {
                Console.BufferWidth = Console.WindowWidth -= 1;
                Thread.Sleep(10);
            }

            for (int i = initailVerticalSizeOfConsole; i < maxVerticalSizeConsole; i++)
            {
                Console.BufferHeight = Console.WindowHeight += 1;
                Thread.Sleep(10);
            }
            #endregion

            // Get the highscore.
            #region
            StreamReader readHighscore = new StreamReader(highScorePath);

            int highScore;

            using (readHighscore)
            {
                highScore = int.Parse(readHighscore.ReadLine());
            }
            #endregion

            string livesLeftString = "Lives left: " + livesFirstPlayer;
            string scoreString = "Score: " + scoreFirstPlayer;
            string highScoreString = "Highscore: " + highScore;

            // Create player.
            #region
            Player user1 = new Player(playFieldWidth / 2, Console.WindowHeight - scoreBoardHeight, ConsoleColor.Red, "_+_");
            #endregion

            // Create enemies
            #region
            Enemy[] enemyFirstRow = CreateRowOfEnemies(initaialEnemyRow, initialEnemyCol, ConsoleColor.Cyan, enemySymbol);
            Enemy[] enemySecondRow = CreateRowOfEnemies(initaialEnemyRow + 2, initialEnemyCol, ConsoleColor.Cyan, enemySymbol);
            Enemy[] enemyThirdRow = CreateRowOfEnemies(initaialEnemyRow + 4, initialEnemyCol, ConsoleColor.Cyan, enemySymbol);
            #endregion


            while (true)
            {
                // Draw Scoreboard.
                PrintOnPosition(Console.WindowHeight - scoreBoardHeight + 1, 0, new string('_', playFieldWidth));
                PrintOnPosition(Console.WindowHeight - scoreBoardHeight + 3, 1, livesLeftString);
                PrintOnPosition(Console.WindowHeight - scoreBoardHeight + 5, 1, scoreString);
                PrintOnPosition(Console.WindowHeight - scoreBoardHeight + 7, 1, highScoreString);

                // Move players. Vlade2
                #region
                if (Console.KeyAvailable)
                {
                    // Move player
                    ConsoleKeyInfo keyInfo = Console.ReadKey();
                    while (Console.KeyAvailable) Console.ReadKey(true); // Eliminates latency in movements of players 

                    if (keyInfo.Key == ConsoleKey.LeftArrow)
                    {
                        user1.Col = MoveFirstPlayerLeft(user1.Col);
                    }
                    if (keyInfo.Key == ConsoleKey.RightArrow)
                    {
                        user1.Col = MoveFirstPlayerRight(user1.Col, user1.Symbol);
                    }
                    if (keyInfo.Key == ConsoleKey.Spacebar)   //temp Tsveti  ------------------------------------
                    {
                        bullet1.Col = user1.Col;
                        bullet1.Row = user1.Row - 1;
                        bullet1.visible = true;
                    }
                }
                #endregion

                // Check and print enemies.
                #region
                // Gets the col of the furthes enemy.
                int maxEnemyGroupCol = Math.Max(GetLastColOfEnemyRow(enemyFirstRow),
                                                    Math.Max(GetLastColOfEnemyRow(enemySecondRow),
                                                                GetLastColOfEnemyRow(enemyThirdRow)));

                // Get the col of the closest to zero enemy.
                int minEnemyGroupCol = Math.Min(GetFirstColOfEnemyRow(enemyFirstRow),
                                    Math.Min(GetFirstColOfEnemyRow(enemySecondRow),
                                                GetFirstColOfEnemyRow(enemyThirdRow)));

                // Resets the values, so there is no unwanted behaviour.
                int rowsToAdd = 0;
                int colsToAdd = 0;

                // Check if at rigth most position.
                if ((maxEnemyGroupCol + enemySymbol.Length == playFieldWidth) && direction == "right")
                {
                    rowsToAdd = 1;
                    colsToAdd = 0;

                    direction = "left";
                }
                // Move right.
                else if ((maxEnemyGroupCol + enemySymbol.Length < playFieldWidth) && direction == "right")
                {
                    rowsToAdd = 0;
                    colsToAdd = 1;


                }
                // Check if at left most position.
                else if ((minEnemyGroupCol == 1) && direction == "left")
                {
                    rowsToAdd = 1;
                    colsToAdd = 0;


                    direction = "right";
                }
                // Move left.
                else if ((minEnemyGroupCol > 0) && direction == "left")
                {
                    rowsToAdd = 0;
                    colsToAdd = -1;
                }

                //Print enemies on field
                DrawRowOfEnemmies(enemyFirstRow, rowsToAdd, colsToAdd);
                DrawRowOfEnemmies(enemySecondRow, rowsToAdd, colsToAdd);
                DrawRowOfEnemmies(enemyThirdRow, rowsToAdd, colsToAdd);
                #endregion

                // Printing the user.
                PrintOnPosition(user1.Row, user1.Col, user1.Symbol, user1.Color);

                //Print the Bullet Temp Tsveti
                #region
                if (bullet1.visible)
                {
                    PrintOnPosition(bullet1.Row, bullet1.Col, bullet);
                    bullet1.ChangePosition();
                }
                #endregion

                Thread.Sleep(speed);
                Console.Clear();
            }


            // Implementation of high scores.

            // Check if highscore is met.
            #region
            if (scoreFirstPlayer > highScore)
            {
                Console.WriteLine("You beat the Highscore!");
                Console.WriteLine("Your score is {0}!", scoreFirstPlayer);
                Console.WriteLine("Last highscore was {0}.", highScore);

                StreamWriter writeHighScore = new StreamWriter(highScorePath);
                using (writeHighScore)
                {
                    writeHighScore.WriteLine(scoreFirstPlayer);
                }

            }
            else
            {
                Console.WriteLine("Game over.");
                Console.WriteLine("Your score is {0}.", scoreFirstPlayer);
            }
            #endregion
        }
    }
}