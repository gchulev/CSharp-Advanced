using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Print_Even_Numbers
{
    internal class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(input);
            List<int> evenNumbers = new List<int>();

            for (int i = 0; i < queue.Count; i++)
            {
                if (queue.Peek() % 2 == 0)
                {
                    evenNumbers.Add(queue.Peek());
                    queue.Dequeue();
                }
                else
                {
                    queue.Dequeue();
                }
                i--;
            }
            Console.WriteLine(string.Join(", ", evenNumbers));
        }
    }
}
