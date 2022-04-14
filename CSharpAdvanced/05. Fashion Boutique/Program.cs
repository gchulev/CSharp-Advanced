using System;
using System.Linq;
using System.Collections.Generic;

namespace _05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>(Console.ReadLine().Split(' ').Select(int.Parse));
            int rackCapacity = int.Parse(Console.ReadLine());
            int racksCount = 1;
            int clothesSum = 0;

            for (int i = 0; i < stack.Count; i++)
            {
                int currentItem = stack.Pop();
                clothesSum += currentItem;

                if (rackCapacity < clothesSum)
                {
                    racksCount++;
                    clothesSum = currentItem;
                }
                i--;
            }
            Console.WriteLine(racksCount);
        }
    }
}
