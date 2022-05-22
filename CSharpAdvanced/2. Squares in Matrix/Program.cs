using System;
using System.Linq;

namespace _2._Squares_in_Matrix
{
    internal class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];
            string[,] matrix = new string[rows, cols];

            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                string[] inputLine = Console.ReadLine().Split(' ').ToArray();
                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = inputLine[c];
                }
            }

            int twoByTowMatrix = 0;
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col + 1] && matrix[row, col] == matrix[row + 1, col] && matrix[row, col] == matrix[row + 1, col + 1])
                    {
                        twoByTowMatrix++;
                    }
                }
            }
            Console.WriteLine(twoByTowMatrix);
        }
    }
}
