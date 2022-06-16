using System;
using System.Collections.Generic;
using System.Linq;

namespace BeaverAtWork
{
    internal class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            char[,] pond = new char[n, n];
            int beaverRpos = 0;
            int beaverCpos = 0;
            int totalBranchesCntr = 0;
            List<char> branches = new List<char>();

            for (int r = 0; r < pond.GetLength(0); r++)
            {
                char[] rowValue = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();

                for (int c = 0; c < pond.GetLength(1); c++)
                {
                    pond[r, c] = rowValue[c];
                    if (pond[r, c] == 'B')
                    {
                        beaverRpos = r;
                        beaverCpos = c;
                    }
                    else if (char.IsLower(pond[r, c]))
                    {
                        totalBranchesCntr++;
                    }
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command.Equals("end") || totalBranchesCntr <= 0)
                {
                    break;
                }
                if (command.Equals("up"))
                {
                    bool isOutsideThePond = CheckIfOutsideThePond(pond, command, beaverRpos, beaverCpos);
                    if (isOutsideThePond)
                    {
                        if (branches.Count > 0)
                        {
                            branches.RemoveAt(branches.Count - 1);
                        }
                    }
                    else
                    {
                        pond[beaverRpos, beaverCpos] = '-'; //Clear current beaver possition

                        if (char.IsLower(pond[beaverRpos - 1, beaverCpos]))// check if the beaver gathers a branch
                        {
                            branches.Add(pond[beaverRpos - 1, beaverCpos]);
                            pond[beaverRpos - 1, beaverCpos] = 'B';
                            beaverRpos--;
                            totalBranchesCntr--;
                        }
                        else if ((pond[beaverRpos - 1, beaverCpos] == 'F') && (beaverRpos - 1 == 0)) //check if the beaver eats fish and the fish is located at the first possition
                        {
                            pond[beaverRpos - 1, beaverCpos] = '-'; //eats the fish
                            int lastIndex = pond.GetLength(0) - 1;

                            if (char.IsLower(pond[lastIndex, beaverCpos]))
                            {
                                branches.Add(pond[lastIndex, beaverCpos]);
                                totalBranchesCntr--;
                            }

                            pond[lastIndex, beaverCpos] = 'B';
                            beaverRpos = lastIndex;
                        }
                        else if ((pond[beaverRpos, beaverCpos] == 'F') && (beaverRpos - 1 > 0)) //if the fish is insde the pond but not at the edge
                        {
                            pond[beaverRpos - 1, beaverCpos] = '-'; //eats the fish
                            if (char.IsLower(pond[0, beaverCpos]))
                            {
                                branches.Add(pond[0, beaverCpos]);
                                totalBranchesCntr--;
                            }
                            pond[0, beaverCpos] = 'B';
                            beaverRpos = 0;
                        }
                        else //When the beaver gathers nothig, just moves
                        {
                            pond[beaverRpos - 1, beaverCpos] = 'B';
                            beaverRpos--;
                        }
                    }
                }
                else if (command.Equals("down"))
                {
                    bool isOutsideThePond = CheckIfOutsideThePond(pond, command, beaverRpos, beaverCpos);
                    if (isOutsideThePond)
                    {
                        if (branches.Count > 0)
                        {
                            branches.RemoveAt(branches.Count - 1);
                        }
                    }
                    else
                    {
                        pond[beaverRpos, beaverCpos] = '-'; //Clear current beaver possition
                        int lastIndex = pond.GetLength(0) - 1; //get the last row index

                        if (char.IsLower(pond[beaverRpos + 1, beaverCpos]))// check if the beaver gathers a branch
                        {
                            branches.Add(pond[beaverRpos + 1, beaverCpos]);
                            pond[beaverRpos + 1, beaverCpos] = 'B';
                            beaverRpos++;
                            totalBranchesCntr--;
                        }
                        else if ((pond[beaverRpos + 1, beaverCpos] == 'F') && (beaverRpos + 1 == lastIndex)) //check if the beaver eats fish and is located at the last possition
                        {
                            pond[beaverRpos + 1, beaverCpos] = '-'; //eats the fish

                            if (char.IsLower(pond[0, beaverCpos]))
                            {
                                branches.Add(pond[0, beaverCpos]);
                                totalBranchesCntr--;
                            }

                            pond[0, beaverCpos] = 'B';
                            beaverRpos = 0;
                        }
                        else if ((pond[beaverRpos + 1, beaverCpos] == 'F') && (beaverRpos + 1 < lastIndex)) //fish is located inside the pond and not at the edge
                        {
                            pond[beaverRpos + 1, beaverCpos] = '-'; //eats the fish

                            if (char.IsLower(pond[beaverRpos + 1, beaverCpos]))
                            {
                                branches.Add(pond[beaverRpos + 1, beaverCpos]);
                                totalBranchesCntr--;
                            }
                            int lastColIndex = pond.GetLength(0) - 1;
                            pond[lastColIndex, beaverCpos] = 'B'; //moves to the end of the column
                            beaverRpos = lastColIndex;
                        }
                        else
                        {
                            pond[beaverRpos + 1, beaverCpos] = 'B'; //moves without gathering anything
                            beaverRpos++;
                        }
                    }
                }
                else if (command.Equals("left"))
                {
                    bool isOutsideThePond = CheckIfOutsideThePond(pond, command, beaverRpos, beaverCpos);
                    if (isOutsideThePond)
                    {
                        if (branches.Count > 0)
                        {
                            branches.RemoveAt(branches.Count - 1);
                        }
                    }
                    else
                    {
                        pond[beaverRpos, beaverCpos] = '-'; //Clear current beaver possition

                        if (char.IsLower(pond[beaverRpos, beaverCpos - 1]))// check if the beaver gathers a branch
                        {
                            branches.Add(pond[beaverRpos, beaverCpos - 1]);
                            pond[beaverRpos, beaverCpos - 1] = 'B';
                            beaverCpos--;
                            totalBranchesCntr--;
                        }
                        else if (pond[beaverRpos, beaverCpos - 1] == 'F')
                        {
                            if (beaverCpos - 1 == 0) //check if we are at the edge of the pond
                            {
                                int lastIndex = pond.GetLength(1) - 1;
                                pond[beaverRpos, beaverCpos - 1] = '-'; //eats the fish

                                if (char.IsLower(pond[beaverRpos, lastIndex]))
                                {
                                    branches.Add(pond[beaverRpos, lastIndex]);
                                    totalBranchesCntr--;
                                }

                                pond[beaverRpos, lastIndex] = 'B';
                                beaverCpos = lastIndex;
                            }
                            else //The beaver is inside the pond
                            {
                                pond[beaverRpos, beaverRpos - 1] = '-'; //eats the fish
                                if (char.IsLower(pond[beaverRpos, 0]))
                                {
                                    branches.Add(pond[beaverRpos, 0]);
                                    totalBranchesCntr--;
                                }
                                pond[beaverRpos, 0] = 'B';
                                beaverCpos = 0;
                            }
                        }
                        else //the beaver doesn't collect anything just moves to the next spot
                        {
                            pond[beaverRpos, beaverCpos - 1] = 'B';
                            beaverCpos--;
                        }
                    }
                }
                else if (command.Equals("right"))
                {
                    bool isOutsideThePond = CheckIfOutsideThePond(pond, command, beaverRpos, beaverCpos);
                    if (isOutsideThePond)
                    {
                        if (branches.Count > 0)
                        {
                            branches.RemoveAt(branches.Count - 1);
                        }
                    }
                    else
                    {
                        pond[beaverRpos, beaverCpos] = '-'; //Clear current beaver possition

                        if (char.IsLower(pond[beaverRpos, beaverCpos + 1])) //check if the beaver gathers a branch
                        {
                            branches.Add(pond[beaverRpos, beaverCpos + 1]);
                            pond[beaverRpos, beaverCpos + 1] = 'B';
                            beaverCpos++;
                            totalBranchesCntr--;
                        }
                        else if (pond[beaverRpos, beaverCpos + 1] == 'F') //check if ther is a fish at the spot
                        {
                            int lastIndex = pond.GetLength(1) - 1;
                            if (beaverCpos + 1 == lastIndex) //check if the beaver is at the edge of the Pond
                            {
                                pond[beaverRpos, beaverCpos + 1] = '-';

                                if (char.IsLower(pond[beaverRpos, 0])) //checking if we have a branch after we swim under water
                                {
                                    branches.Add(pond[beaverRpos, 0]);
                                    totalBranchesCntr--;
                                }

                                pond[beaverRpos, 0] = 'B';
                                beaverCpos = 0;
                            }
                            else //beaver is inside the pond
                            {
                                pond[beaverRpos, beaverCpos + 1] = '-'; //eats the fish and moves forward to the edge of the pond
                                if (char.IsLower(pond[beaverRpos, lastIndex]))
                                {
                                    branches.Add(pond[beaverRpos, lastIndex]);
                                    totalBranchesCntr--;
                                }

                                pond[beaverRpos, lastIndex] = 'B';
                                beaverCpos = lastIndex;
                            }
                        }
                        else
                        {
                            pond[beaverRpos, beaverCpos + 1] = 'B';
                            beaverCpos++;
                        }
                    }
                }
            }

            if (totalBranchesCntr == 0)
            {
                Console.WriteLine($"The Beaver successfully collect {branches.Count} wood branches: {string.Join(", ", branches)}.");
            }
            else
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {totalBranchesCntr} branches left.");
            }

            for (int r = 0; r < pond.GetLength(0); r++)
            {
                for (int c = 0; c < pond.GetLength(1); c++)
                {
                    Console.Write($"{pond[r, c]} ");
                }
                Console.WriteLine();
            }
        }

        public static bool CheckIfOutsideThePond(char[,] pond, string cmd, int beaverRpos, int beaverCpos)
        {
            int lastRowIndex = pond.GetLength(0) - 1;
            int lastColIndex = pond.GetLength(1) - 1;

            if (cmd.Equals("up"))
            {
                if (beaverRpos - 1 < 0)
                {
                    return true;
                }
            }
            if (cmd.Equals("down"))
            {
                if (beaverRpos + 1 > lastRowIndex)
                {
                    return true;
                }
            }
            if (cmd.Equals("left"))
            {
                if (beaverCpos - 1 < 0)
                {
                    return true;
                }
            }
            if (cmd.Equals("right"))
            {
                if (beaverCpos + 1 > lastColIndex)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
