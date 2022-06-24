using System;
using System.Collections.Generic;
using System.Linq;

namespace WarmWinter
{
    internal class Program
    {
        static void Main()
        {
            var hats = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));
            var scarfs = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            var createdSets = new List<int>();
            int mostExpensiveSet = 0;

            while (hats.Count > 0 && scarfs.Count > 0)
            {
                int currentHat = hats.Peek();
                int currentScarf = scarfs.Peek();

                if (currentHat > currentScarf)
                {
                    int currentSet = currentHat + currentScarf;
                    if (mostExpensiveSet < currentSet)
                    {
                        mostExpensiveSet = currentSet;
                    }
                    hats.Pop();
                    scarfs.Dequeue();
                    createdSets.Add(currentSet);
                }
                else if (currentHat == currentScarf)
                {
                    currentHat++;
                    hats.Pop();
                    hats.Push(currentHat);
                    scarfs.Dequeue();
                }
                else
                {
                    hats.Pop();
                }
            }

            Console.WriteLine($"The most expensive set is: {mostExpensiveSet}");
            Console.WriteLine(String.Join(' ', createdSets));
        }
    }
}
