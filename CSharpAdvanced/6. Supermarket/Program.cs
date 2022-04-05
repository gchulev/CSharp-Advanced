using System;
using System.Collections.Generic;

namespace _6._Supermarket
{
    internal class Program
    {
        static void Main()
        {
            string input = Console.ReadLine();
            Queue<string> queue = new Queue<string>();

            while (input != "End")
            {
                if (input == "Paid")
                {
                    foreach (string customer in queue)
                    {
                        Console.WriteLine($"{customer}");
                    }
                    queue.Clear();
                }
                else
                {
                    queue.Enqueue(input);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
