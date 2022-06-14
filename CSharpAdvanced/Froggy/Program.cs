using System;
using System.Collections.Generic;
using System.Linq;

namespace Froggy
{
    internal class Program
    {
        static void Main()
        {
            var lake = new Lake();
            lake.Stones = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
            var oddStones = new List<int>();
            var evenStones = new List<int>();

            for (int i = 0; i < lake.Stones.Count; i++)
            {
                if (i % 2 == 0)
                {
                    evenStones.Add(lake.Stones[i]);
                }
                else
                {
                    oddStones.Add(lake.Stones[i]);
                }
            }
            oddStones.Reverse();
            var allStones = evenStones;
            foreach (int stone in oddStones)
            {
                allStones.Add(stone);
            }

            Console.WriteLine(String.Join(", ", allStones));
        }
    }
}
