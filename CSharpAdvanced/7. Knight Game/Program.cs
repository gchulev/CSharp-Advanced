using System;

namespace _7._Knight_Game
{
    internal class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            char[,] chessBoard = new char[n, n];

            for (int r = 0; r < n; r++)
            {
                string input = Console.ReadLine();

                for (int c = 0; c < n; c++)
                {
                    chessBoard[r, c] = input[c];
                }
            }
            bool overlappingKnights = true;
            int kinghtsRemovedCntr = 0;

            while (overlappingKnights)
            {
                int maxOverlaps = 0;
                int maxOverlapPossitionRow = 0;
                int maxOverlapPOssitionCol = 0;

                for (int r = 0; r < chessBoard.GetLength(0); r++)
                {
                    for (int c = 0; c < chessBoard.GetLength(1); c++)
                    {
                        int currentOverlaps = 0;

                        if (chessBoard[r, c] == 'K')
                        {
                            if ((r - 2) >= 0 && (r - 2) < chessBoard.GetLength(0) && (c - 1) >= 0 && (c - 1) < chessBoard.GetLength(1))
                            {
                                char pos1 = chessBoard[r - 2, c - 1];
                                if (pos1 == 'K')
                                {
                                    currentOverlaps++;
                                }
                            }
                            if ((r - 2) >= 0 && (r - 2) < chessBoard.GetLength(0) && (c + 1) >= 0 && (c + 1) < chessBoard.GetLength(1))
                            {
                                char pos2 = chessBoard[r - 2, c + 1];
                                if (pos2 == 'K')
                                {
                                    currentOverlaps++;
                                }
                            }
                            if ((r - 1) >= 0 && (r - 1) < chessBoard.GetLength(0) && (c - 2) >= 0 && (c - 2) < chessBoard.GetLength(1))
                            {
                                char pos3 = chessBoard[r - 1, c - 2];
                                if (pos3 == 'K')
                                {
                                    currentOverlaps++;
                                }
                            }
                            if ((r - 1) >= 0 && (r - 1) < chessBoard.GetLength(0) && (c + 2) >= 0 && (c + 2) < chessBoard.GetLength(1))
                            {
                                char pos4 = chessBoard[r - 1, c + 2];
                                if (pos4 == 'K')
                                {
                                    currentOverlaps++;
                                }
                            }
                            if ((r + 1) >= 0 && (r + 1) < chessBoard.GetLength(0) && (c - 2) >= 0 && (c - 2) < chessBoard.GetLength(1))
                            {
                                char pos5 = chessBoard[r + 1, c - 2];
                                if (pos5 == 'K')
                                {
                                    currentOverlaps++;
                                }
                            }
                            if ((r + 1) >= 0 && (r + 1) < chessBoard.GetLength(0) && (c + 2) >= 0 && (c + 2) < chessBoard.GetLength(1))
                            {
                                char pos6 = chessBoard[r + 1, c + 2];
                                if (pos6 == 'K')
                                {
                                    currentOverlaps++;
                                }
                            }
                            if ((r + 2) >= 0 && (r + 2) < chessBoard.GetLength(0) && (c - 1) >= 0 && (c - 1) < chessBoard.GetLength(1))
                            {
                                char pos7 = chessBoard[r + 2, c - 1];
                                if (pos7 == 'K')
                                {
                                    currentOverlaps++;
                                }
                            }
                            if ((r + 2) >= 0 && (r + 2) < chessBoard.GetLength(0) && (c + 1) >= 0 && (c + 1) < chessBoard.GetLength(1))
                            {
                                char pos8 = chessBoard[r + 2, c + 1];
                                if (pos8 == 'K')
                                {
                                    currentOverlaps++;
                                }
                            }
                            if (maxOverlaps < currentOverlaps)
                            {
                                maxOverlaps = currentOverlaps;
                                maxOverlapPossitionRow = r;
                                maxOverlapPOssitionCol = c;
                            }
                        }
                    }
                }
                if (maxOverlaps > 0)
                {
                    chessBoard[maxOverlapPossitionRow, maxOverlapPOssitionCol] = '0';
                    kinghtsRemovedCntr++;
                }
                else
                {
                    overlappingKnights = false;
                }
            }
            Console.WriteLine(kinghtsRemovedCntr);
        }
    }
}
