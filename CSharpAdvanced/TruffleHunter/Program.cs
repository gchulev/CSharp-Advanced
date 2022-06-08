using System;

namespace TruffleHunter
{
    internal class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            string[,] forest = new string[n, n];
            int blackTruffelCount = 0;
            int summerTruffelCount = 0;
            int whiteTruffel = 0;
            int eatenByTheboarCount = 0;

            for (int r = 0; r < forest.GetLength(0); r++)
            {
                string[] inputLine = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int c = 0; c < forest.GetLength(1); c++)
                {
                    forest[r, c] = inputLine[c];
                }
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input.Equals("Stop the hunt"))
                {
                    break;
                }
                string command = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0];

                if (command.Equals("Collect"))
                {
                    int row = int.Parse(input.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]);
                    int col = int.Parse(input.Split(' ', StringSplitOptions.RemoveEmptyEntries)[2]);

                    string cellValue = forest[row, col];

                    if (cellValue.Equals("B"))
                    {
                        blackTruffelCount++;
                        forest[row, col] = "-";
                    }
                    else if (cellValue.Equals("S"))
                    {
                        summerTruffelCount++;
                        forest[row, col] = "-";
                    }
                    else if (cellValue.Equals("W"))
                    {
                        whiteTruffel++;
                        forest[row, col] = "-";
                    }

                }
                else if (command.Equals("Wild_Boar"))
                {
                    int row = int.Parse(input.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]);
                    int col = int.Parse(input.Split(' ', StringSplitOptions.RemoveEmptyEntries)[2]);
                    string direction = input.Split(' ', StringSplitOptions.RemoveEmptyEntries)[3];

                    switch (direction)
                    {
                        case "up":
                            for (int i = row; i >= 0; i -= 2)
                            {
                                string currentCellValue = forest[i, col];
                                if (currentCellValue == "B" || currentCellValue == "S" || currentCellValue == "W")
                                {
                                    forest[i, col] = "-";
                                    eatenByTheboarCount++;
                                }
                            }
                            break;
                        case "down":
                            for (int i = row; i < forest.GetLength(0); i += 2)
                            {
                                string currentCellValue = forest[i, col];
                                if (currentCellValue == "B" || currentCellValue == "S" || currentCellValue == "W")
                                {
                                    forest[i, col] = "-";
                                    eatenByTheboarCount++;
                                }
                            }

                            break;
                        case "left":
                            for (int i = col; i >= 0; i -= 2)
                            {
                                string currentCellValue = forest[row, i];
                                if (currentCellValue == "B" || currentCellValue == "S" || currentCellValue == "W")
                                {
                                    forest[row, i] = "-";
                                    eatenByTheboarCount++;
                                }
                            }
                            break;
                        case "right":
                            for (int i = col; i < forest.GetLength(1); i += 2)
                            {
                                string currentCellValue = forest[row, i];
                                if (currentCellValue == "B" || currentCellValue == "S" || currentCellValue == "W")
                                {
                                    forest[row, i] = "-";
                                    eatenByTheboarCount++;
                                }
                            }
                            break;
                        default:
                            break;
                    }
                }
            }
            Console.WriteLine($"Peter manages to harvest {blackTruffelCount} black, {summerTruffelCount} summer, and {whiteTruffel} white truffles.");
            Console.WriteLine($"The wild boar has eaten {eatenByTheboarCount} truffles.");
            for (int r = 0; r < forest.GetLength(0); r++)
            {
                for (int c = 0; c < forest.GetLength(1); c++)
                {
                    Console.Write($"{forest[r, c]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
