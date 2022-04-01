using System;
using System.Collections.Generic;
using System.Linq;

namespace Stack_Sum
{
    internal class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);
            }

            string command = Console.ReadLine().ToLower();
            while (command != "end".ToLower())
            {
                string cmd = command.Split(' ', StringSplitOptions.RemoveEmptyEntries)[0];

                if (command.Contains("add".ToLower()))
                {
                    int firstNumber = int.Parse(command.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]);
                    int secondNumber = int.Parse(command.Split(' ', StringSplitOptions.RemoveEmptyEntries)[2]);
                    stack.Push(firstNumber);
                    stack.Push(secondNumber);
                }
                else if (command.Contains("Remove".ToLower()))
                {
                    int countToRemove = int.Parse(command.Split(' ', StringSplitOptions.RemoveEmptyEntries)[1]);
                    if (stack.Count >= countToRemove)
                    {
                        for (int i = 0; i < countToRemove; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
                command = Console.ReadLine().ToLower();
            }
            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
