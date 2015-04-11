
// dnes e hubav den
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace ConsoleWars
{
    // Enemies and players classes are in separate files. The way they are created is supposed to be the right way, according to trainers.

    class Wars
    {
        // Initial data.
        #region
        // Introduction file path.
        const string introFilePath = @"..\..\Introduction\Intro.txt";

        // Highscore file path.
        const string highScorePath = @"..\..\Scores\Highscore.txt";

        const int numberOfEnemiesPerRow = 5;
        const string enemySymbol = "### ";
        const string bullet = "!";   // Tsveti
        static sbyte changedRowCoords = 0;

        // Max window width - 136. Petar.
        static int playFieldHeight = 25;  //change to 30!!!
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
        static int speed = 10;

        static bool firstRowAlive = true;
        static bool secondRowAlive = true;
        static bool thirdRowAlive = true;
        #endregion

        // Methods
        #region
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

        // Saves the highscore in a .txt file. Ivan.
        /// <summary>
        /// Saves the highscore in a .txt file.
        /// </summary>
        /// <param name="playerInitials">The player's initials</param>
        static void HighscoreCheckAndSave(string PlayerInitials)
        {
            //Parameter check.
            #region

            string playerInitials = PlayerInitials;

            if (string.IsNullOrEmpty(playerInitials)) 
            { 
                playerInitials = "AAA";
            }
            if (playerInitials.Length < 3)
            {
                while (playerInitials.Length != 3) { playerInitials += "_"; }
            }
            if (playerInitials.Length > 3)
            {
                playerInitials = playerInitials.Substring(0, 3);
            }
            #endregion

            //Checks if the file exists.
            #region
            if (!File.Exists(highScorePath))
            {
                File.Create(highScorePath).Close();
                StreamWriter highScoreWriter = new StreamWriter(highScorePath);
                using (highScoreWriter)
                {
                    highScoreWriter.WriteLine("0");
                    highScoreWriter.WriteLine("AAA");
                    highScoreWriter.WriteLine(DateTime.Now.ToString("dd/mm/yyyy"));
                }
            }
            #endregion

            //Stores the highscore in a variable "highScore"
            #region

            StreamReader readHighScore = new StreamReader(highScorePath);
            int highScore;
            using (readHighScore)
            {
                if (!(int.TryParse(readHighScore.ReadLine(), out highScore)))
                {
                    throw new ArgumentException("The highScore in HighScore.txt has to be a valid number!");
                }
            }


            #endregion

            //Writes the highscore in the .txt file
            #region
            if (scoreFirstPlayer > highScore)
            {
                Console.WriteLine("You beat the Highscore!");
                Console.WriteLine("Your score is {0}!", scoreFirstPlayer);
                Console.WriteLine("Last highscore was {0}.", highScore);

                File.Delete(highScorePath);
                File.Create(highScorePath).Close();

                Console.WriteLine("File deleted and created again!");

                StreamWriter writeHighScore = new StreamWriter(highScorePath);
                using (writeHighScore)
                {
                    writeHighScore.WriteLine(scoreFirstPlayer);
                    writeHighScore.WriteLine(playerInitials.ToUpper());
                    writeHighScore.WriteLine(DateTime.Now.ToString("dd/mm/yyyy"));
                }
            }
            else
            {
                Console.WriteLine("Game Over!");
                Console.WriteLine("Your score is {0}!", scoreFirstPlayer);
                Console.WriteLine("The highscore is {0}.", highScore);
            }
            #endregion

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
                if (!(enemy.Hit))
                {
                    PrintOnPosition(enemy.Row, enemy.Col, enemy.Symbol);
                }
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
                if (!enemyRow[i].Hit)
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
            int firstIndexOfEnemyRow = numberOfEnemiesPerRow - 1;

            for (int i = enemyRow.Length - 1; i >= 0; i--)
            {
                if (!enemyRow[i].Hit)
                {
                    firstIndexOfEnemyRow = i;
                }
            }

            int colOfFirstEnemyInRow = enemyRow[firstIndexOfEnemyRow].Col;

            return colOfFirstEnemyInRow;
        }

        /// <summary>
        /// Checks if an enemy is hit and if so - deletes it.
        /// </summary>
        /// <param name="EnemyRow">One-dimensional array of enemies</param>
        /// <param name="initaialEnemyRow">First row for the enemies, used to calculate the current row of the enemy</param>
        /// <param name="bullet">Object of type bullet</param>
        /// <param name="changedRowCoords">Counter for travelled rows</param>
        public static void CheckAndDeleteEnemyIfHit(Enemy[] EnemyRow, int initaialEnemyRow, Bullet bullet, int changedRowCoords)
        {
            // int currentElem = 0;
            for (int currentElem = 0; currentElem < EnemyRow.Length; currentElem++)
            {

                if (bullet.visible && EnemyRow[currentElem].Hit == false && (bullet.Col >= EnemyRow[currentElem].Col && bullet.Col <= EnemyRow[currentElem].Col + 2)
                    && bullet.Row == initaialEnemyRow + changedRowCoords)
                {
                    EnemyRow[currentElem].Hit = true;
                    bullet.visible = false;
                }
            }
        }

        /// <summary>
        /// Checks if the intro file exists. If it doesn't - handles possible exceptions.
        /// </summary>
        /// <returns>Valid value for the intro</returns>
        static string GetIntro(string filePath)
        {
            filePath = introFilePath;
            string introText = string.Empty;
            try
            {
                StreamReader readIntro = new StreamReader(filePath);

                using (readIntro)
                {
                    introText = readIntro.ReadToEnd();
                }
            }
            // All possible exceptions for the StreamReader.
            #region
            catch (ArgumentNullException)
            {
                return introText += "Prepare to begin battle...";
            }
            catch (ArgumentException)
            {
                return introText += "Prepare to begin battle...";
            }
            catch (FileNotFoundException)
            {
                return introText += "Prepare to begin battle...";
            }
            catch (DirectoryNotFoundException)
            {
                return introText += "Prepare to begin battle...";
            }
            catch (IOException)
            {
                return introText += "Prepare to begin battle...";
            }
            #endregion

            return introText;
        }

        /// <summary>
        /// Prints valid intro.
        /// </summary>
        /// <param name="filePath">File path of intro.</param>
        static void PrintIntro(string filePath)
        {
            filePath = introFilePath;
            string intro = GetIntro(filePath);

            for (int i = 0; i < intro.Length; i++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(intro[i]);
                Thread.Sleep(100);  //100
            }
            Thread.Sleep(3000);

            Console.CursorVisible = false;

            Console.Clear();
        }

        /// <summary>
        /// Sets the inital sizes of the console. Used for better viewing the intro.
        /// </summary>
        static void SetInitialWindowSize()
        {
            // Set inital console position
            Console.SetWindowPosition(0, 0);
            // Set inital window size.
            Console.BufferHeight = Console.WindowHeight = initailVerticalSizeOfConsole;
            Console.BufferWidth = Console.WindowWidth = initalHorizontalSizeOfConsole;
        }

        /// <summary>
        /// Canges the console size to the required sizes of the playfield.
        /// </summary>
        static void ChangeToPlayfieldWindowSize()
        {
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
        }

        /// <summary>
        /// Draws the scoreboard.
        /// </summary>
        /// <param name="livesLeftString">Lives left.</param>
        /// <param name="scoreString">Score.</param>
        /// <param name="highScoreString">Current highscore.</param>
        static void DrawScoreBoard(string livesLeftString, string scoreString, string highScoreString)
        {
            PrintOnPosition(Console.WindowHeight - scoreBoardHeight + 1, 0, new string('_', playFieldWidth));
            PrintOnPosition(Console.WindowHeight - scoreBoardHeight + 3, 1, livesLeftString);
            PrintOnPosition(Console.WindowHeight - scoreBoardHeight + 5, 1, scoreString);
            PrintOnPosition(Console.WindowHeight - scoreBoardHeight + 7, 1, highScoreString);
        }

        /// <summary>
        /// Calculates the position increment of each enemy row.
        /// </summary>
        /// <param name="maxEnemyGroupCol">The col of the rightmost alive enemy.</param>
        /// <param name="minEnemyGroupCol">The col of the leftmost alive enemy.</param>
        /// <param name="direction">The current direction of movement of the enemies.</param>
        /// <returns>Increment for the movement of enemies.</returns>
        static sbyte[] NewPositionOfEnemies(int maxEnemyGroupCol, int minEnemyGroupCol, sbyte direction)
        {
            // Resets the values, so there is no unwanted behaviour.
            sbyte[] coordinates = new sbyte[] { 0, 0, 0, 0 };

            /*
             * Coding of the array:
             * coordinates[0] = rowsToAdd;
             * coordinates[1] = colsToAdd;
             * coordinates[2] = changedRowCoords;
             * coordinates[3] = direction;
             * direction: 1 -> "right"
             *            -1 -> "left"
             */

            sbyte rowsToAdd;
            sbyte colsToAdd;


            // Check if at rigth most position.
            if ((maxEnemyGroupCol + enemySymbol.Length == playFieldWidth) && direction == 1)
            {
                rowsToAdd = 1;
                colsToAdd = 0;

                changedRowCoords++;
                direction = -1;
                coordinates[0] = rowsToAdd;
                coordinates[1] = colsToAdd;
                coordinates[2] = changedRowCoords;
                coordinates[3] = direction;
                return coordinates;
            }
            // Move right.
            else if ((maxEnemyGroupCol + enemySymbol.Length < playFieldWidth) && direction == 1)
            {
                rowsToAdd = 0;
                colsToAdd = 1;
                coordinates[0] = rowsToAdd;
                coordinates[1] = colsToAdd;
                coordinates[2] = changedRowCoords;
                coordinates[3] = direction;
                return coordinates;


            }
            // Check if at left most position.
            else if ((minEnemyGroupCol == 1) && direction == -1)
            {
                rowsToAdd = 1;
                colsToAdd = 0;

                changedRowCoords++;
                direction = 1;
                coordinates[0] = rowsToAdd;
                coordinates[1] = colsToAdd;
                coordinates[2] = changedRowCoords;
                coordinates[3] = direction;
                return coordinates;
            }
            // Move left.
            else if ((minEnemyGroupCol > 0) && direction == -1)
            {
                rowsToAdd = 0;
                colsToAdd = -1;
                coordinates[0] = rowsToAdd;
                coordinates[1] = colsToAdd;
                coordinates[2] = changedRowCoords;
                coordinates[3] = direction;
                return coordinates;
            }
            return coordinates;
        }
        #endregion

        static void Main()
        {
            Console.Title = "ConsoleWars";

            // Sets the initial sizes of the console.
            SetInitialWindowSize();

            // Print the intro.
            //PrintIntro(introFilePath);

            // Change console sizes to suitable sizes for the game.
            ChangeToPlayfieldWindowSize();

            Console.Clear();

            // Get the difficulty
            //int difficulty = Menu.StartMenu();

            // TODO: Difficulty settings. Petar.
            // Probably include initial life count, speed, etc... Petar.


            //Environment.Exit(0);


            /* switch(difficulty)
             * {
             *   case 1: userLifeCount = 3;
             *           enemiesLifeCount = 1;
             *           enemiesShoot = false;
             *   case 2: userLifeCount = 2;
             *           enemiesLifeCount = 2;
             *           enemiesShoot = true;
             *           delayForTheBullet
             *   case 3: userLifeCount = 1;
             *           enemiesLifeCount = 3;
             *           enemiesShoot = true;
             *           delayForTheBullet
             * }
             */

            // Get the highscore.
            //#region
            //StreamReader readHighscore = new StreamReader(highScorePath);

            int highScore = 0;

            //using (readHighscore)
            //{
            //    highScore = int.Parse(readHighscore.ReadLine());
            //}
            //#endregion

            // Data for the scoreboard.
            #region
            string livesLeftString = "Lives left: " + livesFirstPlayer;
            string scoreString = "Score: " + scoreFirstPlayer;
            string highScoreString = "Highscore: " + highScore;
            #endregion

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

            // Create a bullet.
            #region
            Bullet bullet1 = new Bullet(0, 0);
            bullet1.visible = false;
            #endregion

            // Initial direction.
            sbyte direction = 1;

            while (true)
            {
                // Draw Scoreboard.
                DrawScoreBoard(livesLeftString, scoreString, highScoreString);

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
                    if (keyInfo.Key == ConsoleKey.Spacebar && !(bullet1.visible))   //Tsveti
                    {
                        bullet1.Col = user1.Col + 1;
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

                sbyte[] newCoordinatesOfEnemies = NewPositionOfEnemies(maxEnemyGroupCol, minEnemyGroupCol, direction);

                sbyte rowsToAdd = newCoordinatesOfEnemies[0];
                sbyte colsToAdd = newCoordinatesOfEnemies[1];
                sbyte changedRowCoords = newCoordinatesOfEnemies[2];
                direction = newCoordinatesOfEnemies[3];

                CheckAndDeleteEnemyIfHit(enemyFirstRow, initaialEnemyRow, bullet1, changedRowCoords);
                CheckAndDeleteEnemyIfHit(enemySecondRow, initaialEnemyRow + 2, bullet1, changedRowCoords);
                CheckAndDeleteEnemyIfHit(enemyThirdRow, initaialEnemyRow + 4, bullet1, changedRowCoords);

                //Print enemies on field
                DrawRowOfEnemmies(enemyFirstRow, rowsToAdd, colsToAdd);
                DrawRowOfEnemmies(enemySecondRow, rowsToAdd, colsToAdd);
                DrawRowOfEnemmies(enemyThirdRow, rowsToAdd, colsToAdd);

                //int countDeadBodies = 0;

                //foreach (Enemy enemy in enemyFirstRow)
                //{
                //    if (enemy.Hit == true)
                //    {
                //        countDeadBodies++;
                //    }
                //}

                //if (countDeadBodies == numberOfEnemiesPerRow)
                //{
                //    firstRowAlive = false;
                //}

                foreach (Enemy enemy in enemyFirstRow)
                {
                    if (enemy.Row == user1.Row && enemy.Hit == false)
                    {
                        Console.WriteLine("User Killed");
                        int currentCol = 0;
                        foreach (Enemy enemyNew in enemyFirstRow)
                        {
                            enemyNew.Hit = false;
                            enemy.Row = initaialEnemyRow + 4;
                            enemy.Col = initialEnemyCol + currentCol;
                            currentCol += enemySymbol.Length;

                        }

                        Thread.Sleep(1000);
                    }
                }

                foreach (Enemy enemy in enemySecondRow)
                {
                    if (enemy.Row == user1.Row && enemy.Hit == false)
                    {
                        Console.WriteLine("User Killed");
                        int currentCol = 0;
                        foreach (Enemy enemyNew in enemySecondRow)
                        {
                            enemyNew.Hit = false;
                            enemy.Row = initaialEnemyRow + 2;
                            enemy.Col = initialEnemyCol + currentCol;
                            currentCol += enemySymbol.Length;

                        }
                        Thread.Sleep(1000);
                    }
                }

                foreach (Enemy enemy in enemyThirdRow)
                {
                    if (enemy.Row == user1.Row && enemy.Hit == false)
                    {
                        Console.WriteLine("User Killed");
                        int currentCol = 0;
                        foreach (Enemy enemyNew in enemySecondRow)
                        {
                            enemyNew.Hit = false;
                            enemy.Row = initaialEnemyRow;
                            enemy.Col = initialEnemyCol + currentCol;
                            currentCol += enemySymbol.Length;

                        }
                        Thread.Sleep(1000);
                    }
                }
                #endregion

                // Printing the user.
                PrintOnPosition(user1.Row, user1.Col, user1.Symbol, user1.Color);

                //Print the Bullet Temp Tsveti
                #region
                if (bullet1.visible && bullet1.Row > 0)
                {
                    //if(bullet1.Row==enemyFirstRow.)
                    PrintOnPosition(bullet1.Row, bullet1.Col, bullet);
                    bullet1.ChangePosition();

                }
                else if (bullet1.Row == 0)
                {
                    bullet1.visible = false;
                }
                #endregion

                Thread.Sleep(speed);
                Console.Clear();
            }


            // Implementation of high scores. - Ivan
            HighscoreCheckAndSave("AAA");

        }
    }
}