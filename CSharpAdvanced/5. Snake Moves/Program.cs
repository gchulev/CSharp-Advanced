using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Snake_Moves
{
    internal class Program
    {
        static void Main()
        {
            int[] dimensions = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];

            Queue<char> snakeQueue = new Queue<char>(Console.ReadLine().ToCharArray());
            char[,] matrix = new char[rows, cols];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                if (r % 2 == 0)
                {
                    for (int c = 0; c < matrix.GetLength(1); c++)
                    {
                        char currentChar = snakeQueue.Dequeue();
                        matrix[r, c] = currentChar;
                        snakeQueue.Enqueue(currentChar);
                    }
                }
                else
                {
                    for (int c = matrix.GetLength(1) - 1; c >= 0; c--)
                    {
                        char currentChar = snakeQueue.Dequeue();
                        matrix[r, c] = currentChar;
                        snakeQueue.Enqueue(currentChar);
                    }
                }
            }

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    Console.Write($"{matrix[r, c]}");
                }
                Console.WriteLine();
            }
        }
    }
}
