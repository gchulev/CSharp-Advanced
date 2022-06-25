using System;

namespace WallDestroyer
{
    internal class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            char[,] wall = new char[n, n];
            int vRow = -1;
            int vCol = -1;
            int holesCounter = 1;
            int rodsCounter = 0;

            for (int r = 0; r < n; r++)
            {
                char[] inputLine = Console.ReadLine().ToCharArray();

                for (int c = 0; c < n; c++)
                {
                    wall[r, c] = inputLine[c];
                    if (wall[r, c] == 'V')
                    {
                        vRow = r;
                        vCol = c;
                    }
                }
            }

            bool isElectrocuted = false;

            while (true)
            {
                string command = Console.ReadLine();
                if (command.Equals("End"))
                {
                    break;
                }
                if (command.Equals("up"))
                {

                    if (IsInsideTheWallArea(vRow - 1, vCol))
                    {
                        MoveVanko(vRow - 1, vCol);
                    }
                }
                else if (command.Equals("down"))
                {
                    if (IsInsideTheWallArea(vRow + 1, vCol))
                    {
                        MoveVanko(vRow + 1, vCol);
                    }
                }
                else if (command.Equals("left"))
                {
                    if (IsInsideTheWallArea(vRow, vCol - 1))
                    {
                        MoveVanko(vRow, vCol - 1);
                    }
                }
                else if (command.Equals("right"))
                {
                    if (IsInsideTheWallArea(vRow, vCol + 1))
                    {
                        MoveVanko(vRow, vCol + 1);
                    }
                }
                if (isElectrocuted)
                {
                    //check if we have to do stuff rist!!!
                    break;
                }
            }

            if (isElectrocuted == false)
            {
                Console.WriteLine($"Vanko managed to make {holesCounter} hole(s) and he hit only {rodsCounter} rod(s).");
            }
            else
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesCounter} hole(s).");
            }

            PrintWall();


            void MoveVanko(int newVrow, int newVcol)
            {
                if (wall[newVrow, newVcol] == '-')// manages to drill a hole
                {
                    holesCounter++;
                    //drilled a whole and moved to that possiton
                    wall[vRow, vCol] = '*'; //marking the old possition with a hole
                    wall[newVrow, newVcol] = 'V'; //moving Vanko to the new possition
                    vRow = newVrow;
                    vCol = newVcol;
                }
                else if (wall[newVrow, newVcol] == 'R') // if he hits a rod
                {
                    rodsCounter++;
                    Console.WriteLine("Vanko hit a rod!");
                }
                else if (wall[newVrow, newVcol] == 'C') // if he hits a cable
                {
                    isElectrocuted = true;
                    wall[vRow, vCol] = '*'; //marking the old possition with a hole
                    wall[newVrow, newVcol] = 'E'; //marking the new possition with E (this is a hole too)
                    vRow = newVrow;
                    vCol = newVcol;
                    holesCounter++;
                }
                else if (wall[newVrow, newVcol] == '*') // if he lands on already created hole
                {
                    Console.WriteLine($"The wall is already destroyed at position [{newVrow}, {newVcol}]!");
                    wall[vRow, vCol] = '*'; //marking the old possition with a hole
                    wall[newVrow, newVcol] = 'V'; //moving Vanko to the new possition
                    vRow = newVrow;
                    vCol = newVcol;
                }
            }

            bool IsInsideTheWallArea(int row, int col)
            {
                if (row >= 0 && row < wall.GetLength(0) && col >= 0 && col < wall.GetLength(1))
                {
                    return true;
                }
                return false;
            }

            void PrintWall()
            {
                for (int r = 0; r < n; r++)
                {
                    for (int c = 0; c < n; c++)
                    {
                        Console.Write($"{wall[r, c]}");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
