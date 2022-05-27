using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Periodic_Table
{
    internal class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            var uniqueElements = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] elements = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach (string element in elements)
                {
                    uniqueElements.Add(element);
                }
            }
            var orderedUniqueElements = uniqueElements.OrderBy(x => x).ToArray();
            Console.WriteLine(String.Join(' ', orderedUniqueElements));
        }
    }
}
