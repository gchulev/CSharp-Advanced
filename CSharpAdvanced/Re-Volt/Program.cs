using System;
using System.Linq;

namespace Re_Volt
{
    internal class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int cmdCount = int.Parse(Console.ReadLine());
            char[,] map = new char[n, n];
            int playerRowCoordinate = -1;
            int playerColCoordinate = -1;
            bool playerFinished = false;

            for (int r = 0; r < n; r++)
            {
                char[] inputLine = Console.ReadLine().ToCharArray();
                for (int c = 0; c < n; c++)
                {
                    map[r, c] = inputLine[c];

                    if (map[r, c] == 'f')
                    {
                        playerRowCoordinate = r;
                        playerColCoordinate = c;
                    }
                }
            }
            for (int i = 0; i < cmdCount; i++)
            {
                string command = Console.ReadLine();
                switch (command)
                {
                    case "up":
                        int playerNewRowCoordinate = playerRowCoordinate - 1;
                        int playerNewColCoordinate = playerColCoordinate;
                        if (IsInsideTheMap(playerNewRowCoordinate, playerNewColCoordinate))
                        {
                            if (ReachedFinish(playerNewRowCoordinate, playerNewColCoordinate))
                            {
                                map[playerRowCoordinate, playerColCoordinate] = '-';
                                map[playerNewRowCoordinate, playerNewColCoordinate] = 'f';
                                playerFinished = true;
                                break;
                            }
                            if (IsOnBonus(playerNewRowCoordinate, playerNewColCoordinate))
                            {
                                if (IsInsideTheMap(playerNewRowCoordinate - 1, playerColCoordinate))
                                {
                                    map[playerRowCoordinate, playerColCoordinate] = '-'; //moving the player from its original possition
                                    playerRowCoordinate = playerNewRowCoordinate - 1;
                                    playerColCoordinate = playerNewColCoordinate;
                                    if (map[playerRowCoordinate, playerColCoordinate] == 'F')
                                    {
                                        playerFinished = true;
                                    }
                                    map[playerRowCoordinate, playerColCoordinate] = 'f'; //placing the player to the new possition with the new coordinates
                                }
                                else
                                {
                                    map[playerRowCoordinate, playerNewColCoordinate] = '-'; //clearing player's initial possition
                                    playerRowCoordinate = map.GetLength(0) - 1; //moving the player at the oppsite possition of where he started
                                    map[playerRowCoordinate, playerColCoordinate] = 'f'; //the player is placed at the last row since this is 'up' command and the opposite is down.
                                }
                            }
                            else if (!IsOnTrap(playerNewRowCoordinate, playerNewColCoordinate))
                            {
                                map[playerRowCoordinate, playerColCoordinate] = '-'; //moving from initial possition
                                playerRowCoordinate = playerNewRowCoordinate;
                                playerColCoordinate = playerNewColCoordinate;
                                map[playerRowCoordinate, playerColCoordinate] = 'f'; //placing the player at the new possition
                            }
                        }
                        else
                        {
                            map[playerRowCoordinate, playerColCoordinate] = '-'; //clearing player's initial possition
                            playerRowCoordinate = map.GetLength(0) - 1; //moving the player at the oppsite possition of where he started

                            if (map[playerRowCoordinate, playerColCoordinate] == 'F')
                            {
                                playerFinished = true;
                            }
                            map[playerRowCoordinate, playerColCoordinate] = 'f'; //the player is placed at the last row since this is 'up' command and the opposite is down.
                        }
                        break;
                    case "down":
                        playerNewRowCoordinate = playerRowCoordinate + 1;
                        playerNewColCoordinate = playerColCoordinate;

                        if (IsInsideTheMap(playerNewRowCoordinate, playerNewColCoordinate))
                        {
                            if (ReachedFinish(playerNewRowCoordinate, playerNewColCoordinate))
                            {
                                map[playerRowCoordinate, playerColCoordinate] = '-';
                                map[playerNewRowCoordinate, playerNewColCoordinate] = 'f';
                                playerFinished = true;
                                break;
                            }
                            if (IsOnBonus(playerNewRowCoordinate, playerNewColCoordinate))
                            {
                                if (IsInsideTheMap(playerNewRowCoordinate + 1, playerColCoordinate))
                                {
                                    map[playerRowCoordinate, playerColCoordinate] = '-'; //moving the player from its original possition
                                    playerRowCoordinate = playerNewRowCoordinate + 1;
                                    playerColCoordinate = playerNewColCoordinate;
                                    if (map[playerRowCoordinate, playerColCoordinate] == 'F')
                                    {
                                        playerFinished = true;
                                    }
                                    map[playerRowCoordinate, playerColCoordinate] = 'f'; //placing the player to the new possition with the new coordinates
                                }
                                else
                                {
                                    map[playerRowCoordinate, playerColCoordinate] = '-'; //clearing player's initial possition
                                    playerRowCoordinate = 0; //moving the player at the oppsite possition of where he started
                                    map[playerRowCoordinate, playerColCoordinate] = 'f'; //the player is placed at the start of the column since this is 'down' command
                                }
                            }
                            else if (!IsOnTrap(playerNewRowCoordinate, playerNewColCoordinate))
                            {
                                map[playerRowCoordinate, playerColCoordinate] = '-'; //moving from initial possition
                                playerRowCoordinate = playerNewRowCoordinate;
                                playerColCoordinate = playerNewColCoordinate;
                                map[playerRowCoordinate, playerColCoordinate] = 'f'; //placing the player at the new possition
                            }
                        }
                        else
                        {
                            map[playerRowCoordinate, playerColCoordinate] = '-'; //clearing player's initial possition
                            playerRowCoordinate = 0; //moving the player at the oppsite possition of where he started
                            if (map[playerRowCoordinate, playerColCoordinate] == 'F')
                            {
                                playerFinished = true;
                            }
                            map[playerRowCoordinate, playerColCoordinate] = 'f'; //the player is placed at the last row since this is 'up' command and the opposite is down.
                        }
                        break;
                    case "left":
                        playerNewRowCoordinate = playerRowCoordinate;
                        playerNewColCoordinate = playerColCoordinate - 1;
                        if (IsInsideTheMap(playerNewRowCoordinate, playerNewColCoordinate))
                        {
                            if (ReachedFinish(playerNewRowCoordinate, playerNewColCoordinate))
                            {
                                map[playerRowCoordinate, playerColCoordinate] = '-';
                                map[playerNewRowCoordinate, playerNewColCoordinate] = 'f';
                                playerFinished = true;
                                break;
                            }
                            if (IsOnBonus(playerNewRowCoordinate, playerNewColCoordinate))
                            {
                                if (IsInsideTheMap(playerNewRowCoordinate, playerNewColCoordinate - 1))//check if the next possition after 'B' is not outside the map
                                {
                                    map[playerRowCoordinate, playerColCoordinate] = '-'; //moving the player from its original possition
                                    playerRowCoordinate = playerNewRowCoordinate;
                                    playerColCoordinate = playerNewColCoordinate - 1;
                                    map[playerRowCoordinate, playerColCoordinate] = 'f'; //placing the player to the new possition with the new coordinates
                                }
                                else//the player comes from the other side since he wen out of the matrix
                                {
                                    map[playerRowCoordinate, playerColCoordinate] = '-'; //clearing player's initial possition
                                    playerColCoordinate = map.GetLength(1) - 1; //moving the player at the oppsite possition of where he started
                                    if (map[playerRowCoordinate, playerColCoordinate] == 'F')
                                    {
                                        playerFinished = true;
                                    }
                                    map[playerRowCoordinate, playerColCoordinate] = 'f'; //the player is placed at the start of the column since this is 'down' command
                                }
                            }
                            else if (!IsOnTrap(playerNewRowCoordinate, playerNewColCoordinate))
                            {
                                map[playerRowCoordinate, playerColCoordinate] = '-'; //moving from initial possition
                                playerRowCoordinate = playerNewRowCoordinate;
                                playerColCoordinate = playerNewColCoordinate;
                                map[playerRowCoordinate, playerColCoordinate] = 'f'; //placing the player at the new possition
                            }
                        }
                        else
                        {
                            map[playerRowCoordinate, playerColCoordinate] = '-'; //clearing player's initial possition
                            playerColCoordinate = map.GetLength(1) - 1; ; //moving the player at the oppsite possition of where he started

                            if (map[playerRowCoordinate, playerColCoordinate] == 'F')
                            {
                                playerFinished = true;
                            }
                            map[playerRowCoordinate, playerColCoordinate] = 'f'; //the player is placed at the last row since this is 'up' command and the opposite is down.
                        }
                        break;
                    case "right":
                        playerNewRowCoordinate = playerRowCoordinate;
                        playerNewColCoordinate = playerColCoordinate + 1;
                        if (IsInsideTheMap(playerNewRowCoordinate, playerNewColCoordinate))
                        {
                            if (ReachedFinish(playerNewRowCoordinate, playerNewColCoordinate))
                            {
                                map[playerRowCoordinate, playerColCoordinate] = '-';
                                map[playerNewRowCoordinate, playerNewColCoordinate] = 'f';
                                playerFinished = true;
                                break;
                            }
                            if (IsOnBonus(playerNewRowCoordinate, playerNewColCoordinate))
                            {
                                if (IsInsideTheMap(playerNewRowCoordinate, playerNewColCoordinate + 1))//check if the next possition after 'B' is not outside the map
                                {
                                    map[playerRowCoordinate, playerColCoordinate] = '-'; //moving the player from its original possition
                                    playerRowCoordinate = playerNewRowCoordinate;
                                    playerColCoordinate = playerNewColCoordinate + 1;
                                    map[playerRowCoordinate, playerColCoordinate] = 'f'; //placing the player to the new possition with the new coordinates
                                }
                                else //the player comes from the other side since he wen out of the matrix
                                {
                                    map[playerRowCoordinate, playerColCoordinate] = '-'; //clearing player's initial possition

                                    playerColCoordinate = 0; //moving the player at the oppsite possition of where he started

                                    if (map[playerRowCoordinate, playerColCoordinate] == 'F')
                                    {
                                        playerFinished = true;
                                    }
                                    map[playerRowCoordinate, playerColCoordinate] = 'f'; //the player is placed at the start of the column since this is 'down' command
                                }
                            }
                            else if (!IsOnTrap(playerNewRowCoordinate, playerNewColCoordinate))
                            {
                                map[playerRowCoordinate, playerColCoordinate] = '-'; //moving from initial possition
                                playerRowCoordinate = playerNewRowCoordinate;
                                playerColCoordinate = playerNewColCoordinate;
                                map[playerRowCoordinate, playerColCoordinate] = 'f'; //placing the player at the new possition
                            }
                        }
                        else
                        {
                            map[playerRowCoordinate, playerColCoordinate] = '-'; //clearing player's initial possition
                            playerColCoordinate = 0; ; //moving the player at the oppsite possition of where he started
                            if (map[playerRowCoordinate, playerColCoordinate] == 'F')
                            {
                                playerFinished = true;
                            }
                            map[playerRowCoordinate, playerColCoordinate] = 'f';
                        }
                        break;
                    default:
                        break;
                }
                if (playerFinished)
                {
                    break;
                }
            }
            if (playerFinished)
            {
                Console.WriteLine("Player won!");
            }
            else
            {
                Console.WriteLine("Player lost!");
            }
            PrintMap();

            void PrintMap()
            {
                for (int r = 0; r < map.GetLength(0); r++)
                {
                    for (int c = 0; c < map.GetLength(1); c++)
                    {
                        Console.Write(map[r, c]);
                    }
                    Console.WriteLine();
                }
            }
            bool IsInsideTheMap(int playerNewRowCoordinate, int playerNewColCoordinate)
            {
                if (playerNewRowCoordinate >= 0 && playerNewRowCoordinate < map.GetLength(0) && playerNewColCoordinate >= 0 && playerNewColCoordinate < map.GetLength(1))
                {
                    return true;
                }
                return false;
            }
            bool IsOnBonus(int row, int col)
            {
                if (map[row, col] == 'B')
                {
                    return true;
                }
                return false;
            }
            bool IsOnTrap(int row, int col)
            {
                if (map[row, col] == 'T')
                {
                    return true;
                }
                return false;
            }
            bool ReachedFinish(int row, int col)
            {
                if (map[row, col] == 'F')
                {
                    return true;
                }
                return false;
            }
        }
    }
}
