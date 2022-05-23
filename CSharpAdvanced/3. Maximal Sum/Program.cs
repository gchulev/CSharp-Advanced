using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    internal class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int n = input[0];
            int m = input[1];
            int[,] matrix = new int[n, m];
            int[,] best3by3Matrix = new int[3, 3];

            for (int r = 0; r < n; r++)
            {
                int[] inputLine = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int c = 0; c < m; c++)
                {
                    matrix[r, c] = inputLine[c];
                }
            }

            int bestSum = 0;

            for (int r = 0; r < matrix.GetLength(0) - 2; r++)
            {
                for (int c = 0; c < matrix.GetLength(1) - 2; c++)
                {
                    int[,] tempMatrix = new int[3, 3];
                    int tempSum = 0;

                    tempMatrix[0, 0] = matrix[r, c];
                    tempMatrix[0, 1] = matrix[r, c + 1];
                    tempMatrix[0, 2] = matrix[r, c + 2];
                    tempMatrix[1, 0] = matrix[r + 1, c];
                    tempMatrix[1, 1] = matrix[r + 1, c + 1];
                    tempMatrix[1, 2] = matrix[r + 1, c + 2];
                    tempMatrix[2, 0] = matrix[r + 2, c];
                    tempMatrix[2, 1] = matrix[r + 2, c + 1];
                    tempMatrix[2, 2] = matrix[r + 2, c + 2];


                    for (int row = 0; row < tempMatrix.GetLength(0); row++)
                    {
                        for (int col = 0; col < tempMatrix.GetLength(1); col++)
                        {
                            tempSum += tempMatrix[row, col];
                        }
                    }
                    if (tempSum > bestSum)
                    {
                        bestSum = tempSum;
                        best3by3Matrix = tempMatrix;
                    }
                }
            }
            Console.WriteLine($"Sum = {bestSum}");

            for (int r = 0; r < best3by3Matrix.GetLength(0); r++)
            {
                for (int c = 0; c < best3by3Matrix.GetLength(1); c++)
                {
                    Console.Write($"{best3by3Matrix[r, c]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
