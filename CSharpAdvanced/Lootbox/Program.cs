using System;
using System.Linq;
using System.Collections.Generic;

namespace Lootbox
{
    internal class Program
    {
        static void Main()
        {
            var firstBox = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            var secondBox = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            int collectedItemsValue = 0;

            while (firstBox.Count > 0 && secondBox.Count > 0)
            {
                int item1 = firstBox.Peek();
                int item2 = secondBox.Peek();
                int currentSum = item1 + item2;

                if (currentSum % 2 == 0)
                {
                    collectedItemsValue += currentSum;
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    secondBox.Pop();
                    firstBox.Enqueue(item2);
                }

            }

            if (firstBox.Count == 0)
            {
                Console.WriteLine("First lootbox is empty");
            }
            if (secondBox.Count == 0)
            {
                Console.WriteLine("Second lootbox is empty");
            }
            if (collectedItemsValue >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {collectedItemsValue}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {collectedItemsValue}");
            }
        }
    }
}
