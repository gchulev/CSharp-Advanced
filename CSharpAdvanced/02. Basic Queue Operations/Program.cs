using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    internal class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int numsToAdd = input[0];
            int numsToRemove = input[1];
            int numToCheck = input[2];
            Queue<int> queue = new Queue<int>();

            for (int i = 0; i < numsToAdd; i++)
            {
                queue.Enqueue(numbers[i]);
            }
            for (int i = 0; i < numsToRemove; i++)
            {
                queue.Dequeue();
            }
            if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (queue.Contains(numToCheck))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
