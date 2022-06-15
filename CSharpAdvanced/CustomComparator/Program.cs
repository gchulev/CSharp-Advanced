using System;
using System.Linq;

namespace CustomComparator
{
    public class Program
    {
        static void Main()
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Func<int, int, int> compare = (x, y) => x % 2 == 0 && y % 2 != 0 ? -1 : x % 2 != 0 && y % 2 == 0 ? 1 : x > y ? 1 : x < y ? -1 : 0;
            Array.Sort(input,(x, y) => compare(x, y));
            Console.WriteLine(String.Join(' ', input));
        }
    }
}
