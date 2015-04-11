// dnes e hubav den
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Media;

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

        // Sound files filepaths
        const string STConsoleResize1 = @"..\..\ConsoleWarsSoundtrack\ConsoleResize1.wav";
        const string STConsoleResize2 = @"..\..\ConsoleWarsSoundtrack\ConsoleResize2.wav";
        const string STIntro = @"..\..\ConsoleWarsSoundtrack\Intro.wav";
        const string STBlast = @"..\..\ConsoleWarsSoundtrack\Blast.wav";
        const string STMenu = @"..\..\ConsoleWarsSoundtrack\Menu.wav";
        static SoundPlayer player = new SoundPlayer();

        static int numberOfEnemiesPerRow = 5;
        static int maxNumberOfEnemiesPerRow = 10;
        const string enemySymbol = "### ";
        const string bullet = "!";   // Tsveti
        static int changedRowCoords = 0;

        // Max window width - 136. Petar.
        static int playFieldHeight = 25;
        static int playFieldWidth = 50;
        static int scoreBoardHeight = 9;
        static int level = 1;
        static int speedIncrement = 5;

        static int initailVerticalSizeOfConsole = 10;
        static int initalHorizontalSizeOfConsole = 80;

        static int verticalSizeOfConsole = initailVerticalSizeOfConsole;

        // These are used for the increasing size of the console window.
        static int maxVerticalSizeConsole = playFieldHeight + scoreBoardHeight;
        static int minHorizontalSizeConsole = playFieldWidth;

        static int initialEnemyCol = 2;
        static int initialEnemyRow = 2; //CHANGE BACK TO 2
        static int minEnemyGroupCol = 0;
        static int maxEnemyGroupCol = 0;

        static bool playerDestroyed = false;

        static int scoreFirstPlayer = 0;
        static int scoreIncrement;
        static int livesFirstPlayer;
        static int speed = 105; // change back to 105
        static int oneMoreLoop = 0;
        static string userSymbol = "_+_";
        static ConsoleColor userColor = ConsoleColor.Red;
        static int maxLevels; // Change to 10

        static string result = String.Empty;

        static int highestScore;
        static string playerName;
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
                if (bullet.visible && EnemyRow[currentElem].Hit == false
                    && (bullet.Col >= EnemyRow[currentElem].Col
                    && bullet.Col <= EnemyRow[currentElem].Col + 2)
                    && bullet.Row == EnemyRow[currentElem].Row) /*initaialEnemyRow + changedRowCoords*/
                {
                    using (SoundPlayer player2 = new SoundPlayer(STBlast))
                    {
                        // Use PlaySync to load and then play the sound.
                        // ... The program will pause until the sound is complete.
                        player2.Play();
                    }
                    EnemyRow[currentElem].Hit = true;
                    bullet.visible = false;
                    scoreFirstPlayer += scoreIncrement;
                    //Console.Beep(12345, 1000);
                }
            }
        }

        /// <summary>
        /// Checks if player is hit by enemy.
        /// </summary>
        static bool CheckIfUserIsDestroyed(Enemy[] EnemyRow, Player user1)
        {
            if (EnemyRow[0].Row == user1.Row)
            {
                for (int i = 0; i < EnemyRow.Length; i++)
                {
                    if (!EnemyRow[i].Hit)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        static bool CheckIfAllEnemiesAreDead(Enemy[] firstEnemyRow, Enemy[] secondEnemyRow, Enemy[] thirdEnemyRow)
        {
            foreach (Enemy enemy in firstEnemyRow)
            {
                if (!enemy.Hit)
                {
                    return false;
                }
            }

            foreach (Enemy enemy in secondEnemyRow)
            {
                if (!enemy.Hit)
                {
                    return false;
                }
            }

            foreach (Enemy enemy in thirdEnemyRow)
            {
                if (!enemy.Hit)
                {
                    return false;
                }
            }

            return true;
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
            using (SoundPlayer player3 = new SoundPlayer())
            {
                player3.SoundLocation = STConsoleResize1;
                player3.Play();
                for (int i = initalHorizontalSizeOfConsole; i > minHorizontalSizeConsole; i--)
                {
                    Console.BufferWidth = Console.WindowWidth -= 1;
                    Thread.Sleep(10);
                }

                player3.Stop();
                player3.SoundLocation = STConsoleResize2;
                player3.Play();

                for (int i = initailVerticalSizeOfConsole; i < maxVerticalSizeConsole; i++)
                {
                    Console.BufferHeight = Console.WindowHeight += 1;
                    Thread.Sleep(10);
                }
                player3.Stop();
            }
        }

        /// <summary>
        /// Draws the scoreboard.
        /// </summary>
        /// <param name="livesLeftString">Lives left.</param>
        /// <param name="scoreString">Score.</param>
        /// <param name="highScoreString">Current highscore.</param>
        static void DrawScoreBoard(string livesLeftString, string scoreString, string highScoreString, string levelString, string speedString, string difficultyString)
        {
            PrintOnPosition(Console.WindowHeight - scoreBoardHeight + 1, 0, new string('_', playFieldWidth));
            PrintOnPosition(Console.WindowHeight - scoreBoardHeight + 3, 1, livesLeftString);
            PrintOnPosition(Console.WindowHeight - scoreBoardHeight + 5, 1, scoreString);
            PrintOnPosition(Console.WindowHeight - scoreBoardHeight + 7, 1, highScoreString);
            PrintOnPosition(Console.WindowHeight - scoreBoardHeight + 3, playFieldWidth / 2, levelString);
            PrintOnPosition(Console.WindowHeight - scoreBoardHeight + 5, playFieldWidth / 2, speedString);
            PrintOnPosition(Console.WindowHeight - scoreBoardHeight + 7, playFieldWidth / 2, difficultyString);
        }

        /// <summary>
        /// Calculates the position increment of each enemy row.
        /// </summary>
        /// <param name="maxEnemyGroupCol">The col of the rightmost alive enemy.</param>
        /// <param name="minEnemyGroupCol">The col of the leftmost alive enemy.</param>
        /// <param name="direction">The current direction of movement of the enemies.</param>
        /// <returns>Increment for the movement of enemies.</returns>
        static int[] NewPositionOfEnemies(int maxEnemyGroupCol, int minEnemyGroupCol, int direction)
        {
            // Resets the values, so there is no unwanted behaviour.
            int[] coordinates = new int[] { 0, 0, 0, 0 };

            /*
             * Coding of the array:
             * coordinates[0] = rowsToAdd;
             * coordinates[1] = colsToAdd;
             * coordinates[2] = changedRowCoords;
             * coordinates[3] = direction;
             * direction: 1 -> "right"
             *            -1 -> "left"
             */

            int rowsToAdd;
            int colsToAdd;


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

        /// <summary>
        /// Prints a message letter by letter.
        /// </summary>
        /// <param name="message">The required message to be printed.</param>
        /// <param name="row">The required row of the message.</param>
        /// <param name="col">The required col of the message.</param>
        /// <param name="speed">Speed for writting the message.</param>
        static void PrintTextLetterByLetterOnPosition(string message, int row, int col, int speed)
        {
            Console.SetCursorPosition(col, row);

            for (int i = 0; i < message.Length; i++)
            {
                Console.Write(message[i]);
                Thread.Sleep(speed);
            }
        }

        //Creates a file if such does not exist
        public static void CreateFile(string highScoreFile)
        {
            if (!File.Exists(highScoreFile))
            {
                try
                {
                    StreamWriter writeHighScore = new StreamWriter(highScoreFile);
                    using (writeHighScore)
                    {
                        writeHighScore.Write("PlayerName Points Date");
                    }
                }
                // All possible exceptions for the StreamReader.
                #region
                catch (ArgumentNullException)
                {

                }
                catch (ArgumentException)
                {

                }
                catch (FileNotFoundException)
                {

                }
                catch (DirectoryNotFoundException)
                {

                }
                catch (IOException)
                {

                }
                #endregion
            }
        }

        //Sets info about the user and the game 
        public static void GetUserAndGameInfo()
        {
            Console.Write("Enter your Initials for the high score: ");
            playerName = Console.ReadLine();

            if (string.IsNullOrEmpty(playerName))
            {
                playerName = "XXX";
            }
            else if (playerName.Length < 3)
            {
                playerName = playerName.PadRight(3, '_');
            }
            else if (playerName.Length > 3)
            {
                playerName = playerName.Substring(0, 3);
            }
            CreateFile(highScorePath);
            highestScore = GetTheHighScore(highScorePath);
            WriteHigherScoreToFile(highScorePath, playerName, scoreFirstPlayer, highestScore);
        }

        //Setting the new highscore
        public static void WriteHigherScoreToFile(string highScoreFile, string playerName, int currentPoints, int highestPoints)
        {
            if (highestPoints <= currentPoints)
            {
                try
                {
                    StreamWriter writeHighScore = new StreamWriter(highScoreFile);
                    using (writeHighScore)
                    {
                        writeHighScore.WriteLine("PlayerName Points Date");
                        writeHighScore.Write("{0}        {1}      {2}", playerName.ToUpper(), currentPoints, DateTime.Now.ToString("dd/mm/yyyy"));
                    }
                }
                #region
                catch (ArgumentNullException)
                {

                }
                catch (ArgumentException)
                {

                }
                catch (FileNotFoundException)
                {

                }
                catch (DirectoryNotFoundException)
                {

                }
                catch (IOException)
                {

                }
                #endregion
            }

        }

        //Getting the new highscore
        public static int GetTheHighScore(string highScoreFile)
        {
            int points = 0;
            if (!File.Exists(highScoreFile))
            {
                return points;
            }
            else
            {
                try
                {
                    StreamReader streamReader = new StreamReader(highScoreFile);

                    using (streamReader)
                    {
                        string line;
                        if ((line = streamReader.ReadLine()) != null)
                        {
                            streamReader.ReadLine();  //skip the first row
                            if ((line = streamReader.ReadLine()) != null)
                            {
                                string[] info = line.Split();
                                points = int.Parse(info[1]);
                            }
                        }
                    }
                }
                // Exceptions.
                #region
                catch (ArgumentNullException)
                {

                }
                catch (ArgumentException)
                {

                }
                catch (FileNotFoundException)
                {

                }
                catch (DirectoryNotFoundException)
                {

                }
                catch (IOException)
                {

                }
                #endregion
                return points;
            }
        }

        /// <summary>
        /// Sets the difficulty of the game.
        /// </summary>
        /// <param name="difficulty">A difficulty chosen by the player.</param>
        static void SetDifficulty(int difficulty)
        {
            switch (difficulty)
            {
                case 1:
                    scoreIncrement = 5;
                    maxLevels = 10;
                    livesFirstPlayer = 2;
                    break;
                case 2:
                    scoreIncrement = 7;
                    maxLevels = 15;
                    livesFirstPlayer = 1;
                    break;
                case 3:
                    scoreIncrement = 10;
                    maxLevels = 20;
                    livesFirstPlayer = 0;
                    break;

                default:
                    break;
            }
        }

        #endregion

        // Play music / sound
        static void PlayMusic(string path)
        {
            try
            {
                player.SoundLocation = path;
                player.Play();

            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Sound file is missing. Unable to initialize sound.");
            }
            catch (TimeoutException)
            {
            }
            catch (InvalidOperationException)
            { 
            }
        }

        // Stop music / sound
        static void StopMusic()
        {
            try
            {
                player.Stop();
            }
            catch (Exception)
            { 
            }
        }

        static void Main()
        {
            Console.Title = "ConsoleWars";
            SoundPlayer player = new SoundPlayer();

            // Sets the initial sizes of the console.
            SetInitialWindowSize();

            // Print the intro and play sound.
            #region
            PlayMusic(STIntro);


            // Print intro
            PrintIntro(introFilePath);

            // Stop sound
            StopMusic();
            #endregion

            // Change console sizes to suitable sizes for the game.
            ChangeToPlayfieldWindowSize();

            Console.Clear();

            // Get the difficulty
            PlayMusic(STMenu);

            int difficulty = Menu.StartMenu();
            SetDifficulty(difficulty);

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

            int highScore = 0;

            // Create player.
            #region
            Player user1 = new Player(playFieldWidth / 2, Console.WindowHeight - scoreBoardHeight, userColor, userSymbol);
            #endregion

            // Create enemies
            #region
            Enemy[] enemyFirstRow = CreateRowOfEnemies(initialEnemyRow, initialEnemyCol, ConsoleColor.Cyan, enemySymbol);
            Enemy[] enemySecondRow = CreateRowOfEnemies(initialEnemyRow + 2, initialEnemyCol, ConsoleColor.Cyan, enemySymbol);
            Enemy[] enemyThirdRow = CreateRowOfEnemies(initialEnemyRow + 4, initialEnemyCol, ConsoleColor.Cyan, enemySymbol);
            #endregion

            // Create a bullet.
            #region
            Bullet bullet1 = new Bullet(0, 0);
            bullet1.visible = false;
            #endregion

            // Initial direction.
            int direction = 1;

            // Stop menu music
            StopMusic();

            while (true)
            {
                Console.Clear();

                // Data for the scoreboard.
                #region
                string livesLeftString = "Lives left: " + (livesFirstPlayer + 1);
                string scoreString = "Score: " + scoreFirstPlayer;
                string highScoreString = "Highscore: " + highScore;
                string speedString = "Speed: " + speedIncrement / 5;
                string levelString = "Level: " + level + " / " + maxLevels;
                string difficultyString = "Difficulty: " + difficulty;

                #endregion

                // Draw Scoreboard.
                DrawScoreBoard(livesLeftString, scoreString, highScoreString, levelString, speedString, difficultyString);

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
                // Gets the col of the furthest enemy.
                maxEnemyGroupCol = Math.Max(GetLastColOfEnemyRow(enemyFirstRow),
                                                Math.Max(GetLastColOfEnemyRow(enemySecondRow),
                                                            GetLastColOfEnemyRow(enemyThirdRow)));

                // Get the col of the closest to zero enemy.

                minEnemyGroupCol = Math.Min(GetFirstColOfEnemyRow(enemyFirstRow),
                                Math.Min(GetFirstColOfEnemyRow(enemySecondRow),
                                            GetFirstColOfEnemyRow(enemyThirdRow)));

                int[] newCoordinatesOfEnemies = NewPositionOfEnemies(maxEnemyGroupCol, minEnemyGroupCol, direction);

                int rowsToAdd = newCoordinatesOfEnemies[0];
                int colsToAdd = newCoordinatesOfEnemies[1];
                int changedRowCoords = newCoordinatesOfEnemies[2];
                direction = newCoordinatesOfEnemies[3];

                //Check each row of enemies, if enemy is hit by the bullet
                CheckAndDeleteEnemyIfHit(enemyFirstRow, initialEnemyRow, bullet1, changedRowCoords);
                CheckAndDeleteEnemyIfHit(enemySecondRow, initialEnemyRow + 2, bullet1, changedRowCoords);
                CheckAndDeleteEnemyIfHit(enemyThirdRow, initialEnemyRow + 4, bullet1, changedRowCoords);

                //Print enemies on field

                DrawRowOfEnemmies(enemyFirstRow, rowsToAdd, colsToAdd);
                DrawRowOfEnemmies(enemySecondRow, rowsToAdd, colsToAdd);
                DrawRowOfEnemmies(enemyThirdRow, rowsToAdd, colsToAdd);
                #endregion

                // Printing the user.
                PrintOnPosition(user1.Row, user1.Col, user1.Symbol, user1.Color);

                //Check if user symbol is destroyed
                playerDestroyed = CheckIfUserIsDestroyed(enemyThirdRow, user1);
                if (!playerDestroyed)
                {
                    playerDestroyed = CheckIfUserIsDestroyed(enemySecondRow, user1);
                }
                if (!playerDestroyed)
                {
                    playerDestroyed = CheckIfUserIsDestroyed(enemyFirstRow, user1);
                }


                // If user is destroyed or hit
                if (playerDestroyed && livesFirstPlayer > 0)
                {
                    playerDestroyed = false;
                    for (int i = 0; i < enemyFirstRow.Length; i++)
                    {
                        enemyThirdRow[i].Row = initialEnemyRow + 4;
                        enemySecondRow[i].Row = initialEnemyRow + 2;
                        enemyFirstRow[i].Row = initialEnemyRow;
                        changedRowCoords = initialEnemyRow - 2;
                    }

                    livesFirstPlayer--;
                    PrintOnPosition(user1.Row, user1.Col, "XXX", ConsoleColor.Red);

                    enemyFirstRow = CreateRowOfEnemies(initialEnemyRow, initialEnemyCol, ConsoleColor.Cyan, enemySymbol);
                    enemySecondRow = CreateRowOfEnemies(initialEnemyRow + 2, initialEnemyCol, ConsoleColor.Cyan, enemySymbol);
                    enemyThirdRow = CreateRowOfEnemies(initialEnemyRow + 4, initialEnemyCol, ConsoleColor.Cyan, enemySymbol);
                    Thread.Sleep(500);
                    Console.Clear();

                    DrawScoreBoard(livesLeftString, scoreString, highScoreString, levelString, speedString, difficultyString);
                    PrintOnPosition(user1.Row, user1.Col, "XXX", ConsoleColor.Red);

                    PrintOnPosition(playFieldHeight / 2, playFieldWidth / 2 - 10, "You have lost a life!", ConsoleColor.Green);
                    Thread.Sleep(2000);

                    user1.Symbol = userSymbol;
                    user1.Color = userColor;
                }
                else if (playerDestroyed && livesFirstPlayer < 1)
                {
                    if (oneMoreLoop == 0)
                    {
                        oneMoreLoop = 1;
                        continue;
                    }
                    else
                    {
                        result = "loose";
                        break;
                    }
                }



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

                bool NoOneAlive = CheckIfAllEnemiesAreDead(enemyFirstRow, enemySecondRow, enemyThirdRow);
                if (NoOneAlive)
                {
                    Console.Clear();
                    DrawScoreBoard(livesLeftString, scoreString, highScoreString, levelString, speedString, difficultyString);
                    speed -= speedIncrement;
                    speedIncrement += 5;

                    if (level % 2 == 0)
                    {
                        numberOfEnemiesPerRow++;
                    }

                    if (numberOfEnemiesPerRow > maxNumberOfEnemiesPerRow)
                    {
                        numberOfEnemiesPerRow = 10;
                    }

                    level++;

                    if (level > maxLevels)
                    {
                        result = "win";
                        break;
                    }

                    PrintOnPosition(playFieldHeight / 2, playFieldWidth / 2 - 4, "LEVEL: " + level, ConsoleColor.Green);
                    Thread.Sleep(1000);

                    enemyFirstRow = CreateRowOfEnemies(initialEnemyRow, initialEnemyCol, ConsoleColor.Cyan, enemySymbol);
                    enemySecondRow = CreateRowOfEnemies(initialEnemyRow + 2, initialEnemyCol, ConsoleColor.Cyan, enemySymbol);
                    enemyThirdRow = CreateRowOfEnemies(initialEnemyRow + 4, initialEnemyCol, ConsoleColor.Cyan, enemySymbol);

                }

                Thread.Sleep(speed);
            } // END OF WHILE LOOP


            if (result == "loose")
            {
                string gameOverMessage1 = "You were not worthy enough!";
                string gameOverMessage2 = "You were unable to defend your hard drive!";
                string gameOverMessage3 = "Your score: " + scoreFirstPlayer;
                string gameOver = "GAME OVER!";

                PrintTextLetterByLetterOnPosition(gameOverMessage1, playFieldHeight / 2, 10, 100);
                PrintTextLetterByLetterOnPosition(gameOverMessage2, playFieldHeight / 2 + 1, 3, 100);
                PrintTextLetterByLetterOnPosition(gameOverMessage3, playFieldHeight / 2 + 2, 10, 100);

                Thread.Sleep(500);
                PrintOnPosition(playFieldHeight / 2 + 5, playFieldWidth / 2 - 5, gameOver, ConsoleColor.Red);
                Console.WriteLine();
            }
            else if (result == "win")
            {
                Console.WriteLine("You have won the game!");
            }

            GetUserAndGameInfo();
            PrintOnPosition(5, 15, "HIGH SCORE: ", ConsoleColor.Red);
            PrintOnPosition(5, 28, playerName.ToUpper(), ConsoleColor.Red);
            PrintOnPosition(5, 32, highScore.ToString(), ConsoleColor.Red);
            Console.SetCursorPosition(12, Console.WindowHeight - 1);
        }
    }
}