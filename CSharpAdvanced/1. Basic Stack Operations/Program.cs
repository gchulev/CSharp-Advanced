using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Basic_Stack_Operations
{
    internal class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] numArray = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int numToPush = input[0];
            int numToPop = input[1];
            int numToCheck = input[2];
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < numToPush; i++)
            {
                stack.Push(numArray[i]);
            }
            for (int j = 0; j < numToPop; j++)
            {
                stack.Pop();
            }
            if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (stack.Contains(numToCheck))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
