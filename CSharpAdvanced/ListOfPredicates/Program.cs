using System;
using System.Collections.Generic;
using System.Linq;

namespace ListOfPredicates
{
    internal class Program
    {
        static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            HashSet<int> uniqueNums = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToHashSet();

            List<int> numbers = uniqueNums.ToList();

            Func<List<int>, List<int>> dividers =
                    ls =>
                    {
                        var output = new List<int>();

                        for (int i = 1; i <= n; i++)
                        {
                            bool canBeDivided = true;
                            for (int c = 0; c < ls.Count; c++)
                            {
                                if (i % ls[c] != 0)
                                {
                                    canBeDivided = false;
                                    break;
                                }
                            }
                            if (canBeDivided)
                            {
                                output.Add(i);
                            }
                        }
                        return output;
                    };
            Console.WriteLine($"{string.Join(' ', dividers(numbers))}");
        }
    }
}
