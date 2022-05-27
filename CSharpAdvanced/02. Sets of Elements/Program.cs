using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    internal class Program
    {
        static void Main()
        {
            int[] setsLength = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int n = setsLength[0];
            int m = setsLength[1];
            var set1 = new HashSet<int>();
            var set2 = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                int numToAdd = int.Parse(Console.ReadLine());
                set1.Add(numToAdd);
            }
            for (int i = 0; i < m; i++)
            {
                int numToAdd = int.Parse(Console.ReadLine());
                set2.Add(numToAdd);
            }

            int[] set3 = set1.Intersect(set2).ToArray();
            Console.WriteLine(String.Join(' ', set3));
        }
    }
}
