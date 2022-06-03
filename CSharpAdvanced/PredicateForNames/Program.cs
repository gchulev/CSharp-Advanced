using System;
using System.Collections.Generic;
using System.Linq;

namespace PredicateForNames
{
    internal class Program
    {
        static void Main()
        {
            int length = int.Parse(Console.ReadLine());
            List<string> names = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToList();

            Predicate<string> isLongerThan = x => x.Length <= length;
            var result = names.FindAll(x => isLongerThan(x)).ToList();
            Console.WriteLine(String.Join($"{Environment.NewLine}", result));
        }
    }
}
