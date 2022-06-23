using System;
using System.Linq;
using System.Collections.Generic;

namespace Survivor
{
    internal class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            char[][] beach = new char[n][];
            int playerTokens = 0;
            int opponentTokens = 0;
            const int STEPS = 3;

            for (int r = 0; r < n; r++)
            {
                char[] inputLine = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                beach[r] = inputLine;
            }

            while (true)
            {
                string[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = input[0];

                if (command.Equals("Gong"))
                {
                    break;
                }
                if (command.Equals("Find"))
                {
                    int row = int.Parse(input[1]);
                    int col = int.Parse(input[2]);

                    if (row >= 0 && row < beach.Length && col >= 0 && col < beach[row].Length)
                    {
                        if (beach[row][col] == 'T')
                        {
                            beach[row][col] = '-';
                            playerTokens++;
                        }
                    }
                }
                else if (command.Equals("Opponent"))
                {
                    int row = int.Parse(input[1]);
                    int col = int.Parse(input[2]);
                    string direction = input[3];

                    if (row >= 0 && row < beach.Length && col >= 0 && col < beach[row].Length)
                    {
                        if (beach[row][col] == 'T')
                        {
                            beach[row][col] = '-';
                            opponentTokens++;

                        }
                            int availableSteps = 0;
                            switch (direction)
                            {
                                case "up":

                                    if (row - STEPS > 0)
                                    {
                                        availableSteps = row - STEPS;
                                    }

                                    for (int r = row; r >= availableSteps; r--)
                                    {
                                        if (beach[r][col] == 'T')
                                        {
                                            beach[r][col] = '-';
                                            opponentTokens++;
                                        }
                                    }
                                    availableSteps = 0;

                                    break;
                                case "down":

                                    if (row + STEPS <= beach.Length - 1)
                                    {
                                        availableSteps = row + STEPS;
                                    }

                                    for (int r = row; r <= availableSteps; r++)
                                    {
                                        if (beach[r][col] == 'T')
                                        {
                                            beach[r][col] = '-';
                                            opponentTokens++;
                                        }
                                    }
                                    availableSteps = 0;

                                    break;
                                case "left":

                                    if (col - STEPS > 0)
                                    {
                                        availableSteps = col - STEPS;
                                    }

                                    for (int c = col; c >= availableSteps; c--)
                                    {
                                        if (beach[row][c] == 'T')
                                        {
                                            beach[row][c] = '-';
                                            opponentTokens++;
                                        }
                                    }
                                    availableSteps = 0;

                                    break;
                                case "right":

                                    if (col + STEPS <= beach[row].Length - 1)
                                    {
                                        availableSteps = col + STEPS;
                                    }

                                    for (int c = col; c <= availableSteps; c++)
                                    {
                                        if (beach[row][c] == 'T')
                                        {
                                            beach[row][c] = '-';
                                            opponentTokens++;
                                        }
                                    }
                                    availableSteps = 0;
                                    break;
                                default:
                                    break;
                            }
                    }
                }
            }
            PrintBeach();
            Console.WriteLine($"Collected tokens: {playerTokens}");
            Console.WriteLine($"Opponent's tokens: {opponentTokens}");

            void PrintBeach()
            {
                for (int r = 0; r < beach.Length; r++)
                {
                    Console.Write(string.Join(' ', beach[r]));
                    Console.WriteLine();
                }
            }
        }
    }
}
