using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    internal class Program
    {
        static void Main()
        {
            int[] dimensions = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            string[,] matrix = new string[rows, cols];
            
            for (int r = 0; r < matrix.GetLength(0); r++)
            {
                string[] inputLine = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                for (int c = 0; c < matrix.GetLength(1); c++)
                {
                    matrix[r, c] = inputLine[c];
                }
            }

            while (true)
            {
                string[] line = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (line[0].Equals("END"))
                {
                    break;
                }

                if (line[0].StartsWith("swap") && line.Length == 5)
                {
                    int row1 = int.Parse(line[1]);
                    int col1 = int.Parse(line[2]);
                    int row2 = int.Parse(line[3]);
                    int col2 = int.Parse(line[4]);

                    if (!(row1 >= 0 && row1 < matrix.GetLength(0)) || !(col1 >= 0 && col1 < matrix.GetLength(1)) || !(row2 >= 0 && row2 < matrix.GetLength(0)) || !(col2 >= 0 && col2 < matrix.GetLength(1)))
                    {
                        Console.WriteLine("Invalid input!");
                        continue;
                    }

                    string valueOne = matrix[row1, col1];
                    string valueTwo = matrix[row2, col2];

                    matrix[row1, col1] = valueTwo;
                    matrix[row2, col2] = valueOne;

                    for (int r = 0; r < matrix.GetLength(0); r++)
                    {
                        for (int c = 0; c < matrix.GetLength(1); c++)
                        {
                            Console.Write($"{matrix[r, c]} ");
                        }
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}
