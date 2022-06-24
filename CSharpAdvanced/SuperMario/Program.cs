using System;
using System.Linq;

namespace SuperMario
{
    internal class Program
    {
        static void Main()
        {
            int lives = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            char[][] maze = new char[n][];
            int marioRow = -1;
            int marioCol = -1;

            for (int r = 0; r < n; r++)
            {
                char[] inputLine = Console.ReadLine().ToCharArray();
                maze[r] = inputLine;
                for (int c = 0; c < maze[r].Length; c++)
                {
                    if (maze[r][c] == 'M')
                    {
                        marioRow = r;
                        marioCol = c;
                    }
                }
            }

            while (true)
            {
                string[] input = Console.ReadLine().Split();
                string command = input[0];
                int row = int.Parse(input[1]);
                int col = int.Parse(input[2]);

                SpawnEnemy(row, col);
                MoveMario(command);

                //checking if Mario died
                if (lives <= 0)
                {
                    Console.WriteLine($"Mario died at {marioRow};{marioCol}.");
                    break;
                }
                //checking if Mario saved the princess
                if (!maze.Any(arr => arr.Any(x => x.Equals('P'))))
                {
                    Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
                    break;
                }
            }
            PrintMaze();


            void SpawnEnemy(int row, int col)
            {
                maze[row][col] = 'B';
            }

            bool CanMove(int row, int col)
            {
                if (row >= 0 && row < maze.Length && col >= 0 && col < maze[row].Length)
                {
                    return true;
                }
                return false;
            }

            void MoveMario(string command)
            {
                lives--;
                if (command.Equals("W"))//up
                {
                    if (CanMove(marioRow - 1, marioCol))
                    {
                        maze[marioRow][marioCol] = '-';//clear Mario's initial possition since he can move
                        if (maze[marioRow - 1][marioCol] == 'B')
                        {
                            lives -= 2;
                            if (lives <= 0)
                            {
                                maze[marioRow - 1][marioCol] = 'X';
                                marioRow--;
                            }
                            else
                            {
                                maze[marioRow - 1][marioCol] = 'M';
                                marioRow--;
                            }
                        }
                        else if (maze[marioRow - 1][marioCol] == 'P')//check if he reaches the princess
                        {
                            maze[marioRow - 1][marioCol] = '-'; //Mario and the princess dissapear from the maze
                        }
                        else //if thre is nothing
                        {
                            if (lives <= 0)
                            {
                                maze[marioRow - 1][marioCol] = 'X';
                                marioRow--;
                            }
                            else
                            {
                                maze[marioRow - 1][marioCol] = 'M';
                                marioRow--;
                            }
                        }
                    }

                    else
                    {

                        if (lives <= 0)
                        {
                            maze[marioRow][marioCol] = 'X';
                        }
                    }
                }
                else if (command.Equals("S"))//down
                {
                    if (CanMove(marioRow + 1, marioCol))
                    {
                        maze[marioRow][marioCol] = '-';//clear Mario's initial possition
                        if (maze[marioRow + 1][marioCol] == 'B')
                        {
                            lives -= 2;
                            if (lives <= 0)
                            {
                                maze[marioRow + 1][marioCol] = 'X';
                                marioRow++;
                            }
                            else
                            {
                                maze[marioRow + 1][marioCol] = 'M';
                                marioRow++;
                            }
                        }
                        else if (maze[marioRow + 1][marioCol] == 'P')//check if he reaches the princess
                        {
                            maze[marioRow + 1][marioCol] = '-'; //Mario and the princess dissapear from the maze
                        }
                        else //if there is nothing
                        {
                            if (lives <= 0)
                            {
                                maze[marioRow + 1][marioCol] = 'X';
                                marioRow++;
                            }
                            else
                            {
                                maze[marioRow + 1][marioCol] = 'M';
                                marioRow++;
                            }
                        }
                    }
                    else
                    {
                        if (lives <= 0)
                        {
                            maze[marioRow][marioCol] = 'X';
                        }
                    }
                }
                else if (command.Equals("A"))//left
                {
                    if (CanMove(marioRow, marioCol - 1))
                    {
                        maze[marioRow][marioCol] = '-'; //clear the initial possition
                        if (maze[marioRow][marioCol - 1] == 'B')
                        {
                            lives -= 2;
                            if (lives <= 0)
                            {
                                maze[marioRow][marioCol - 1] = 'X';
                                marioCol--;
                            }
                            else
                            {
                                maze[marioRow][marioCol - 1] = 'M'; //moving Mario to his new location
                                marioCol--;
                            }
                        }
                        else if (maze[marioRow][marioCol - 1] == 'P')//check if he reaches the princess
                        {
                            maze[marioRow][marioCol - 1] = '-';//both disappear
                        }
                        else //if there is nothing
                        {
                            if (lives <= 0)
                            {
                                maze[marioRow][marioCol - 1] = 'X';//Mario dies
                                marioCol--;
                            }
                            else
                            {
                                maze[marioRow][marioCol - 1] = 'M'; //Mario moves to the new possition
                                marioCol--;
                            }
                        }
                    }
                    else
                    {
                        if (lives <= 0)
                        {
                            maze[marioRow][marioCol] = 'X';
                        }
                    }
                }
                else if (command.Equals("D"))//right
                {
                    if (CanMove(marioRow, marioCol + 1))
                    {
                        maze[marioRow][marioCol] = '-';
                        if (maze[marioRow][marioCol + 1] == 'B')
                        {
                            lives -= 2;
                            if (lives <= 0)
                            {
                                maze[marioRow][marioCol + 1] = 'X'; //Mario dies at the new possition
                                marioCol++;
                            }
                            else
                            {
                                maze[marioRow][marioCol + 1] = 'M';//Mario moves to the new possition after defeating the enemy
                                marioCol++;
                            }
                        }
                        else if (maze[marioRow][marioCol + 1] == 'P')//check if he reaches the princess
                        {
                            maze[marioRow][marioCol + 1] = '-';//Mario and the princess disappear
                        }
                        else //if there is nothing
                        {
                            if (lives <= 0)
                            {
                                maze[marioRow][marioCol + 1] = 'X';
                                marioCol++;
                            }
                            else
                            {
                                maze[marioRow][marioCol] = 'M';
                                marioCol++;
                            }
                        }
                    }
                    else
                    {
                        if (lives <= 0)
                        {
                            maze[marioRow][marioCol] = 'X';
                        }
                    }
                }
            }

            void PrintMaze()
            {
                for (int r = 0; r < n; r++)
                {
                    for (int c = 0; c < maze[r].Length; c++)
                    {
                        Console.Write(maze[r][c]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
