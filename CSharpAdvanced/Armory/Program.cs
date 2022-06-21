using System;
using System.Linq;

namespace Armory
{
    internal class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            char[,] armory = new char[n, n];
            int officerRow = -1;
            int officerCol = -1;
            decimal coinsSpent = 0m;

            for (int r = 0; r < n; r++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                for (int c = 0; c < n; c++)
                {
                    armory[r, c] = input[c];
                    if (armory[r, c] == 'A')
                    {
                        officerRow = r;
                        officerCol = c;
                    }
                }
            }
            bool isOutsideTheArmory = false;
            if (officerRow < 0 || officerCol < 0)
            {
                isOutsideTheArmory = true;
            }

            while (coinsSpent < 65 && isOutsideTheArmory == false)
            {
                string command = Console.ReadLine();
                if (command.Equals("up"))
                {
                    int newRowPos = officerRow - 1;
                    int newColPos = officerCol;

                    isOutsideTheArmory = Move(newRowPos, newColPos) == 0;
                }
                else if (command.Equals("down"))
                {
                    int newRowPos = officerRow + 1;
                    int newColPos = officerCol;

                    isOutsideTheArmory = Move(newRowPos, newColPos) == 0;
                }
                else if (command.Equals("left"))
                {
                    int newRowPos = officerRow;
                    int newColPos = officerCol - 1;

                    isOutsideTheArmory = Move(newRowPos, newColPos) == 0;
                }
                else if (command.Equals("right"))
                {
                    int newRowPos = officerRow;
                    int newColPos = officerCol + 1;

                    isOutsideTheArmory = Move(newRowPos, newColPos) == 0;
                }
            }

            if (coinsSpent < 65)
            {
                Console.WriteLine("I do not need more swords!");
            }
            else
            {
                Console.WriteLine("Very nice swords, I will come back for more!");
            }
            Console.WriteLine($"The king paid {coinsSpent} gold coins.");

            PrintMatrix();

            int Move(int newOfficerRow, int newOfficerCol)
            {
                if (newOfficerRow < 0 || newOfficerRow >= n || newOfficerCol < 0 || newOfficerCol >= n)
                {
                    armory[officerRow, officerCol] = '-';
                    return 0;
                }
                if (char.IsDigit(armory[newOfficerRow, newOfficerCol]))
                {
                    armory[officerRow, officerCol] = '-';
                    officerRow = newOfficerRow;
                    officerCol = newOfficerCol;
                    coinsSpent += int.Parse(armory[newOfficerRow, newOfficerCol].ToString());
                    armory[newOfficerRow, newOfficerCol] = 'A'; //Moving the officer to the new possition
                }
                else if (armory[newOfficerRow, newOfficerCol] == 'M')
                {

                    armory[officerRow, officerCol] = '-'; //Clear the officer's possition
                    armory[newOfficerRow, newOfficerCol] = '-'; //Clear the first 'M' possition

                    for (int r = 0; r < armory.GetLength(0); r++)
                    {
                        for (int c = 0; c < armory.GetLength(1); c++)
                        {
                            if (armory[r, c] == 'M')
                            {
                                armory[r, c] = 'A'; //Moving the officer to the new possition
                                officerRow = r;
                                officerCol = c; //Setting the officer possition ot the new coordinates
                                return 1;
                            }
                        }
                    }
                }
                else
                {
                    armory[officerRow, officerCol] = '-';
                    armory[newOfficerRow, newOfficerCol] = 'A';
                    officerRow = newOfficerRow;
                    officerCol = newOfficerCol;
                }
                return 1;
            }

            void PrintMatrix()
            {
                for (int r = 0; r < armory.GetLength(0); r++)
                {
                    for (int c = 0; c < armory.GetLength(1); c++)
                    {
                        Console.Write($"{armory[r, c]}");
                    }
                    Console.WriteLine();
                }
            }
        }

    }
}
