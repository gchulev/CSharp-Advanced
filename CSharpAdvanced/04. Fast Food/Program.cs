using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int foodQuantity = int.Parse(Console.ReadLine());
            Queue<int> orders = new Queue<int>(Console.ReadLine().Split(' ').Select(int.Parse));
            int maxOrder = orders.Max();

            for (int i = 0; i < orders.Count; i++)
            {
                if (foodQuantity < orders.Peek())
                {
                    break;
                }
                foodQuantity -= orders.Dequeue();
                i--;
            }
            Console.WriteLine(maxOrder);
            if (orders.Count > 0)
            {
                Console.WriteLine($"Orders left: {string.Join(' ', orders)}");
            }
            else
            {
                Console.WriteLine($"Orders complete");
            }
        }
    }
}
