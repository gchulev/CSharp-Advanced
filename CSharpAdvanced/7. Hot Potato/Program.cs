using System;
using System.Collections.Generic;

namespace _7._Hot_Potato
{
    internal class Program
    {
        static void Main()
        {
            Queue<string> queue = new Queue<string>(Console.ReadLine().Split(' '));
            int toss = int.Parse(Console.ReadLine());
            int i = 1;
            while (queue.Count > 1)
            {
                string currentChild = queue.Dequeue();
                if (i == toss)
                {
                    Console.WriteLine($"Removed {currentChild}");
                    i = 1;
                }
                else
                {
                    queue.Enqueue(currentChild);
                    i++;
                }
            }
            Console.WriteLine($"Last is {string.Join(' ', queue)}");
        }
    }
}
