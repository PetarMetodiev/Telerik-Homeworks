using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Galaxians
{
   
    class GalaxianGame
    {
        //battleship variables
        static int gameFieldWidth = 80;
        static int gameFieldHeigth = 30;
        static int battleShipStartPositionX = gameFieldWidth / 2 - 2 ;
        static int battleShipStartPositionY = gameFieldHeigth - 1;
        static string battleShipShape = "--@--";
        static bool battleShipDestroyed = false;
        //enemy variables
        static int enemyOnePosX = 0;
        static int enemyOnePosY = 0;
        static int enemyTwoPosX = 0;
        static int enemyTwoPosY = 2;
        static int enemyThreePosX = 0;
        static int enemyThreePosY = 4;
        static int maxRowLength = 0;

        static char rocket = '!';
        static bool rocketInSight = false;
        
        static int rocketPositionY = gameFieldHeigth - 1;
        static int rocketPositionX = 0;
        

        static List<string> rowMembersOne = new List<string> { "###", "###", "###", "###", "###", "###", "###"};
        static List<string> rowMembersTwo = new List<string> { "###", "###", "###", "###", "###", "###", "###" };
        static List<string> rowMembersThree = new List<string> { "###", "###", "###", "###", "###", "###", "###" };
        static bool rowExists = true;
        
            

        private static void DrawBattleShip(int x, int y, string symbol)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(symbol);
        }

        private static void DrawEnemies(int x, int y, List<string> rowMembers, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.SetCursorPosition(x, y);
            
            foreach (string memeber in rowMembers )
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(memeber);
                Console.Write(" ");
            }
            
        }

        private static void ShootRocket(int x, int y, char rocket)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(rocket);
        }

        private static void CheckAndDeleteEnemyIfHit(int enemyX, int enemyY, List<string> rowMembers)
        {
            for (int i = 0, j = 0; i < rowMembers.Count * 4; i += 4, j++) // each element takes four places "### " -> rowMembers.Count * 4
            {
                
                if ((rocketPositionX == enemyX + i || rocketPositionX == enemyX + i + 1 || rocketPositionX == enemyX + i + 2)
                    && rocketPositionY == enemyY && rowMembers[j] != "   ")
                {
                    rowMembers[j] = "   ";
                    rocketInSight = false;
                }

                if (rowMembers[rowMembers.Count - 1] == "   ")
                {
                    rowMembers.Remove(rowMembers[rowMembers.Count - 1]);
                }

                if ((battleShipStartPositionX == enemyX + rowMembers.Count * 4|| battleShipStartPositionX + 4 == enemyX)
                    && battleShipStartPositionY == enemyY && rowMembers[j] != "   ")
                {
                    battleShipDestroyed = true;
                    Console.Clear();
                    
                    return;
                }
            }
        }

        private static bool checkIfRowExists(List<string> rowMembers)
        {
            if (!rowMembers.Contains("###"))
            {
                rowMembers.Clear();
                return rowExists = false;
            }
            else
            {
                return rowExists = true;
            }
        }
 
        static void Main()
        {
            Console.BufferHeight = Console.WindowHeight = gameFieldHeigth;
            Console.BufferWidth = Console.WindowWidth = gameFieldWidth;
            Console.CursorVisible = false;

            while (!battleShipDestroyed)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo pressedKey = Console.ReadKey(true);
                    while (Console.KeyAvailable) Console.ReadKey(true);
                    if (pressedKey.Key == ConsoleKey.LeftArrow)
                    {
                        if (battleShipStartPositionX - 1 >= 0)
                        {
                            battleShipStartPositionX--;
                        }
                    }
                    else if (pressedKey.Key == ConsoleKey.RightArrow)
                    {
                        if (battleShipStartPositionX + 1 <= gameFieldWidth - 6)
                        {
                            battleShipStartPositionX++;
                        }
                    }
                    else if (pressedKey.Key == ConsoleKey.Spacebar)
                    {
                        if (!rocketInSight)
                        {
                            rocketPositionX = battleShipStartPositionX + 2;
                            ShootRocket(rocketPositionX, rocketPositionY, rocket);
                            rocketInSight = true;
                        }
                        
                    }
                }

                DrawBattleShip(battleShipStartPositionX, battleShipStartPositionY, battleShipShape);

                if (checkIfRowExists(rowMembersOne))
                {
                    DrawEnemies(enemyOnePosX, enemyOnePosY, rowMembersOne);
                }

                if (checkIfRowExists(rowMembersTwo))
                {
                    DrawEnemies(enemyTwoPosX, enemyTwoPosY, rowMembersTwo);
                }

                if (checkIfRowExists(rowMembersThree))
                {
                    DrawEnemies(enemyThreePosX, enemyThreePosY, rowMembersThree);
                }
                
                
                maxRowLength = Math.Max(rowMembersOne.Count(), Math.Max(rowMembersTwo.Count, rowMembersThree.Count));
                
                
                // move enemies
                if (enemyOnePosX < gameFieldWidth - maxRowLength * 4 && enemyOnePosY % 2 == 0)
                {
                    enemyOnePosX++;
                    enemyTwoPosX++;
                    enemyThreePosX++;
                }
                else if (enemyOnePosX == gameFieldWidth - maxRowLength * 4)
                {
                    enemyThreePosY++;   enemyThreePosX--;
                    enemyTwoPosY++;     enemyTwoPosX--;
                    enemyOnePosY++;     enemyOnePosX--; 
                }
                else if (enemyOnePosX > 0 && enemyOnePosY % 2 != 0)
                {
                    enemyThreePosX--;
                    enemyTwoPosX--;
                    enemyOnePosX--;
                }
                else if (enemyOnePosX == 0)
                {
                    enemyThreePosY++;   enemyThreePosX++;
                    enemyTwoPosY++;     enemyTwoPosX++;
                    enemyOnePosY++;     enemyOnePosX++;
                }

                if (rocketInSight && rocketPositionY > 0)
                {
                    rocketPositionY--;
                    ShootRocket(rocketPositionX, rocketPositionY, rocket);
                }
                else
                {
                    rocketInSight = false;
                    rocketPositionY = gameFieldHeigth - 1;
                }

                CheckAndDeleteEnemyIfHit(enemyOnePosX, enemyOnePosY, rowMembersOne);
                CheckAndDeleteEnemyIfHit(enemyTwoPosX, enemyTwoPosY, rowMembersTwo);
                CheckAndDeleteEnemyIfHit(enemyThreePosX, enemyThreePosY, rowMembersThree);

                Thread.Sleep(50);
                Console.Clear();
            }
            Console.WriteLine("GAME IS OVER".PadLeft(gameFieldWidth / 2, ' '));
        }
    }
}

