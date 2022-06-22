using System;

namespace PawnWars
{
    internal class Program
    {
        static void Main()
        {
            string[,] chessBoardMap = new string[8, 8];

            for (int r = 0; r < 8; r++)
            {
                for (int c = 0; c < 8; c++)
                {
                    char charToInsert = (char)('a' + c);
                    chessBoardMap[r, c] = $"{charToInsert}{8 - r}";
                }
            }

            int whitePawnRow = -1;
            int whitePawnCol = -1;

            int blackPawnRow = -1;
            int blackPawnCol = -1;

            char[,] chessBoard = new char[8, 8];
            for (int r = 0; r < 8; r++)
            {
                char[] inputLine = Console.ReadLine().ToCharArray();
                for (int c = 0; c < 8; c++)
                {
                    chessBoard[r, c] = inputLine[c];
                    if (chessBoard[r, c] == 'w')
                    {
                        whitePawnRow = r;
                        whitePawnCol = c;
                    }
                    if (chessBoard[r, c] == 'b')
                    {
                        blackPawnRow = r;
                        blackPawnCol = c;
                    }
                }
            }
            bool whitePawnturn = true;
            string moveResult = string.Empty;

            while (whitePawnRow > 0 && blackPawnRow < 7)
            {
                if (whitePawnturn)
                {
                    var caputreCoordinates = CapturedEnemyPawn(whitePawnRow, whitePawnCol, whitePawnturn);

                    if (caputreCoordinates.rowCapture != -1 && caputreCoordinates.colCapture != -1)
                    {
                        Console.WriteLine($"Game over! White capture on {chessBoardMap[caputreCoordinates.rowCapture, caputreCoordinates.colCapture]}.");
                        break;
                    }
                    moveResult = MovePawn(whitePawnRow, whitePawnCol, 'w');
                    whitePawnturn = false;
                    if (moveResult == "white pawn promoted")
                    {
                        Console.WriteLine($"Game over! White pawn is promoted to a queen at {chessBoardMap[whitePawnRow, whitePawnCol]}.");
                        break;
                    }
                    //for debugging
                    //Console.WriteLine("------- Moving White Pawn ------------");
                    //PrintChessboard();
                }
                else
                {
                    var caputreCoordinates = CapturedEnemyPawn(blackPawnRow, blackPawnCol, whitePawnturn);

                    if (caputreCoordinates.rowCapture != -1 && caputreCoordinates.colCapture != -1)
                    {
                        Console.WriteLine($"Game over! Black capture on {chessBoardMap[caputreCoordinates.rowCapture, caputreCoordinates.colCapture]}.");
                        break;
                    }
                    moveResult = MovePawn(blackPawnRow, blackPawnCol, 'b');
                    whitePawnturn = true;
                    if (moveResult == "black pawn prmoted")
                    {
                        Console.WriteLine($"Game over! Black pawn is promoted to a queen at {chessBoardMap[blackPawnRow, blackPawnCol]}.");
                        break;
                    }
                    //for debugging
                    //Console.WriteLine("------- Moving Black Pawn ------------");
                    //PrintChessboard();
                }
            }

            //PrintChessboard();

            (int rowCapture, int colCapture) CapturedEnemyPawn(int currentPawnRow, int currentPawnCol, bool pawnTurn)
            {
                //White pawn turn
                if (pawnTurn)
                {
                    //checking if we are at the left side of the chess board
                    if (currentPawnCol - 1 < 0)
                    {
                        //TODO: check only the right diagonal
                        if (chessBoard[currentPawnRow - 1, currentPawnCol + 1] == 'b')//right diagonal
                        {
                            chessBoard[currentPawnRow, currentPawnCol] = '-';
                            whitePawnRow = currentPawnRow - 1;
                            whitePawnCol = currentPawnCol + 1;
                            chessBoard[whitePawnRow, whitePawnCol] = 'w'; //Moving the pawn to the new possition
                            return (whitePawnRow, whitePawnCol);
                        }
                    }
                    else if (currentPawnCol + 1 > chessBoard.GetLength(1) - 1)
                    {
                        if (chessBoard[currentPawnRow - 1, currentPawnCol - 1] == 'b')//left diagonal
                        {
                            chessBoard[currentPawnRow, currentPawnCol] = '-'; //Moving the pawn from its possition to the new one
                            whitePawnRow = currentPawnRow - 1;
                            whitePawnCol = currentPawnCol - 1;
                            chessBoard[whitePawnRow, whitePawnCol] = 'w';
                            return (whitePawnRow, whitePawnCol);
                        }
                    }
                    //Checking both diagonals
                    else
                    {
                        if (chessBoard[currentPawnRow - 1, currentPawnCol - 1] == 'b')//left diagonal
                        {
                            chessBoard[currentPawnRow, currentPawnCol] = '-'; //Moving the pawn from its possition to the new one
                            whitePawnRow = currentPawnRow - 1;
                            whitePawnCol = currentPawnCol - 1;
                            chessBoard[whitePawnRow, whitePawnCol] = 'w';
                            return (whitePawnRow, whitePawnCol);
                        }

                        else if (chessBoard[currentPawnRow - 1, currentPawnCol + 1] == 'b')//right diagonal
                        {
                            chessBoard[currentPawnRow, currentPawnCol] = '-';
                            whitePawnRow = currentPawnRow - 1;
                            whitePawnCol = currentPawnCol + 1;
                            chessBoard[whitePawnRow, whitePawnCol] = 'w'; //Moving the pawn to the new possition
                            return (whitePawnRow, whitePawnCol);
                        }
                    }
                    return (-1, -1);
                }
                //Black pawn turn
                else
                {
                    //check if we are outside the board on the left
                    if (currentPawnCol - 1 < 0)
                    {
                        //Checking right side only
                        if (chessBoard[currentPawnRow + 1, currentPawnCol + 1] == 'w')
                        {
                            chessBoard[currentPawnRow, currentPawnCol] = '-';
                            blackPawnRow = currentPawnRow + 1;
                            blackPawnCol = currentPawnCol + 1;
                            chessBoard[blackPawnRow, blackPawnCol] = 'b';
                            return (blackPawnRow, blackPawnCol);
                        }
                    }
                    //Check if we are outside the board on the right side
                    else if (currentPawnCol + 1 > chessBoard.GetLength(1) - 1)
                    {
                        //Checking left side only
                        if (chessBoard[currentPawnRow + 1, currentPawnCol - 1] == 'w')
                        {
                            chessBoard[currentPawnRow, currentPawnCol] = '-';
                            blackPawnRow = currentPawnRow + 1;
                            blackPawnCol = currentPawnCol - 1;
                            chessBoard[blackPawnRow, blackPawnCol] = 'b';
                            return (blackPawnRow, blackPawnCol);
                        }
                    }
                    //checking both diagonals
                    else
                    {
                        if (chessBoard[currentPawnRow + 1, currentPawnCol + 1] == 'w')
                        {
                            chessBoard[currentPawnRow, currentPawnCol] = '-';
                            blackPawnRow = currentPawnRow + 1;
                            blackPawnCol = currentPawnCol + 1;
                            chessBoard[blackPawnRow, blackPawnCol] = 'b';
                            return (blackPawnRow, blackPawnCol);
                        }
                        if (chessBoard[currentPawnRow + 1, currentPawnCol - 1] == 'w')
                        {
                            chessBoard[currentPawnRow, currentPawnCol] = '-';
                            blackPawnRow = currentPawnRow + 1;
                            blackPawnCol = currentPawnCol - 1;
                            chessBoard[blackPawnRow, blackPawnCol] = 'b';
                            return (blackPawnRow, blackPawnCol);
                        }
                    }
                    return (-1, -1);
                }
            }


            void PrintChessboard()
            {
                Console.WriteLine();
                for (int r = 0; r < chessBoard.GetLength(0); r++)
                {
                    for (int c = 0; c < chessBoard.GetLength(1); c++)
                    {
                        Console.Write(chessBoard[r, c]);
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }

            string MovePawn(int currentPawnRow, int currentPawnCol, char pawn)
            {
                if (pawn.Equals('w'))
                {
                    int newPawnRow = currentPawnRow - 1;
                    int newPawnCol = currentPawnCol;
                    chessBoard[currentPawnRow, currentPawnCol] = '-'; //Taking the white pawn to move it forward
                    chessBoard[newPawnRow, newPawnCol] = 'w';
                    whitePawnRow = newPawnRow;
                    whitePawnCol = newPawnCol;

                    if (newPawnRow == 0)
                    {
                        return "white pawn promoted";
                    }
                }
                if (pawn.Equals('b'))
                {
                    int newPawnRow = currentPawnRow + 1;
                    int newPawnCol = currentPawnCol;
                    chessBoard[currentPawnRow, currentPawnCol] = '-'; //Taking the black pawn to move it forward
                    chessBoard[newPawnRow, newPawnCol] = 'b';
                    blackPawnRow = newPawnRow;
                    blackPawnCol = newPawnCol;

                    if (newPawnRow == 7)
                    {
                        return "black pawn prmoted";
                    }
                }
                return "no promotion";
            }
        }
    }
}
