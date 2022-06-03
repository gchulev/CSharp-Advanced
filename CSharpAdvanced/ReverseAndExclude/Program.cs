using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseAndExclude
{
    internal class Program
    {
        static void Main()
        {
            List<int> numbers = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            int num = int.Parse(Console.ReadLine());

            Func<int, int, bool> isDivisible = (x, y) => x % y == 0;
            numbers.Reverse();
            var test = numbers.Select(x => isDivisible(x, num)).ToList();
            Predicate<int> isDivisbleBynNum = x => x % num == 0;
            numbers.RemoveAll(isDivisbleBynNum);
            Console.WriteLine(String.Join(' ', numbers));
        }
    }
}
