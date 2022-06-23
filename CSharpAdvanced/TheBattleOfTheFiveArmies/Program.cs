using System;
using System.Linq;

namespace TheBattleOfTheFiveArmies
{
    internal class Program
    {
        static void Main()
        {
            int armour = int.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            char[][] map = new char[n][];
            int mordorRow = -1;
            int mordorCol = -1;
            int armyRow = -1;
            int armyCol = -1;

            for (int r = 0; r < n; r++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                map[r] = input;
                for (int c = 0; c < map[r].Length; c++)
                {
                    if (map[r][c] == 'M')
                    {
                        mordorRow = r;
                        mordorCol = c;
                    }
                    if (map[r][c] == 'A')
                    {
                        armyRow = r;
                        armyCol = c;
                    }

                }
            }

            while (true)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = input[0];
                int orcsRow = int.Parse(input[1]);
                int orcsCol = int.Parse(input[2]);

                SpawnOrcs(orcsRow, orcsCol);
                MoveArmy(command);

                //checking if the army died
                if (map.Any(x => x.Any(elm => elm.Equals('X'))))
                {
                    Console.WriteLine($"The army was defeated at {armyRow};{armyCol}.");
                    break;
                }
                //checking if the char 'A' is present on the map, if not then the army reached Mordor so we print the message
                if (!map.Any(x => x.Any(elm => elm.Equals('A'))))
                {
                    Console.WriteLine($"The army managed to free the Middle World! Armor left: {armour}");
                    break;
                }
            }
            PrintMap();

            void SpawnOrcs(int row, int col)
            {
                map[row][col] = 'O';
            }

            void MoveArmy(string command)
            {
                int mapTopBoudnry = 0; // row boundry
                int mapBottomBoundry = n - 1;
                int mapLeftBoundry = 0; //column boundry
                int mapRightBoundry = map[0].Length - 1; //column boundry

                if (command.Equals("up"))
                {
                    armour--;//dicreasing the armory since the army generaly moves
                    //check if the army doesn't try to move outside the map
                    if (armyRow - 1 >= mapTopBoudnry) //if the army is insde the map, process the data it not do nothing.
                    {
                        //clearing army's previous possition
                        map[armyRow][armyCol] = '-';

                        if (map[armyRow - 1][armyCol] == 'O')//army fights the enemy
                        {
                            armour -= 2;
                            if (armour <= 0)
                            {
                                map[armyRow - 1][armyCol] = 'X';
                                armyRow--; //new army row possition
                            }
                            else
                            {
                                map[armyRow - 1][armyCol] = 'A';//army defeats the enemy and moves on their possition
                                armyRow--; //row changes because we move up, column stays the same
                            }
                        }
                        //check if the army reached Mordor
                        else if (map[armyRow - 1][armyCol] == 'M')
                        {
                            map[armyRow - 1][armyCol] = '-';//army reached Mordor and disappears
                            armyRow--;
                        }
                        //just moving the army since there is no enemy at the new location
                        else
                        {
                            map[armyRow - 1][armyCol] = 'A';
                            armyRow--;//the new army row possition. Column is the same since we move up
                        }
                    }
                    if (armour <= 0)
                    {
                        map[armyRow][armyCol] = 'X';//army dies because it tries to move out of the map but the armour goes below 0
                    }
                }
                else if (command.Equals("down"))
                {
                    armour--; //decreasing the armour since the army moves

                    //if the army is inside the map we process the data if not we do nothing
                    if (armyRow + 1 <= mapBottomBoundry)
                    {
                        //clear the army's old possition
                        map[armyRow][armyCol] = '-';

                        //check if the army reaches enemies
                        if (map[armyRow + 1][armyCol] == 'O')
                        {
                            armour -= 2;//deacreasing the armoru since the army fights

                            //check if the army dies
                            if (armour <= 0)
                            {
                                map[armyRow + 1][armyCol] = 'X';
                                armyRow++; //the new army row possition
                            }
                            else
                            {
                                map[armyRow + 1][armyCol] = 'A';
                                armyRow++; // the new army row possition
                            }
                        }
                        //check if the army reached Mordor
                        else if (map[armyRow + 1][armyCol] == 'M')
                        {
                            map[armyRow + 1][armyCol] = '-';//the army disappears
                            armyRow++;
                        }
                        //if there is no orcs or no Mordor, the army just moves down
                        else
                        {
                            map[armyRow + 1][armyCol] = 'A';
                            armyRow++; //the new army row possition
                        }
                    }
                    if (armour <= 0)
                    {
                        map[armyRow][armyCol] = 'X';//army dies because it tries to move out of the map but the armour goes below 0
                    }
                }
                else if (command.Equals("left"))
                {
                    //decreasing the armor since the army moves
                    armour--;

                    //checknig if we move inside the map
                    if (armyCol - 1 >= mapLeftBoundry)
                    {
                        //clearing old army possiton
                        map[armyRow][armyCol] = '-';

                        //checking if the army fights enemy
                        if (map[armyRow][armyCol - 1] == 'O')
                        {
                            armour -= 2;//decreasing the armor because the army fights
                            if (armour <= 0)
                            {
                                map[armyRow][armyCol - 1] = 'X'; //Army dies
                                armyCol--; //the new army col possition
                            }
                            // the army wins
                            else
                            {
                                map[armyRow][armyCol - 1] = 'A';
                                armyCol--; //the new army column possition
                            }
                        }
                        //checking if the army reached mordor
                        else if (map[armyRow][armyCol - 1] == 'M')
                        {
                            map[armyRow][armyCol - 1] = '-'; //the army wins the war and disappears
                        }
                        //army didn't encounter anyone at its new possition so it just moves there
                        else
                        {
                            map[armyRow][armyCol - 1] = 'A';
                            armyCol--; //the new army column possition
                        }
                    }
                    if (armour <= 0)
                    {
                        map[armyRow][armyCol] = 'X';//army dies because it tries to move out of the map but the armour goes below 0
                    }
                }
                else if (command.Equals("right"))
                {
                    armour--; //decreasing the armor because the army moves

                    //checking if the army moves inside the map
                    if (armyCol + 1 <= mapRightBoundry)
                    {
                        //clear the army old possiton
                        map[armyRow][armyCol] = '-';

                        //checking if the army encountered an enemy
                        if (map[armyRow][armyCol + 1] == 'O')
                        {
                            armour -= 2; //army fights so we decrease the armour
                            //checking if the army survives
                            if (armour <= 0)
                            {
                                map[armyRow][armyCol + 1] = 'X'; //the army dies
                                armyCol++; //the new army col possition
                            }
                            //the army survives
                            else
                            {
                                map[armyRow][armyCol + 1] = 'A';
                                armyCol++;// the new army column possition
                            }
                        }
                        //check if the army reached Mordor
                        else if (map[armyRow][armyCol + 1] == 'M')
                        {
                            map[armyRow][armyCol + 1] = '-'; //the army wins the war and dissapears
                            armyCol++;
                        }

                        //there is no enemies or morodor so the army just moves
                        else
                        {
                            map[armyRow][armyCol + 1] = 'A';
                            armyCol++; //the new army column possition
                        }
                    }
                    if (armour <= 0)
                    {
                        map[armyRow][armyCol] = 'X';//army dies because it tries to move out of the map but the armour goes below 0
                    }
                }
            }

            void PrintMap()
            {
                for (int r = 0; r < map.Length; r++)
                {
                    for (int c = 0; c < map[r].Length; c++)
                    {
                        Console.Write(map[r][c]);
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
