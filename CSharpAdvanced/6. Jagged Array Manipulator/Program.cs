using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    internal class Program
    {
        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] inputData = new double[rows][];

            for (int i = 0; i < rows; i++)
            {
                double[] currentRow = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(double.Parse).ToArray();
                inputData[i] = currentRow;
            }

            for (int r = 0; r < inputData.GetLength(0); r++)
            {
                if (r != inputData.GetLength(0) - 1 && inputData[r].Length > 0)
                {
                    if (inputData[r].Length == inputData[r + 1].Length)
                    {
                        for (int i = 0; i < inputData[r].Length; i++)
                        {
                            inputData[r][i] = inputData[r][i] * 2;
                            inputData[r + 1][i] = inputData[r + 1][i] * 2;
                        }
                    }
                    else
                    {
                        for (int i = 0; i < inputData[r].Length; i++)
                        {
                            inputData[r][i] = inputData[r][i] / 2;
                        }
                        for (int i = 0; i < inputData[r + 1].Length; i++)
                        {
                            inputData[r + 1][i] = inputData[r + 1][i] / 2;
                        }
                    }
                }
            }

            while (true)
            {
                string commandLine = Console.ReadLine();
                if (commandLine == "End")
                {
                    foreach (double[] item in inputData)
                    {
                        Console.WriteLine(String.Join(' ', item));
                    }
                    break;
                }

                string command = commandLine.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0];
                int row = int.Parse(commandLine.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]);
                int col = int.Parse(commandLine.Split(' ', StringSplitOptions.RemoveEmptyEntries)[2]);
                double value = double.Parse(commandLine.Split(' ', StringSplitOptions.RemoveEmptyEntries)[3]);

                if (command.Equals("Add"))
                {
                    if (row >= 0 && row < inputData.Length)
                    {
                        if (col >= 0 && col < inputData[row].Length)
                        {
                            inputData[row][col] += value;
                        }
                    }
                }
                else if (command.Equals("Subtract"))
                {
                    if (row >= 0 && row < inputData.Length)
                    {
                        if (col >= 0 && col < inputData[row].Length)
                        {
                            inputData[row][col] -= value;
                        }
                    }
                }
            }
        }
    }
}
